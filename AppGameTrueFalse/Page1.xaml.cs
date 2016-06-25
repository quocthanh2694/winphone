using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Windows.Storage;
using System.Threading.Tasks;
using System.IO;

namespace AppGameTrueFalse
{
    public partial class Page1 : PhoneApplicationPage
    {
        public void writetotextfile()
        {
            //Set the path of the file
            String pathoffile =  "Diem1.txt";

            //Content of file
            String Content = "123";
            //if(!File.Exists(pathoffile))
            using (StreamWriter writer = new StreamWriter(pathoffile))
            {
                writer.Write(Content);
            }
        }
        public Page1()
        {
            InitializeComponent();
           // writetotextfile();
        }
        //private async void btnRead_Click()
        //{
        //    await WriteToFile("15", "Diem1.txt");
        //}
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

        private void help_Click(object sender, RoutedEventArgs e)
        {
            Uri newPage = new Uri("/Help.xaml", UriKind.Relative);
            NavigationService.Navigate(newPage);
        }

        private void quit_Click(object sender, RoutedEventArgs e)
        {
           
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                MessageBoxResult mbr = MessageBox.Show("Are you sure you want to exit game?", "Warning", MessageBoxButton.OKCancel);

                if (mbr == MessageBoxResult.OK)
                {
                    Application.Current.Terminate();
                }
                else
                {
                }
            });
            

        }
        
    }
}