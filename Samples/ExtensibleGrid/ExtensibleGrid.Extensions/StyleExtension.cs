using System;
using System.Windows.Controls;
using ExtensibleGrid.GridLibrary.GridLibrary;
using System.Windows.Controls.Theming;

namespace GridExtensions
{

    [ExportGridExtension("Style Extension", "Applies a nice style to the grid")]
    public class StyleExtension : IGridExtension
    {
        private DataGrid _grid;

        public void Initialize(DataGrid grid)
        {
            _grid = grid;
            ImplicitStyleManager.SetResourceDictionaryUri(_grid, new Uri("ExtensibleGrid.Extensions;component/Theme.xaml", UriKind.Relative));
            ImplicitStyleManager.SetApplyMode(grid, ImplicitStylesApplyMode.Auto);
            ImplicitStyleManager.Apply(_grid);
        }
    }
}