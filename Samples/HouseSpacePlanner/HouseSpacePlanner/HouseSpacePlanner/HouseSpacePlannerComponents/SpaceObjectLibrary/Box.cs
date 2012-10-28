//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace HouseSpacePlanner
{
    using System;
    using System.ComponentModel.Composition;
    
    [Export(typeof(SpaceObject))]
    [ExportMetadata("Name", "Box")]
    [ExportMetadata("Type", "Furniture")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [CLSCompliant(false)]
    public class SimpleBox : XamlSpaceObject
    {
        public SimpleBox() : base(5, 5) { }


        protected override string CanvasXaml
        {
            get { return HouseSpacePlannerComponents.SpaceObjectLibrary.XamlDictionary.Xaml_Box; }
        }
    }
}
