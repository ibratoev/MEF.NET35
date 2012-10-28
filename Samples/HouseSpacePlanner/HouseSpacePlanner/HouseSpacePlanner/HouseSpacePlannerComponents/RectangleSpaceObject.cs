//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------
namespace HouseSpacePlanner
{
    using System;

    public class RectangleSpaceObject:WallSpaceObject 
    {
        public RectangleSpaceObject(double width, double height):base(width, height)
        {
            Walls.Add(new Wall(0, 0, width, WallPosition.WE));
            Walls.Add(new Wall(width, 0, height, WallPosition.NS));
            Walls.Add(new Wall(0, 0, height, WallPosition.NS));
            Walls.Add(new Wall(0, height, width, WallPosition.WE));
        }
    }
}
