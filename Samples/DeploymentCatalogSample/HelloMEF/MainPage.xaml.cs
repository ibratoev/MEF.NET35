using System;
using System.Windows.Controls;
using System.ComponentModel.Composition;

namespace HelloMEF
{
    public partial class MainPage : UserControl, IPartImportsSatisfiedNotification
    {
        public MainPage()
        {
            InitializeComponent();
            CompositionInitializer.SatisfyImports(this);
        }

        [ImportMany(AllowRecomposition=true)]
        public Lazy<UserControl,IWidgetMetadata>[] Widgets { get; set; }

        #region IPartImportsSatisfiedNotification Members

        public void OnImportsSatisfied()
        {
            TopWidgets.Items.Clear();
            BottomWidgets.Items.Clear();

            foreach (var widget in Widgets)
            {
                if (widget.Metadata.Location == WidgetLocation.Top)
                    TopWidgets.Items.Add(widget.Value);
                else if (widget.Metadata.Location == WidgetLocation.Bottom)
                    BottomWidgets.Items.Add(widget.Value);
            }
        }

        #endregion
    }
}
