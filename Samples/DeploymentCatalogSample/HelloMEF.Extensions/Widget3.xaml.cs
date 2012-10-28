using System.Windows.Controls;

namespace HelloMEF.Extensions
{
    [ExportWidget(Location=WidgetLocation.Bottom)]
    public partial class Widget3 : UserControl
    {
        public Widget3()
        {
            InitializeComponent();
        }
    }
}
