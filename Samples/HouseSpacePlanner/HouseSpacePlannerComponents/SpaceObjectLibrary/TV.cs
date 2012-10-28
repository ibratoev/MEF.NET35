//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace HouseSpacePlanner
{
    using System;
    using System.ComponentModel.Composition;
    using HouseSpacePlannerComponents;

    [SpaceObject("Furniture", "TV")]
    public class TV : XamlSpaceObject
    {
        public TV()
            : base(9, 3){}

        protected override string CanvasXaml
        {
            get { return HouseSpacePlannerComponents.SpaceObjectLibrary.XamlDictionary.Xaml_TV; }
        }
    }
}
