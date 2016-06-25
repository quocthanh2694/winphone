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
using System.Windows.Threading;

namespace AppGameTrueFalse
{
    public partial class MainPage : PhoneApplicationPage
    {   
        Random r;
        bool gtdung;  
        int so1 = 0, so2 = 0, kq = 0, kqdc = 0, kqdt = 0, score, sorandtr2 = 0, sorandsau2 = 0, pageso = 0;
        private DispatcherTimer dispatcherTimer;
        // Constructor
        int demTG = 0, dem = 0;
        int thoiGianbanDau = 250;
        int thoiGianTruDi1Lan = 10;
        int thoiGianCoDinh = 100;
        int thoiGianTickMilisecond = 10;
        int thoiGianGiamSauSoLan = 10;
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

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            progressBar.Value = demTG;
            //do whatever you want to do here
           
            time.Text = "Time: " + (float)demTG / 100;
            demTG = demTG - 1;
            //Thread.Sleep(10);
            if (demTG <= 0)
            {
                GameOver();
            }


        }
        public void TimerTick()
        {
            dispatcherTimer.Stop();



            dispatcherTimer.Start();
        }
        void SetTime()
        {


            dem++;
            demTG = thoiGianbanDau - (dem / thoiGianGiamSauSoLan) * thoiGianTruDi1Lan;
            
            progressBar.Maximum = demTG;
            if (demTG < thoiGianCoDinh)
                demTG = thoiGianCoDinh;
            
            TimerTick();

        }

        public MainPage()
        {
           
            InitializeComponent();
            amthanh.Source = new Uri("/Assets/nhacspectre.mp3", UriKind.RelativeOrAbsolute);
            amthanh.Play();

            demTG = thoiGianbanDau;

            progressBar.Maximum = demTG;
            progressBar.Value = demTG;

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, thoiGianTickMilisecond);

            TimerTick();



            pageso = 2;
            Kiemtra();
        }

        private void dung_Click(object sender, RoutedEventArgs e)
        {
            SetTime();
            if (gtdung == true)
            {
                score++;
                diem.Text = "Score: " + score.ToString();

                //amthanhclick.Source = new Uri("/Assets/beepclick.mp3", UriKind.RelativeOrAbsolute);
                //amthanhclick.Play();
                amthanh.Play();
                Kiemtra();
            }

            else
            {
                GameOver();
            }
        }

        private void GameOver()
        {
            dispatcherTimer.Stop();
            Uri newPage = new Uri("/GameOver.xaml", UriKind.Relative);
            NavigationService.Navigate(newPage);
            (App.Current as App).score = score;
            (App.Current as App).pageso = pageso;
            
        }

        private void sai_Click(object sender, RoutedEventArgs e)
        {
            SetTime();
            if (gtdung == false)
            {
                score++;
                diem.Text = "Score: " + score.ToString();

                //amthanhclick.Source = new Uri("/Assets/beepclick.mp3", UriKind.RelativeOrAbsolute);
                //amthanhclick.Play();
                amthanh.Play();
                Kiemtra();
            }
            else
            {
                GameOver();
            }
        }
    }
}