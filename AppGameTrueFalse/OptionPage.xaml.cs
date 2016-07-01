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
        int chon;
        string s = "Value of add life: ";
        public OptionPage()
        {
            InitializeComponent();
            double pe = (App.Current as App).perc;
            if (pe == 1)
            {
                
                slider2.Value = 1;
            }
            else
                if (pe == 0.8)
            {
                slider2.Value = 30;
            }
            else
                if (pe == 0.7)
            {
                slider2.Value = 50;
            }
            else
                if (pe ==0.6)
            {
                slider2.Value = 70;
            }
            else
                if (pe == 0.5)
            {
                slider2.Value = 100;
            }

        }

        private void slider2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                
                if (slider2.Value <20)
                {
                    percenttxt.Text = s+"0%";
                    (App.Current as App).perc = 1;
                }
                else
                    if (slider2.Value >=20 && slider2.Value<40)
                {
                    percenttxt.Text = s+"20%";
                    (App.Current as App).perc = 0.8;

                }
                else
                     if (slider2.Value >= 40 && slider2.Value < 60)
                {
                    percenttxt.Text = s+"30%";
                    (App.Current as App).perc = 0.7;
                }
                else
                     if (slider2.Value >=60 && slider2.Value < 80)
                {
                    percenttxt.Text = s +"40%";
                    (App.Current as App).perc = 0.6;
                }
                else
                     if (slider2.Value >= 80)
                {
                    percenttxt.Text = s + "50%";
                    (App.Current as App).perc = 0.5;
                }
            }
            catch { }

        }
        private void toastToggle_Checked(object sender, RoutedEventArgs e)
        {
            tgw.Content = "Hard";
            chon = 2;
        }

        private void toastToggle_Unchecked(object sender, RoutedEventArgs e)
        {
            tgw.Content = "Easy";
            chon = 1;
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            Uri newPage = new Uri("/Page1.xaml", UriKind.Relative);
            NavigationService.Navigate(newPage);
            (App.Current as App).chon = chon;
        }
    }
}