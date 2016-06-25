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
using System.Windows.Media;

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
        double percent = 100; // >% thời gian
        double per = 1;
        int thoigiantam = 0;// Tách thời gian khi người dùng click
        int demTG=0,dem=0,mang,level=1;
        int thoiGianbanDau = 150;
        int thoiGianTruDi1Lan = 10;
        int thoiGianCoDinh = 70;
        int thoiGianTickMilisecond = 10;
        int thoiGianGiamSauSoLan = 5;// thời gian giảm tổng giờ sau (số) lần click đúng

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

            time.Text = "Time: " + (float)demTG/100;
            demTG = demTG - 1;
            //Thread.Sleep(10);
            if (demTG == 0)
            {
                SetTime();
                GameOver();
                
            }
            if (demTG < percent)
            {
                progressBar.Foreground = new SolidColorBrush(Color.FromArgb(255, 225, 9,17));
                
            }
            else
            {
                progressBar.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));

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
            amthanh.Source = new Uri("/Assets/nhacspectre.mp3", UriKind.RelativeOrAbsolute);
            amthanh.Play();
            demTG = thoiGianbanDau;

            progressBar.Maximum = demTG;
            progressBar.Value = demTG;

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, thoiGianTickMilisecond);

            TimerTick();

            mang = (App.Current as App).mang;
            mangtxt.Text = "Life: " + mang.ToString();
            tongtgtxt.Text = thoiGianbanDau.ToString();
            per = (App.Current as App).perc;
            percent = thoiGianbanDau * per;

            pageso = 1;
            
            Kiemtra();
        }
        void GameOver()
        {
            mang--;
            if (mang <1)
            {
                dispatcherTimer.Stop();

                Uri newPage = new Uri("/GameOver.xaml", UriKind.Relative);
                NavigationService.Navigate(newPage);
                (App.Current as App).score = score;
                (App.Current as App).pageso = pageso;
            }
            else
            {
                mangtxt.Text = "Life: " + mang.ToString();
                Kiemtra();
            }
        }

        void SetTime()
        {


            // Set level
            if (dem % thoiGianGiamSauSoLan == 0)
            {
                level++;
                leveltxt.Text = "Level: " + level.ToString();
            }

            // Set thời gian tạm để cộng mạng
           
            // Set đếm thời gian
                demTG = thoiGianbanDau - (dem / thoiGianGiamSauSoLan) * thoiGianTruDi1Lan;
           
            progressBar.Maximum = demTG;
            if (demTG < thoiGianCoDinh)
                demTG = thoiGianCoDinh;

            tongtgtxt.Text = demTG.ToString();
            // Set % cộng mạng
            percent = demTG*per;

            TimerTick();


            ////them am thanh choi 
            //amthanhclick.Source = new Uri("/Assets/beepclick.mp3", UriKind.Absolute);
            //amthanhclick.Play();

            //amthanh.Play();

        }
        void CongMang()
        {
            if (demTG >= percent)
            {
                mang++;
                mangtxt.Text = "Life: " + mang.ToString();
            }
        }
        private void dung_Click(object sender, RoutedEventArgs e)
        {
            

            if (gtdung == true)
            {
                CongMang();
                dem++;
                SetTime();

                
                
                score = score +1;
                diem.Text = "Score: " + score.ToString();

                //amthanhclick.Source = new Uri("/Assets/beepclick.mp3", UriKind.RelativeOrAbsolute);
                //amthanhclick.Play();
                amthanh.Play();
                Kiemtra();
            }           
            else
            {
                SetTime();
                GameOver();
            }
            
            //    ProgressBar();
        }

        private void sai_Click(object sender, RoutedEventArgs e)
        {
            if (gtdung == false)
            {
                CongMang();
                dem++;
                SetTime();


                score = score + 1; 
                diem.Text = "Score: " + score.ToString();

                //amthanhclick.Source = new Uri("/Assets/beepclick.mp3", UriKind.RelativeOrAbsolute);
                //amthanhclick.Play(); 
                amthanh.Play();        
                Kiemtra();
            }
            else
            {
                SetTime();
                GameOver();
            }
            
        }
        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            //Do your work here
            dispatcherTimer.Stop();
            base.OnBackKeyPress(e);
        }
    }
}