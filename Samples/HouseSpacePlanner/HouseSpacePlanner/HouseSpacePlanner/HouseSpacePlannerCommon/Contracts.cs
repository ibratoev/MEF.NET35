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
using System.ComponentModel.Composition;

namespace HouseSpacePlannerCommon
{
    public interface ISpaceObjectToolbox
    {
    }

    public interface ISpaceObjectToolboxMetadata
    {
        ToolboxType ToolboxType { get; }
    }

    public enum ToolboxType { Furniture, House }

    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple=false)]
    public class ExportSpaceObjectToolboxAttribute : ExportAttribute
    {
        public ExportSpaceObjectToolboxAttribute(ToolboxType toolboxType)
            :base(typeof(ISpaceObjectToolbox))
        {
            this.ToolboxType = toolboxType;
        }

        public ToolboxType ToolboxType { get; protected set; }
    }

    public interface IPlanningSurfacePane { }

    public interface IOptionalComponentPane { }
    

}
