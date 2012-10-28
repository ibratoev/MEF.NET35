//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace HouseSpacePlanner
{
    using System;
    using System.ComponentModel.Composition;
    using HouseSpacePlannerComponents.SpaceObjectLibrary;
    using HouseSpacePlannerComponents;

    [SpaceObject("Furniture", "Round Desk")]
    public class RoundDesk : XamlSpaceObject
    {
        public RoundDesk()
            : base(5, 3.5) { }

        protected override string CanvasXaml
        {
            get { return XamlDictionary.Xaml_RoundDesk; }
        }
    }
}
