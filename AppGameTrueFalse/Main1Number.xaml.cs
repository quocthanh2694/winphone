using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media.Animation;
using System.Threading;
using System.Windows.Threading;
//using Windows.UI.Xaml.Navigation;


namespace AppGameTrueFalse
{
    public partial class MainPlus1Number : PhoneApplicationPage
    {
        Random r;
        bool gtdung;
        int so1=0, so2=0, kq=0,kqdc=0,kqdt=0,sorandtr2=0,sorandsau2=0,score,pageso=0;
        private DispatcherTimer dispatcherTimer;
        // Constructor
        int demTG=0,i=0;
        int thoiGianbanDau = 150;
        int thoiGianTruDi1Lan = 5;
        int thoiGianCoDinh = 35;
        int thoiGianTickMilisecond = 35;

        public int SoSanh2So(int a,int b)
        {
            if(a > b)
            {
                return a;
            }
            else if (a==b)
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
            so1 = r.Next(1,9);
            so2 = r.Next(1, 9);
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
        private void ProgressBar()
        {
            //var storyboard = new Storyboard();

            //var animation = new DoubleAnimation { Duration = TimeSpan.FromSeconds(2), From = 100, To = 0, EnableDependentAnimation = true };

            //Storyboard.SetTarget(animation, this.progressBar);
            //Storyboard.SetTargetProperty(animation, "Value");

            //storyboard.Children.Add(animation); 

            //storyboard.Begin();

            //progressBar.Value = 100;
            //progressBar.Maximum = 100;
            //for (int i = 100; i > 0; i--)
            //{
            //    progressBar.Value--;
            //   // Thread.Sleep(100);

            //}


        }




       
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            progressBar.Value = demTG;
            //do whatever you want to do here
            time.Text = "Time: " + demTG;
            demTG = demTG - 1;
            //Thread.Sleep(10);
            if (demTG == 0)
            {
                GameOver();
            }


        }
        public void TimerTick()
        {
            dispatcherTimer.Stop();
           


            dispatcherTimer.Start();
        }
        public MainPlus1Number()
        {
            InitializeComponent();

            demTG = thoiGianbanDau;

            progressBar.Maximum = demTG;
            progressBar.Value = demTG;

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, thoiGianTickMilisecond);

            TimerTick();

            amthanh.Source = new Uri("/Assets/nhacspectre.mp3", UriKind.RelativeOrAbsolute);
            pageso = 1;
            amthanh.Play();
            Kiemtra();
        }
        void GameOver()
        {
            dispatcherTimer.Stop();

            Uri newPage = new Uri("/Page2.xaml", UriKind.Relative);
            NavigationService.Navigate(newPage);
            (App.Current as App).score = score;
            (App.Current as App).pageso = pageso;
        }
        void SetTime()
        {
            
                demTG = thoiGianbanDau - i;
            if (demTG < thoiGianCoDinh)
                demTG = thoiGianCoDinh;
            progressBar.Maximum = demTG;
            i+=thoiGianTruDi1Lan;
            TimerTick();
        }
        private void dung_Click(object sender, RoutedEventArgs e)
        {

            SetTime();
            if (gtdung == true)
            {
                score = score +1;
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
            ProgressBar();
        }

        private void sai_Click(object sender, RoutedEventArgs e)
        {
            SetTime();

            if (gtdung == false)
            {
                score = score + 1; 
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