//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace HouseSpacePlanner
{
    using System.ComponentModel.Composition;

    [Export(typeof(IDimensionToPixelConverter))]
    public class DefaultDimensionToPixelConverter : IDimensionToPixelConverter
    {
        #region IDimensionToPixelConverter Members

        public double ToPixel(double value)
        {
            return value * 10;
        }

        #endregion
    }
}
