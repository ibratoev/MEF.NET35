//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace HouseSpacePlanner
{
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Shapes;

    public class WallSpaceObject : SpaceObject
    {
        protected List<Wall> Walls { get; private set; }

        public WallSpaceObject(double width, double height)
            : base(width, height)
        {
            Walls = new List<Wall>();
        }

        public override void OnImportsSatisfied()
        {
            base.OnImportsSatisfied();
            foreach (Wall wall in Walls)
            {
                wall.PixelConverter = PixelConvereter;
                wall.WallDepth = ShapeWallDepth;
                UIElement wallShape = wall.Shape;
                wallShape.IsHitTestVisible = false;
                Children.Add(wallShape);
            }
        }

        protected virtual WallDepth ShapeWallDepth { get { return WallDepth.Normal; } }

    }

    public enum WallPosition
    {
        WE,
        NWSE,
        NS,
        SWNE
    }

    public enum WallDepth
    {
        Normal,
        Thin,
        Thick
    }

    public class Wall
    {
        private Rectangle shape;


        public Wall(double x, double y, double length, WallPosition position)
        {
            X = x;
            Y = y;
            Length = length;
            WallPosition = position;
        }
        public double X { get; private set; }
        public double Y { get; private set; }
        public WallPosition WallPosition { get; private set; }
        public double Length { get; private set; }
        public WallDepth WallDepth { get; set; }
        public IDimensionToPixelConverter PixelConverter { get; set; }


        public virtual FrameworkElement Shape
        {
            get
            {
                if (shape == null)
                {
                    shape = new Rectangle();
                    shape.Fill = new SolidColorBrush(Colors.Black);
                    shape.SetValue(Canvas.TopProperty, PixelConverter.ToPixel(Y));
                    shape.SetValue(Canvas.LeftProperty, PixelConverter.ToPixel(X));
                    shape.Width = PixelConverter.ToPixel(Length);
                    shape.Height = DepthToPixel(WallDepth);
                    TranslateTransform transform = new TranslateTransform();
                    transform.Y = -shape.Height / 2;
                    RotateTransform rotTransform = new RotateTransform();
                    switch (WallPosition)
                    {
                        case WallPosition.NS:
                            rotTransform.Angle = 90;
                            break;
                        case WallPosition.NWSE:
                            rotTransform.Angle = 45;
                            break;
                        case WallPosition.SWNE:
                            rotTransform.Angle = -45;
                            break;
                        default:
                            break;
                    }
                    TransformGroup transformGroup = new TransformGroup();
                    transformGroup.Children.Add(transform);
                    transformGroup.Children.Add(rotTransform);
                    shape.RenderTransform = transformGroup;
                }
                return shape;
            }
        }

        private double DepthToPixel(WallDepth depth)
        {
            switch (depth)
            {
                case WallDepth.Thick:
                    return 4;
                case WallDepth.Thin:
                    return 1;
                default:
                    return 2;
            }
        }
    }
}


