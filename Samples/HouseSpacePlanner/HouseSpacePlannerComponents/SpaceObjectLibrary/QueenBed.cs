//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace HouseSpacePlanner
{
    using System;
    using System.ComponentModel.Composition;
    using HouseSpacePlannerComponents;

    [SpaceObject("Furniture", "Queen Bed")]
    public class QueenBed : XamlSpaceObject
    {
        public QueenBed()
            : base(5, 7) { }

        protected override string CanvasXaml
        {
            get { return HouseSpacePlannerComponents.SpaceObjectLibrary.XamlDictionary.Xaml_QueenBed; }
        }
    }
}
