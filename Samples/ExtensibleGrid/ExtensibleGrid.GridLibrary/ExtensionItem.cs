using System;
using System.Net;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;

namespace ExtensibleGrid.GridLibrary
{
    public class ExtensionItem
    {
        public Lazy<IGridExtension, IGridExtensionMetadata> GridExtension { get; set; }
        public bool Enabled { get; set; }
        public bool Activated { get; set; }
    }

}
