using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using HouseSpacePlanner;
using System.ComponentModel.Composition;

namespace HouseSpacePlannerComponents
{
    [MetadataAttribute, AttributeUsage(AttributeTargets.Class, AllowMultiple=false)]
    public class SpaceObjectAttribute : ExportAttribute, ISpaceObjectMetadata
    {
        public SpaceObjectAttribute(string type, string name)
            : base(typeof(SpaceObject))
        {
            Name = name;
            Type = type;
        }

        public string Name { get; set; }

        public string Type { get; set; }
    }
}
