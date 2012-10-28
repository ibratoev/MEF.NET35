using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace HelloMEF.Extensions
{
    [ExportWidget(Location = WidgetLocation.Top)]
    public partial class Widget4 : UserControl
    {
        public Widget4()
        {
            InitializeComponent();
        }
    }
}
