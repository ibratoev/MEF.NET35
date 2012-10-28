//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace HouseSpacePlanner
{
    using System;
    using System.ComponentModel.Composition;
    using System.Windows;
    using System.Windows.Controls;

    [CLSCompliant(false)]
    public interface IElementRotationService
    {
        void RegisterRotatingElement(Canvas element);
        void RegisterRotationSurface(FrameworkElement element);
    }
}
