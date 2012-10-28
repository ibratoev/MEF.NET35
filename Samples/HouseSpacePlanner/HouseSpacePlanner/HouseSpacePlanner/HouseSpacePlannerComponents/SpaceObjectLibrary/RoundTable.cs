//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace HouseSpacePlanner
{
    using System;
    using System.ComponentModel.Composition;
    using HouseSpacePlannerComponents;

    [SpaceObject("Furniture", "Round Table")]
    public class RoundTable : XamlSpaceObject
    {

        public RoundTable()
            : base(3, 3) { }

        protected override string CanvasXaml
        {
            get { return HouseSpacePlannerComponents.SpaceObjectLibrary.XamlDictionary.Xaml_RoundTable; }
        }
    }
}
