//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace HouseSpacePlanner
{
    using System.ComponentModel.Composition;

    public interface IDimensionToPixelConverter
    {
        double ToPixel(double value);
    }

}
