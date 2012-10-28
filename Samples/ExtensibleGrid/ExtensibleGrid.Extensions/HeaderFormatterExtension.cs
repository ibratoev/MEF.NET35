using System;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using ExtensibleGrid.GridLibrary.GridLibrary;

namespace ExtensibleGrid.GridLibrary.GridExtensions
{
    [ExportGridExtension("Header Formatter Extension", "Adds spaces between pascal cased field names")]
    public class HeaderFormatterExtension : IGridExtension
    {
        private DataGrid _grid;

        public void Initialize(DataGrid grid)
        {
            _grid = grid;
            _grid.AutoGeneratingColumn += new EventHandler<DataGridAutoGeneratingColumnEventArgs>(_grid_AutoGeneratingColumn);

            foreach (DataGridColumn column in grid.Columns)
            {
                column.Header = FormatHeader((string) column.Header);
            }
        }

        void _grid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            e.Column.Header = FormatHeader(e.PropertyName);
        }

        string FormatHeader(string header)
        {
            string formattedHeader = "";

            for (int i = 0; i < header.Length;i++ )
            {
                char c = header[i];
                if (i > 0 && c >= 'A' && c <= 'Z')
                    formattedHeader += ' ';
                
                formattedHeader += c;
             
            }
            return formattedHeader;
        }
    }
}
