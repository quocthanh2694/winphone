using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Windows.Phone.UI.Input;

namespace AppGameTrueFalse
{
    public partial class Help : PhoneApplicationPage
    {
        public Help()
        {
            InitializeComponent();
        }

        private void textBox_Copy1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        void GoBack()

        {

            if (this.NavigationService.CanGoBack)

            {

                this.NavigationService.GoBack();

            }

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            GoBack();
        }
    }
}