using System.Windows.Controls;
using HelloMEF.Contracts;
using System.ComponentModel.Composition;

namespace HelloMEF
{
    [ExportWidget(Location = WidgetLocation.Bottom)]
    public partial class Widget2 : UserControl
    {
        public Widget2()
        {
            InitializeComponent();
        }
    }
}
