using System;
using System.ComponentModel.Composition;

[MetadataAttribute]
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class ExportGridExtension : ExportAttribute, IGridExtensionMetadata  
{
    public ExportGridExtension(string name, string description)
        : base(typeof(IGridExtension))
    {
        this.Name = name;
        this.Description = description;
    }

    public string Name { get; set; }
    public string Description { get; set; }
}