using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;

namespace AppGameTrueFalse
{
    public partial class Page2 : PhoneApplicationPage
    {
        int score, diemcaonhat1,diemcaonhat2,pageso;
       // string textRead = "";
        public Page2()
        {
            InitializeComponent();
           // string diem1=readfromtextfile("Diem1.txt");
           

            score = (App.Current as App).score;
            pageso = (App.Current as App).pageso;
            diem.Text = score.ToString();
            if (pageso == 1)
            {
                int diemcaonhat = (App.Current as App).diemcaonhat1;
                

                if (score > diemcaonhat)
                {
                    diemcaonhat1 = score;
                    bestscore.Text = diemcaonhat1.ToString();
                    (App.Current as App).diemcaonhat1 = diemcaonhat1;
                }
                else
                {
                    bestscore.Text = (App.Current as App).diemcaonhat1.ToString();
                }
                //if (Convert.ToInt16(diem1) > Convert.ToInt16(bestscore.Text))
                //{
                //    bestscore.Text = diem1;

                //}
                //writetotextfile("Diem1.txt", bestscore.Text);


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
        //public void writetotextfile(string fileName,string text)
        //{
        //    //Set the path of the file
        //    string pathoffile = fileName;

        //    //Content of file
        //    string Content = text;
        //    if (!File.Exists(pathoffile))
        //        using (StreamWriter writer = new StreamWriter(pathoffile))
        //        {
        //            writer.Write(Content);
        //        }
        //}
        //public string readfromtextfile(string fileName)
        //{
        //    //Set the path of the file
        //    string pathoffile = fileName;

        //    //Content of file
        //    string Content = "";

        //    using (System.IO.StreamReader reader = new StreamReader(pathoffile))
        //    {
        //        Content = reader.ReadToEnd();
        //    }

        //    return Content;
        //}

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