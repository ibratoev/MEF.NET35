//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace HouseSpacePlanner
{
    using System;
    using System.ComponentModel.Composition;
    using System.Windows;

    [CLSCompliant(false)]
    public class ShapeSelectedEventArgs : EventArgs
    {
        public FrameworkElement PreviouslySelectedShape { get; set; }
        public FrameworkElement NewSelectedShape { get; set; }
    }

    [CLSCompliant(false)]
    public interface IElementMovingService
    {
        void RegisterSurfaceElement(FrameworkElement element, bool isSurface);
        void RegisterMovingElement(FrameworkElement element);
        event EventHandler<ShapeSelectedEventArgs> ShapeSelectedChanged;
        FrameworkElement ShapeSelected { get; }
    }

}
