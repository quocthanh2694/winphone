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
    public partial class Page1 : PhoneApplicationPage
    {
        
        public Page1()
        {
            InitializeComponent();
        }

        private void plus2number_Click(object sender, RoutedEventArgs e)
        {
            Uri newPage = new Uri("/Main2Number.xaml", UriKind.Relative);
            NavigationService.Navigate(newPage);
        }

        private void plus1number_Click(object sender, RoutedEventArgs e)
        {
            Uri newPage = new Uri("/Main1Number.xaml", UriKind.Relative);
            NavigationService.Navigate(newPage);
        }

        private void option_Click(object sender, RoutedEventArgs e)
        {
            Uri newPage = new Uri("/OptionPage.xaml", UriKind.Relative);
            NavigationService.Navigate(newPage);
        }
    }
}