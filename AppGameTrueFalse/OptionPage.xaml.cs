using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace AppGameTrueFalse
{
    public partial class OptionPage : PhoneApplicationPage
    {
        float soslider;
        public OptionPage()
        {
            InitializeComponent();
        }

        private void slider2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
    }
}