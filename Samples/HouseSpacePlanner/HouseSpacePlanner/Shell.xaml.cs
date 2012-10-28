//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace HouseSpacePlanner
{
    using System.ComponentModel.Composition;
    using System.Windows;
    using System.Windows.Controls;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using HouseSpacePlannerCommon;

    public partial class Shell : UserControl
    {
        [Import]
        public IPlanningSurfacePane PlanningSurface
        {
            set
            {
                UIElement surface = (UIElement) value;
                surface.SetValue(Grid.ColumnProperty, 1);
                surface.SetValue(Grid.RowSpanProperty, 2);
                mainPanelGrid.Children.Add(surface);
            }
        }

        [ImportMany]
        public Lazy<ISpaceObjectToolbox, ISpaceObjectToolboxMetadata>[] Toolboxes
        {
            set
            {
                foreach (var toolboxExport in value)
                {
                    var toolbox = (Control) toolboxExport.Value;
                    if (toolboxExport.Metadata.ToolboxType == ToolboxType.Furniture)
                    {
                        toolbox.SetValue(Grid.ColumnProperty, 0);
                    }
                    else
                    { 
                        toolbox.SetValue(Grid.RowProperty, 1);
                    }
                    toolbox.DataContext = toolboxExport.Metadata.ToolboxType.ToString().ToUpper();                    
                    mainPanelGrid.Children.Add(toolbox);
                }
            }
        }

        [Import]
        public IOptionalComponentPane OptionalComponentsPane
        {
            set
            {
                UIElement surface = (UIElement) value;
                optionalComponentsPaneContainer.Child = surface;
            }
        }

        public Shell()
        {
            InitializeComponent();
            CompositionInitializer.SatisfyImports(this);
        }

    }
}
