using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace HelloMEF.Contracts
{

    public interface IDeploymentCatalogService
    {
        void AddXap(string uri);
        void RemoveXap(string uri);
    }
    
}
