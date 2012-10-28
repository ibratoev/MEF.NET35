//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace HouseSpacePlanner
{
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System;
    using System.Collections.ObjectModel;
    using HouseSpacePlannerCommon;

    [Export(typeof(IPlanningSurfacePane))]
    public partial class PlanningPane : UserControl, IPartImportsSatisfiedNotification, IPlanningSurfacePane
    {
        private IElementMovingService elementMovingService;
        private IElementRotationService elementRotationService;
        private readonly ObservableCollection<SpaceObject> surfaceItems =
            new ObservableCollection<SpaceObject>();

        public PlanningPane()
        {
            surfaceItems.CollectionChanged += delegate
            {
                RebindShapes(surfaceItems);
            };

            InitializeComponent();
        }

        [Export("SurfaceItems")]
        public ICollection<SpaceObject> SurfaceItems
        {
            get { return surfaceItems; }
        }

        [Import(AllowDefault=true, AllowRecomposition=true)]
        public IElementMovingService ElementMovingService
        {
            get { return elementMovingService; }
            set { elementMovingService = value; }
        }

        [Import(AllowDefault = true, AllowRecomposition=true)]
        public IElementRotationService ElementRotationService
        {
            get { return elementRotationService; }
            set { elementRotationService = value; }
        }
        
        private IEnumerable<SpaceObject> SpaceObjectsOnSurface
        {
            get
            {
                return   from x in planningPaneCanvas.Children
                    where (x is SpaceObject)
                    select x as SpaceObject;
            }
        }

        private void RebindShapes(IEnumerable<SpaceObject> spaceObjects)
        {
            List<SpaceObject> existingSpaceObects = new List<SpaceObject>(SpaceObjectsOnSurface);

            foreach (var toRemove in existingSpaceObects)
            {
                planningPaneCanvas.Children.Remove(toRemove);
            }

            foreach (var spaceObject in spaceObjects)
            {
                if (ElementMovingService != null)
                {
                    ElementMovingService.RegisterMovingElement(spaceObject);
                }
                if (ElementRotationService != null)
                {
                    ElementRotationService.RegisterRotatingElement(spaceObject);
                }

                planningPaneCanvas.Children.Add(spaceObject);                  
            }
        }


        private void ButtonRemoveClicked(object sender, RoutedEventArgs e)
        {
            SpaceObject spaceObject = ElementMovingService.ShapeSelected as SpaceObject; 
            if (spaceObject != null)
            {
                spaceObject.RemoveFromPlanningSurface();
            }
        }

        public void OnImportsSatisfied()
        {
            if (ElementMovingService != null)
            {
                foreach (var spaceObject in SpaceObjectsOnSurface)
                {
                    ElementMovingService.RegisterMovingElement(spaceObject);
                }
                ElementMovingService.RegisterSurfaceElement(planningPaneCanvas, true);
                ElementMovingService.RegisterSurfaceElement(Parent as FrameworkElement, false);
                ElementMovingService.ShapeSelectedChanged += ElementMovingService_ShapeSelectedChanged;
            }

            if (ElementRotationService != null)
            {
                foreach (var spaceObject in SpaceObjectsOnSurface)
                {
                    ElementRotationService.RegisterRotatingElement(spaceObject);
                }
                ElementRotationService.RegisterRotationSurface(planningPaneCanvas);
                ElementRotationService.RegisterRotationSurface(Parent as FrameworkElement);
            }
        }

        void ElementMovingService_ShapeSelectedChanged(object sender, ShapeSelectedEventArgs e)
        {
            if (e.NewSelectedShape != null)
            {
                SpaceObject previouslySelectedShape = e.PreviouslySelectedShape as SpaceObject;
                SpaceObject newSelectedShape = e.NewSelectedShape as SpaceObject;
                if (previouslySelectedShape != null)
                {
                    previouslySelectedShape.Background = new SolidColorBrush(Colors.Transparent);
                }
                newSelectedShape.Background = new SolidColorBrush(Color.FromArgb(100, 100, 255, 255));
                contextPanel.Visibility = Visibility.Visible;
                selectedShapeHeight.Text = newSelectedShape.RelativeHeight.ToString("N");
                selectedShapeWidth.Text = newSelectedShape.RelativeWidth.ToString("N");
            }
            else
            {
                contextPanel.Visibility = Visibility.Collapsed;
            }
        }
    }
}
 