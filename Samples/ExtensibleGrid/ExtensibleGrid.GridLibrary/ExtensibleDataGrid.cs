using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using ExtensibleGrid.GridLibrary.GridLibrary;
using System.Windows.Controls.Primitives;
using System.ComponentModel;

namespace ExtensibleGrid.GridLibrary
{
    public class ExtensibleDataGrid : DataGrid
    {
        private ConfigDialog dialog { get; set; }
        private IEnumerable<ExtensionItem> extensionItems;
    
        public override void OnApplyTemplate()
        {
            dialog = new ConfigDialog();
            dialog.OKButton.Click += new RoutedEventHandler(OKButton_Click);
            dialog.CancelButton.Click += new RoutedEventHandler(CancelButton_Click);
            Button ConfigButton = GetTemplateChild("ConfigButton") as Button;

            if (ConfigButton != null)
            {
                ConfigButton.Click += new RoutedEventHandler(ConfigButton_Click);
            }
            base.OnApplyTemplate();
        }

        void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            dialog.Close();
        }

        void OKButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var extensionItem in extensionItems)
            {
                if (extensionItem.Enabled == true && extensionItem.Activated == false)
                {
                    var extension = extensionItem.GridExtension.Value;
                    extension.Initialize(this);
                    extensionItem.Activated = true;
                }
            }
            
        }

        void ConfigButton_Click(object sender, RoutedEventArgs e)
        {
            dialog.DataContext = extensionItems;
            dialog.Show();
        }

        public ExtensibleDataGrid()
        {
            this.Loaded += new RoutedEventHandler(MefGrid_Loaded);
            DefaultStyleKey = typeof(ExtensibleDataGrid);
        }

        void MefGrid_Loaded(object sender, RoutedEventArgs e)
        {
            CompositionInitializer.SatisfyImports(this);
            extensionItems = Extensions.Select(ex => new ExtensionItem { GridExtension = ex }).ToArray();
        }

        [ImportMany]
        public IEnumerable<Lazy<IGridExtension, IGridExtensionMetadata>> Extensions { get; set; }

    }
}

//does not NEED to implement IGridExtensionMetadata, but ensures the members are there