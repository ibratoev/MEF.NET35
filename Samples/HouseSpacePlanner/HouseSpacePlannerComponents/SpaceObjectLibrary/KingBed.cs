//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace HouseSpacePlanner
{
    using System;
    using System.ComponentModel.Composition;
    using HouseSpacePlannerComponents;

    [SpaceObject("Furniture", "King Bed")]
    public class KingBed : XamlSpaceObject
    {
        public KingBed()
            : base(6, 7) { }

        protected override string CanvasXaml
        {
            get { return HouseSpacePlannerComponents.SpaceObjectLibrary.XamlDictionary.Xaml_KindBed; }
        }
    }
}
