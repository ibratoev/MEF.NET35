//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace HouseSpacePlanner
{
    using System;
    using System.ComponentModel.Composition;
    using HouseSpacePlannerComponents;

    [SpaceObject("Plan", "1 Br Apt")]
    public class RoomType1 : WallSpaceObject
    {
        public RoomType1()
            : base(27, 38)
        {
 
            Walls.Add(new Wall(0, 2, 2, WallPosition.WE));
            Walls.Add(new Wall(5, 2, 6, WallPosition.WE));
            Walls.Add(new Wall(5, 2, 3, WallPosition.NWSE));
            Walls.Add(new Wall(11, 0, 7, WallPosition.NS));
            Walls.Add(new Wall(11, 1, 16, WallPosition.WE));
            Walls.Add(new Wall(0, 12, 1, WallPosition.WE));
            Walls.Add(new Wall(4, 12, 4, WallPosition.WE));
            Walls.Add(new Wall(5, 12, 10, WallPosition.NS));
            Walls.Add(new Wall(0, 2, 20, WallPosition.NS));
            Walls.Add(new Wall(0, 22, 8, WallPosition.WE));
            Walls.Add(new Wall(8, 12, 10, WallPosition.NS));
            Walls.Add(new Wall(4, 22, 16, WallPosition.NS));
            Walls.Add(new Wall(4, 38, 23, WallPosition.WE));
            Walls.Add(new Wall(11, 0, 16, WallPosition.WE));
            Walls.Add(new Wall(27, 0, 38, WallPosition.NS));
            Walls.Add(new Wall(12, 22, 15, WallPosition.WE));
            Walls.Add(new Wall(12, 12, 13, WallPosition.NS));
            Walls.Add(new Wall(12, 28, 10, WallPosition.NS));
            Walls.Add(new Wall(12, 28, 3, WallPosition.NWSE));
            Walls.Add(new Wall(4, 30, 2, WallPosition.WE));
            Walls.Add(new Wall(9, 30, 3, WallPosition.WE));
            Walls.Add(new Wall(9, 30, 3, WallPosition.SWNE));
            Walls.Add(new Wall(4, 35, 8, WallPosition.WE));
            Walls.Add(new Wall(10, 30, 5, WallPosition.NS));
        }

        protected override WallDepth ShapeWallDepth
        {
            get
            {
                return WallDepth.Thick;
            }
        }
    }
}
