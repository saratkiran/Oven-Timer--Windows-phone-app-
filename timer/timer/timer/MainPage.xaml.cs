using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Windows.Interactivity;
using Microsoft.Expression.Interactivity;
using Microsoft.Xna.Framework.Audio;
using System.Windows.Threading;
using Microsoft.Xna.Framework;

namespace timer
{
    public partial class MainPage : PhoneApplicationPage
    {
          private DispatcherTimer timer;
        DateTime nowtime;
        int l = 0, s = 0,t;
        public MainPage()
        {
            InitializeComponent();

        }

        private void OnTick(object sender, EventArgs e)
        {
            if (t == 2)
            {
                return;
             }
            else
            {
                var midnight = nowtime;
                var timeLeft = midnight - DateTime.Now;


                if (timeLeft.Hours >= 00 && timeLeft.Minutes >= 00 && timeLeft.Seconds >= 00)
                {
                    Countdown.Text = String.Format("{0:D2}:{1:D2}:{2:D2}", timeLeft.Hours, timeLeft.Minutes, timeLeft.Seconds);
                }
                else
                {
                    Countdown.Text = "Done";
                    songplay();
                }
            }



        }

        private void songplay()
        {
            if (l != 3)
            {
                SoundEffectInstance seiCircus;

                using (var stream = TitleContainer.OpenStream("123.wmv"))
                {
                    var effect = SoundEffect.FromStream(stream);
                    //create the instance
                    seiCircus = effect.CreateInstance();

                    FrameworkDispatcher.Update();
                    //play sound via the instance
                    seiCircus.Play();
                }
                l++;
            }

        }

        private void start_Click(object sender, RoutedEventArgs e)
        {

            if (sec.Text == "")
            {
                sec.Text = "00";
               
            }
          if (hrs.Text == "")
                            hrs.Text = "00";
          if (mins.Text == "")
              mins.Text = "00";
            
                Double mints = Double.Parse(mins.Text);
                Double hrts = Double.Parse(hrs.Text);
                Double sect = Double.Parse(sec.Text);


                if (mints == 00 && hrts == 00 && sect == 00)
                {
                    MessageBox.Show("Enter the countdown");

                }

                timer = new DispatcherTimer
                {
                    Interval = TimeSpan.FromSeconds(1)
                };
                nowtime = DateTime.Now.AddHours(hrts).AddMinutes(mints).AddSeconds(sect);

                timer.Tick += OnTick;


                timer.Start();
                s = 1;


                t = 1;

           

        }
        private void stop_Click(object sender, RoutedEventArgs e)
        {
            if (s == 1)
            {
                t = 2;
                        
            }
            else
            {
                MessageBox.Show("Start to stop");
            }

        }




        private void reset_Click(object sender, RoutedEventArgs e)
        {
            int l = 00;
            hrs.Text = l.ToString();
            mins.Text = l.ToString();
            sec.Text = l.ToString();

        }

        private void tips_Click(object sender, RoutedEventArgs e)
        {

        }
     

        private void MaskNumericInput(TextBox textBoxControl, bool allowDecimals)
        {
            string[] invalidChars = { "*", "#", ",", ".", "(", ")", "x", "-", "+", " ", "@" };

            if (!allowDecimals)
            {
                invalidChars[invalidChars.Length - 1] = ".";
            }

            foreach (string s in invalidChars)
            {
                textBoxControl.Text = textBoxControl.Text.Replace(s, "");
            }



            textBoxControl.SelectionStart = textBoxControl.Text.Length;
        }


        private void hrs_KeyUp(object sender, KeyEventArgs e)
        {
            MaskNumericInput((TextBox)sender, false);
        }

       
    }
}