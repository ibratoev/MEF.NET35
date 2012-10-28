//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace HouseSpacePlanner
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Shapes;


    [CLSCompliant(false)]
    [Export(typeof(IElementRotationService)), PartCreationPolicy(CreationPolicy.NonShared)]
    public class ElementRotatingService : IElementRotationService, IDisposable
    {
        internal const string RotationElementTag = "RotationElementTag";
        private const double RotationElementRadius = 5;
        private Canvas rotatingElement;
        private List<FrameworkElement> registeredObjects = new List<FrameworkElement>();

        #region IElementRotationService Members

        public void RegisterRotatingElement(Canvas element)
        {
            AddRotationHandle(element);
        }

        public void RegisterRotationSurface(FrameworkElement element)
        {
            if (!registeredObjects.Contains(element))
            {
                registeredObjects.Add(element);
                element.MouseLeftButtonUp += MouseUp;
                element.MouseMove += MouseMoving;
            }
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            foreach (var element in registeredObjects)
            {
                element.MouseLeftButtonDown -= MouseDown;
                element.MouseLeftButtonUp -= MouseUp;
                element.MouseMove -= MouseMoving;
                Panel panel = element as Panel;
                if (panel != null)
                {
                    var rotationHandle = panel.Children.SingleOrDefault(x => x is FrameworkElement
                        && (string)((FrameworkElement)x).Tag == RotationElementTag);
                    if (rotationHandle != null)
                    {
                        panel.Children.Remove(rotationHandle);
                    }
                }
            }
            registeredObjects.Clear();
        }

        #endregion

        private void AddRotationHandle(Canvas element)
        {
            if (!registeredObjects.Contains(element))
            {
                registeredObjects.Add(element);
                Ellipse ellipse = new Ellipse();
                ellipse.Tag = RotationElementTag;
                ellipse.Width = ellipse.Height = RotationElementRadius * 2;
                ellipse.Fill = new SolidColorBrush(Colors.Blue);
                ellipse.SetValue(Canvas.TopProperty, -RotationElementRadius);
                ellipse.SetValue(Canvas.LeftProperty, -RotationElementRadius);
                ellipse.SetValue(Canvas.ZIndexProperty, (int)short.MaxValue);
                ellipse.MouseLeftButtonDown += MouseDown;
                ellipse.MouseLeftButtonUp += MouseUp;
                ellipse.MouseMove += MouseMoving;
                if (!(element.RenderTransform is RotateTransform))
                {
                    element.RenderTransform = new RotateTransform()
                    {
                        CenterX = element.Width / 2,
                        CenterY = element.Height / 2
                    };
                }
                element.Children.Add(ellipse);
            }
        }

        private void MouseDown(object sender, MouseButtonEventArgs e)
        {
            rotatingElement = ((Ellipse)sender).Parent as Canvas;
        }

        private void MouseUp(object sender, MouseButtonEventArgs e)
        {
            rotatingElement = null;
        }

        private void MouseMoving(object sender, MouseEventArgs e)
        {
            if (rotatingElement != null)
            {
                Point aPoint = new Point(0, 0);
                Point bPoint = e.GetPosition(rotatingElement);
                Point cPoint = new Point(rotatingElement.Width / 2, rotatingElement.Height / 2);
                double a = GetDistanceBetweenTwoPoints(bPoint, cPoint);
                double b = GetDistanceBetweenTwoPoints(aPoint, cPoint);
                double c = GetDistanceBetweenTwoPoints(aPoint, bPoint);
                double currentAngle = ((RotateTransform)rotatingElement.RenderTransform).Angle;

                double angle = GetAngleFromTriangleSides(a, b, c);

                if (0 - bPoint.X > 0.1)
                {
                    angle = -angle;
                }

                if (angle.CompareTo(double.NaN) != 0)
                {
                    RotateTransform rotateTransform = (RotateTransform)rotatingElement.RenderTransform;
                    rotateTransform.Angle += angle;
                    if (rotateTransform.Angle > 180)
                    {
                        rotateTransform.Angle = rotateTransform.Angle - 360;
                    }
                }
            }
        }

        private static double GetDistanceBetweenTwoPoints(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow((p2.Y - p1.Y), 2) + Math.Pow((p2.X - p1.X), 2));
        }

        //angle C is opposite side c
        private static double GetAngleFromTriangleSides(double a, double b, double c)
        {
            double cCosine = (a * a + b * b - c * c) / (2 * a * b);
            return Math.Acos(cCosine) * 180 / Math.PI;
        }
    }
}
