//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace HouseSpacePlanner
{
    using System.ComponentModel.Composition;
    using System.Diagnostics;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Controls;
    using System.ComponentModel.Composition.Hosting;
    using HouseSpacePlannerCommon;
    using System;
    using System.ComponentModel;

    [Export(typeof(IOptionalComponentPane))]
    public partial class OptionalComponentsPane : UserControl, IOptionalComponentPane
    {
        [Import]
        public IDeploymentCatalogService DeploymentService { get; set; }

        public OptionalComponentsPane()
        {
            InitializeComponent();
            optionalItems.ItemsSource = new OptionalComponentInfo[] {
                new OptionalComponentInfo(){
                    Name = "HouseSpacePlannerComponents.xap",
                    Description = "Shape components",
                    Uri="HouseSpacePlannerComponents.xap"
                },
                   new OptionalComponentInfo(){
                    Name = "HouseSpacePlannerServices.xap",
                    Description = "Moving and rotation services",
                    Uri="HouseSpacePlannerServices.xap"
                   }
            };
        }

        private void OptionalComponentChecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            Debug.Assert(checkBox != null);

            var componentInfo = checkBox.DataContext as OptionalComponentInfo;
            Debug.Assert(componentInfo != null);
            //Package.DownloadPackageAsync(new Uri(componentInfo.Uri, UriKind.Relative), PackageReceived); 
            DeploymentService.AddXap(componentInfo.Uri);
        }

        //private void PackageReceived(AsyncCompletedEventArgs e, Package p)
        //{
        //    Packages.AddPackage(p);
        //}



        //
        // TODO: removing from Catalog doesn't work
        //
        private void OptionalComponentUnchecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            Debug.Assert(checkBox != null);

            var componentInfo = checkBox.DataContext as OptionalComponentInfo;
            Debug.Assert(componentInfo != null);

            //PartCatalog.Catalogs.Remove(componentInfo.AssemblyCatalog);
            DeploymentService.RemoveXap(componentInfo.Uri);
        }

        public class OptionalComponentInfo
        {
            public string Name { get; set; }
            public string Description { get; set; }
            internal string Uri { get; set; }
            //public Package Package { get; set; }
        }
    }
}
