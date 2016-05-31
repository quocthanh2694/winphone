using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using AppGameTrueFalse.Resources;
using System.Windows.Media.Animation;

namespace AppGameTrueFalse
{
    public partial class MainPage : PhoneApplicationPage
    { 
        Random r;
        bool gtdung;
        int so1 = 0, so2 = 0, kq = 0, kqdc = 0, kqdt = 0, score, sorandtr2 = 0, sorandsau2 = 0, pageso = 0;
        public int SoSanh2So(int a, int b)
        {
            if (a > b)
            {
                return a;
            }
            else if (a == b)
            {
                return 1;
            }
            else
            {
                return b;
            }
        }
        public void Kiemtra()
        {
            r = new Random();
            so1 = r.Next(1,30);
            so2 = r.Next(1,30);
            kqdc = so1 + so2;
            kqdt = so1 - so2;

            if (r.Next(0, 9) % 2 == 0)
            {
                lbdau.Text = "-";
            }
            else
            {
                lbdau.Text = "+";
            }
            if (lbdau.Text == "+")
            {                
                sorandtr2 = kqdc - 2;                
                sorandsau2 = kqdc + 2;
                if (r.Next(0, 9) % 2 == 0)
                {
                    kq = r.Next(sorandtr2, sorandsau2);
                }  
                else
                {
                    kq = kqdc;
                }            
            }
            else if (lbdau.Text == "-")
            {
                sorandtr2 = kqdt - 2;              
                sorandsau2 = kqdt + 2;
                if (r.Next(0, 9) % 2 == 0)
                {
                    kq = r.Next(sorandtr2, sorandsau2);
                }
                else
                {
                    kq = kqdt;
                }
            }

            lb_so1.Text = so1.ToString();
            lb_so2.Text = so2.ToString();
            lb_kq.Text = kq.ToString();

            if (lbdau.Text == "+")
            {
                if (kqdc == kq)
                {
                    gtdung = true;
                }
                else
                {
                    gtdung = false;
                }
            }
            if (lbdau.Text == "-")
            {
                if (kqdt == kq)
                {
                    gtdung = true;
                }
                else
                {
                    gtdung = false;
                }
            }
        }
        public void ProgressBar()
        {
            //var storyboard = new Storyboard();

            //var animation = new DoubleAnimation { Duration = TimeSpan.FromSeconds(2), From = 100, To = 0, EnableDependentAnimation = true };

            //Storyboard.SetTarget(animation, this.progressBar);
            //Storyboard.SetTargetProperty(animation, "Value");

            //storyboard.Children.Add(animation);

            //storyboard.Begin();
        }
        public MainPage()
        {
            InitializeComponent();
            amthanh.Source = new Uri("/Assets/nhacspectre.mp3", UriKind.RelativeOrAbsolute);
            amthanh.Play();
            pageso = 2;
            ProgressBar();
            Kiemtra();
        }

        private void dung_Click(object sender, RoutedEventArgs e)
        {
            ProgressBar();
            if (gtdung == true)
            {
                score++;
                diem.Text = "score: " + score.ToString();

                //amthanhclick.Source = new Uri("/Assets/beepclick.mp3", UriKind.RelativeOrAbsolute);
                //amthanhclick.Play();
                amthanh.Play();
                Kiemtra();
            }

            else
            {
                Uri newPage = new Uri("/Page2.xaml", UriKind.Relative);
                NavigationService.Navigate(newPage);
                (App.Current as App).score = score;
                (App.Current as App).pageso = pageso;
            }
        }

        private void sai_Click(object sender, RoutedEventArgs e)
        {
            ProgressBar();
            if (gtdung == false)
            {
                score++;
                diem.Text = "score: " + score.ToString();

                //amthanhclick.Source = new Uri("/Assets/beepclick.mp3", UriKind.RelativeOrAbsolute);
                //amthanhclick.Play();
                amthanh.Play();
                Kiemtra();
            }
            else
            {
                Uri newPage = new Uri("/Page2.xaml", UriKind.Relative);
                NavigationService.Navigate(newPage);
                (App.Current as App).score = score;
                (App.Current as App).pageso = pageso;
            }
        }
    }
}