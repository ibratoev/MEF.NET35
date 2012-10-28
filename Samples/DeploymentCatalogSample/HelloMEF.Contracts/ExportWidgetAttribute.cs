using System;
using System.Windows.Controls;
using System.ComponentModel.Composition;

namespace HelloMEF
{
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple=false)]
    public class ExportWidgetAttribute : ExportAttribute
    {
        public ExportWidgetAttribute()
            :base(typeof(UserControl))
        {
        }

        public WidgetLocation Location { get; set; }
    }
}
