using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Windows.Controls;
using System.Windows;
using HelloMEF.Contracts;

namespace HelloMEF
{
    [ExportWidget(Location=WidgetLocation.Top)]
    public partial class Widget1 : UserControl
    {
        [Import]
        public IDeploymentCatalogService CatalogService { get; set; }

        public Widget1()
        {
            InitializeComponent();
            Download.Click += new RoutedEventHandler(Download_Click);
        }

        void Download_Click(object sender, RoutedEventArgs e)
        {
            CatalogService.AddXap("HelloMEF.Extensions.Xap");
        }
    }
}
