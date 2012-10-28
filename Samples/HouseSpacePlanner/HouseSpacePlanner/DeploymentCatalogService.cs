using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using HouseSpacePlannerCommon;

namespace HouseSpacePlanner
{
    [Export(typeof(IDeploymentCatalogService))]
    public class DeploymentCatalogService : IDeploymentCatalogService
    {
        private static AggregateCatalog _aggregateCatalog;

        Dictionary<string, DeploymentCatalog> _catalogs;

        public DeploymentCatalogService()
        {
            _catalogs = new Dictionary<string, DeploymentCatalog>();
        }

        public static void Initialize()
        {
            _aggregateCatalog = new AggregateCatalog();
            _aggregateCatalog.Catalogs.Add(new DeploymentCatalog());
            CompositionHost.Initialize(_aggregateCatalog);
        }

        public void AddXap(string uri)
        {
            DeploymentCatalog catalog;
            if (!_catalogs.TryGetValue(uri, out catalog))
            {
                catalog = new DeploymentCatalog(uri);
                catalog.DownloadAsync();
                _catalogs[uri] = catalog;
            }
            _aggregateCatalog.Catalogs.Add(catalog);
        }

        public void RemoveXap(string uri)
        {
            DeploymentCatalog catalog;
            if (_catalogs.TryGetValue(uri, out catalog))
            {
                _aggregateCatalog.Catalogs.Remove(catalog);
            }
        }
    }
}
