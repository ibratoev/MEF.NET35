using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using ExtensibleGrid.GridLibrary.GridLibrary;
using System.Xml.Linq;
using System.Windows.Resources;
using System.Windows.Controls.Theming;
using System.Globalization;
using System.Windows.Markup;
using System.IO;

namespace ExtensibleGrid.GridLibrary.GridExtensions
{
    [ExportGridExtension("AutoComplete Extension", "Add Autocompletion to the FirstName Grid Cell")]
    public class AutoCompleteExtension : IGridExtension
    {

        private DataGrid _grid;
        public void Initialize(DataGrid grid)
        {
            _grid = grid;
            ResourceDictionary dictionary = Parse(new Uri("ExtensibleGrid.Extensions;component/AutoCompleteExtension.xaml", UriKind.Relative));
            //loading the resource dictionary
            DataGridColumn item = null;

            int index = 0;
            foreach (DataGridColumn col in _grid.Columns)
            {

                // turn every column of type string to an autocomplete
                if (col.Header.Equals("FirstName") || col.Header.Equals("First Name"))
                {

                    DataGridTemplateColumn templateColumn = new DataGridTemplateColumn();
                    templateColumn.Header = col.Header;
                    templateColumn.CellEditingTemplate = dictionary["myCellEditingTemplateFirstName"] as DataTemplate;
                    _grid.Columns.Insert(index, templateColumn);
                    item = col;
                    break;

                }
                
                index++;
            }
            _grid.Columns.Remove(item);

        }
        
        /// <summary>
        /// Retrieves a style collection from a uri of a resource
        /// dictionary.
        /// </summary>
        /// <param name="uri">The uri of a resource dictionary.</param>
        /// <returns>A style collection containing the styles in the resource
        /// dictionary.</returns>
        private static ResourceDictionary Parse(Uri uri)
        {

            StreamResourceInfo info = Application.GetResourceStream(uri);
            if (info == null)
            {
                throw new ResourceNotFoundException();
            }
            else
            {
                try
                {
                    return ResourceParser.Parse(info.Stream, true);
                }
                catch (Exception)
                {
                    throw new InvalidResourceException();
                }
            }
        }


    }
}
