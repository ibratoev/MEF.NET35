//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace HouseSpacePlanner
{
    using System;
    using System.Windows.Controls;
    using System.Windows.Markup;
    using System.Windows.Media;

    public abstract class XamlSpaceObject : SpaceObject
    {
        public XamlSpaceObject(double width, double height)
            : base(width, height) { }

        public override void OnImportsSatisfied()
        {
            base.OnImportsSatisfied();
            Canvas canvas = (Canvas)XamlReader.Load(CanvasXaml);
            ScaleTransform scaleTransform = new ScaleTransform();
            scaleTransform.ScaleX = Width / canvas.Width;
            scaleTransform.ScaleY = Height / canvas.Height;
            canvas.RenderTransform = scaleTransform;
            Children.Add(canvas);
        }

        protected abstract string CanvasXaml { get; }
    }
}
