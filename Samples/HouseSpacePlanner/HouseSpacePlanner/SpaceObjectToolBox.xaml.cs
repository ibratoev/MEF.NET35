
namespace HouseSpacePlanner
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.ComponentModel.Composition.Hosting;
    using System.ComponentModel.Composition.Primitives;
    using HouseSpacePlannerCommon;

    public partial class SpaceObjectToolBox : UserControl, ISpaceObjectToolbox
    {
        private string spaceObjectTypeName;

        public SpaceObjectToolBox(string spaceObjectTypeName)
            : this()
        {
            this.spaceObjectTypeName = spaceObjectTypeName;     
        }

        public string SpaceObjectTypeName { get { return spaceObjectTypeName; } }

        [Import("SurfaceItems")]
        public ICollection<SpaceObject> SurfaceItems { get; set; }

        [ImportMany(AllowRecomposition=true)]
        public ExportFactory<SpaceObject, ISpaceObjectMetadata>[] SpaceObjects
        {
            set
            {             
                List<SpaceObjectBindingHelper> spaceObjects = new List<SpaceObjectBindingHelper>();
                var selectedSos = from so in value
                                  where (so.Metadata.Type == spaceObjectTypeName)
                                  select new SpaceObjectBindingHelper(so);
               
                foreach (var so in selectedSos)
                {
                    ScaleTransform scaleTrasform = new ScaleTransform();
                    SpaceObject shape = so.SpaceObject;
                    if (shape.Parent == null)
                    {
                        shape.Loaded += delegate
                        {
                            scaleTrasform.ScaleX = scaleTrasform.ScaleY = Math.Min(40.00 / shape.Width, 30.00 / shape.Height);
                            shape.RenderTransform = scaleTrasform;
                            ToolTipService.SetToolTip(shape, so.Name);

                            // Hack necessary becaues the SL XAML parser keeps
                            // crashing otherwise.
                            FindParent<Button>(shape).Click += ItemButtonClicked;
                        };
                        spaceObjects.Add(so);
                    }
                }
               (scrollViewer.Content as ItemsControl).ItemsSource = spaceObjects;
            }
        }

        public SpaceObjectToolBox()
        {
            InitializeComponent();
        }

        T FindParent<T>(DependencyObject e)
        {
            if (e is T)
                return (T)(object)e;

            return FindParent<T>(((FrameworkElement)e).Parent);
        }

        public void ItemButtonClicked(object sender, RoutedEventArgs e)
        {
            var helper = (SpaceObjectBindingHelper)((Button)sender).DataContext;
            var lifetimeContext = helper.Creator.CreateExport();

            lifetimeContext.Value.RemoveFromPlanningSurfaceRequested += delegate
            {
                SurfaceItems.Remove(lifetimeContext.Value);
                lifetimeContext.Dispose();
            };

            SurfaceItems.Add(lifetimeContext.Value);
        }
    }

    [ExportSpaceObjectToolbox(ToolboxType.Furniture)]
    public class FurnitureToolbox : SpaceObjectToolBox
    {
        public FurnitureToolbox()
            : base("Furniture") { }
    }

    [ExportSpaceObjectToolbox(ToolboxType.Plan)]
    public class HouseToolbox : SpaceObjectToolBox
    {
        public HouseToolbox()
            : base("Plan") { }
    }
}
