//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace HouseSpacePlanner
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;


    [CLSCompliant(false)]
    [Export(typeof(IElementMovingService)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class ElementMovingService : IElementMovingService, IDisposable
    {
        private FrameworkElement surfaceElement;
        bool isMoving;
        private double moveStartX;
        private double moveStartY;

        private List<FrameworkElement> registeredObjects = new List<FrameworkElement>();
        public FrameworkElement ShapeSelected { get; private set; }

        public event EventHandler<ShapeSelectedEventArgs> ShapeSelectedChanged;

        #region IElementMovingService Members

        public void RegisterSurfaceElement(FrameworkElement element, bool isSurface)
        {
            if (!registeredObjects.Contains(element))
            {
                registeredObjects.Add(element);
                    element.MouseLeftButtonUp += ShapeMouseUp;
                element.MouseMove += ShapeMouseMove;
            }
            if (isSurface)
            {
                surfaceElement = element;
            }
        }

        public void RegisterMovingElement(FrameworkElement element)
        {
            if (!registeredObjects.Contains(element))
            {
                registeredObjects.Add(element);
                element.MouseLeftButtonDown += ShapeMouseDown;
                element.MouseLeftButtonUp += ShapeMouseUp;
                element.MouseMove += ShapeMouseMove;
            }
        }

        #endregion
        
        #region IDisposable Members

        public void Dispose()
        {
            ShapeSelectedChanged(this, new ShapeSelectedEventArgs() { PreviouslySelectedShape = ShapeSelected, NewSelectedShape = null });
            ShapeSelected = null;
            foreach (var element in registeredObjects)
            {
                element.MouseLeftButtonDown -= ShapeMouseDown;
                element.MouseLeftButtonUp -= ShapeMouseUp;
                element.MouseMove -= ShapeMouseMove;
            }
            registeredObjects.Clear();
        }

        #endregion

        private void ShapeMouseDown(object sender, MouseButtonEventArgs e)
        {
            var originalSource = e.GetType().GetProperty("OriginalSource").GetValue(e, null);
            if ((string)((FrameworkElement)originalSource).Tag == ElementRotatingService.RotationElementTag)
                return;

            Point startPosition = e.GetPosition(surfaceElement);
            moveStartX = startPosition.X;
            moveStartY = startPosition.Y;
            if (ShapeSelectedChanged != null)
            {
                ShapeSelectedChanged(this, new ShapeSelectedEventArgs()
                {
                    PreviouslySelectedShape = ShapeSelected,
                    NewSelectedShape = sender as FrameworkElement
                });
            }
            ShapeSelected = sender as FrameworkElement;
            isMoving = true;
        }

        private void ShapeMouseMove(object sender, MouseEventArgs e)
        {
            if (ShapeSelected != null && isMoving)
            {
                Point newPosition = e.GetPosition(surfaceElement);
                double newLeft = ((double)ShapeSelected.GetValue(Canvas.LeftProperty)) + newPosition.X - moveStartX;
                double newTop = ((double)ShapeSelected.GetValue(Canvas.TopProperty)) + newPosition.Y - moveStartY;

                moveStartX = newPosition.X;
                moveStartY = newPosition.Y;

                if (newLeft >= 0 && newLeft <= surfaceElement.Width - ShapeSelected.Width)
                {
                    ShapeSelected.SetValue(Canvas.LeftProperty, newLeft);
                }
                else if (newLeft < 0)
                {
                    ShapeSelected.SetValue(Canvas.LeftProperty, 0.00);
                    moveStartX = 0;
                }
                else
                {
                    ShapeSelected.SetValue(Canvas.LeftProperty, surfaceElement.Width - ShapeSelected.Width);
                    moveStartX = surfaceElement.Width - ShapeSelected.Width;
                }

                if (newTop >= 0 && newTop <= surfaceElement.Height - ShapeSelected.Height)
                {
                    ShapeSelected.SetValue(Canvas.TopProperty, newTop);
                }
                else if (newTop < 0)
                {
                    ShapeSelected.SetValue(Canvas.TopProperty, 0.00);
                    moveStartY = 0;
                }
                else
                {
                    ShapeSelected.SetValue(Canvas.TopProperty, surfaceElement.Height - ShapeSelected.Height);
                    moveStartY = surfaceElement.Height - ShapeSelected.Height;
                }
            }
        }

        private void ShapeMouseUp(object sender, MouseEventArgs e)
        {
            isMoving = false;
        }
    }
}
