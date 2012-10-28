//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace HouseSpacePlanner
{
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Windows.Controls;

    public partial class ErrorWindow : UserControl
    {
        public ErrorWindow(IEnumerable<CompositionError> issues)
        {
            InitializeComponent();
            listBox.ItemsSource = issues;
        }
    }
}
