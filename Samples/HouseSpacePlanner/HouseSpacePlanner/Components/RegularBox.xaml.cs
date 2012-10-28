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

namespace HouseSpacePlanner.Components
{
    [SpaceObject("Furniture", "Regular Box")]
    public partial class RegularBox : SpaceObject
    {
        public RegularBox()
            : base(5, 5)
        {
            InitializeComponent();
        }
    }
}
