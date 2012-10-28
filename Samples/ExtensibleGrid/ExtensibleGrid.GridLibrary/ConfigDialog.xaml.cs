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

namespace ExtensibleGrid.GridLibrary.GridLibrary
{
    public partial class ConfigDialog : ChildWindow
    {
        public ListBox ExtensionsList
        {
            get { return this.ListBox; }
        }
        public ConfigDialog()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void CheckBox_BindingValidationError(object sender, ValidationErrorEventArgs e)
        {

        }
    }
}

