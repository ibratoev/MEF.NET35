//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace HouseSpacePlanner
{
    using System;
    using System.ComponentModel.Composition;
    using HouseSpacePlannerComponents;

    [SpaceObject("Plan", "Single Office")]
    public class MSSingleOffice : RectangleSpaceObject
    {
        public MSSingleOffice()
            : base(8, 12)
        {
            Walls.Add(new Wall(7, 3, 3, WallPosition.NS));
            Walls.Add(new Wall(0, 12, 3, WallPosition.SWNE));
        }
    }
}
