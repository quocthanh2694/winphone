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
    public partial class Page2 : PhoneApplicationPage
    {
        int score, diemcaonhat1,diemcaonhat2,pageso;
        public Page2()
        {
            InitializeComponent();
            score = (App.Current as App).score;
            pageso = (App.Current as App).pageso;
            diem.Text = score.ToString();
            if(pageso==1)
            {
                if (score > (App.Current as App).diemcaonhat1)
                {
                    diemcaonhat1 = score;
                    bestscore.Text = diemcaonhat1.ToString();
                    (App.Current as App).diemcaonhat1 = diemcaonhat1;
                }
                else
                {
                    bestscore.Text = (App.Current as App).diemcaonhat1.ToString();
                }
            }
            else
            { 
                if (score > (App.Current as App).diemcaonhat2)
                {
                    diemcaonhat2 = score;
                    bestscore.Text = diemcaonhat2.ToString();
                    (App.Current as App).diemcaonhat2 = diemcaonhat2;
                }
                else
                {
                    bestscore.Text = (App.Current as App).diemcaonhat2.ToString();
                }
            }
            
        }
        private void tieptuc_Click(object sender, RoutedEventArgs e)
        {
            if(pageso == 1)
            {
                Uri newPage = new Uri("/Main1Number.xaml", UriKind.Relative);
                NavigationService.Navigate(newPage);
            }
            else if (pageso == 2)
            {
                Uri newPage = new Uri("/Main2Number.xaml", UriKind.Relative);
                NavigationService.Navigate(newPage);
            }
        }

        private void quaylaimenu_Click(object sender, RoutedEventArgs e)
        {
            Uri newPage = new Uri("/Page1.xaml", UriKind.Relative);
            NavigationService.Navigate(newPage);
        }
    }
}