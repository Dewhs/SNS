using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SNS.ViewModels;
using TouchTracking;
using System.Timers;
using SNS.Anim;

namespace SNS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomeViewModel myHomeViewModel;
        // ---------------- TIMER ---------------------
        private static System.Timers.Timer aTimer;

        //-------- Delay_Anim --------
        const int delay_anim = 100;//100ms de base


        double delta_X = 0;

        public HomePage()
        {
            InitializeComponent();
            BindingContext = myHomeViewModel = new HomeViewModel();

            //--------------- Timer_Anim --------------------
            aTimer = new System.Timers.Timer(delay_anim);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;

            
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Task.Run(() =>
            {
                Task.Delay(500);
                Anim_Frame();
            });
        }

        int Anim_Frame()
        {
            int sound = Int32.Parse(L_db.Text);

            Random rnd = new Random();

            double[] intervalle = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            int coeff_global = 3;
            if(sound != 0)
            {
                for (int y = 0; y < 10; y++)
                {

                    if (y < 3)
                    {
                        int Borne_inf = sound * ( 5 * y );
                        int Borne_sup = Borne_inf + 250;
                        intervalle[y] = rnd.Next(Borne_inf, Borne_sup);
                    }
                    else if (y >= 3 && y < 6)
                    {
                        int Borne_inf = 10 * (sound - 10 * y);
                        int Borne_sup = Borne_inf + 200;
                        intervalle[y] = rnd.Next(Borne_inf, Borne_sup);
                    }
                    else
                    {
                        int Borne_inf = 20 * sound - (2*y*y*y);
                        int Borne_sup = Borne_inf + 200;
                        intervalle[y] = rnd.Next(Borne_inf, Borne_sup);
                    }

                    if(intervalle[y] < 10)
                    {
                        intervalle[y] = 10;
                    }
                
                

                //Int32.Parse(Math.Round(20 - 1.5 * y).ToString()), Int32.Parse(Math.Round(30 -4.1*y).ToString())

                /* if (y < 4)
                 {
                     intervalle[y] = rnd.Next(coeff_global * sound / (50 - 10 * y), 2 * coeff_global * sound / (50 - 10 * y));
                 }
                 else if (y >= 4 && y < 7)
                 {
                     intervalle[y] = rnd.Next(coeff_global * sound / (10 + 8 * y), 2 * coeff_global * sound / (10 + 8 * y));
                 }
                 else
                 {
                     intervalle[y] = rnd.Next(coeff_global * sound / (10 * y - 55), 2 * coeff_global * sound / (10 * y - 55));
                 }*/


                }
            }

            //var Frame_son_1_anim = new Animation(v => Frame_son_1.ScaleYTo(Frame_son_1.Scale * intervalle[0] / 10, delay_anim));
            /*int Borne_inf = 10 + coeff_global * sound;
            int Borne_sup = Borne_inf + 10;
            intervalle[0] = rnd.Next(Borne_inf, Borne_sup);*/
            //double test = Frame_son_1.Height * intervalle[0]/5;

            /*Console.WriteLine("Int 0 : " + intervalle[0]);
            Console.WriteLine("Int 1 : " + intervalle[1]);
            Console.WriteLine("Int 2 : " + intervalle[2]);
            Console.WriteLine("Int 3 : " + intervalle[3]);
            Console.WriteLine("Int 4 : " + intervalle[4]);
            Console.WriteLine("Int 5 : " + intervalle[5]);
            Console.WriteLine("Int 6 : " + intervalle[6]);
            Console.WriteLine("Int 7 : " + intervalle[7]);
            Console.WriteLine("Int 8 : " + intervalle[8]);
            Console.WriteLine("Int 9 : " + intervalle[9]);*/
            //Console.WriteLine("Height F1 : " + Frame_son_1.Height);
            //Console.WriteLine("Test F1 : " + test);
            
            
            var Frame_son_1_anim = new Animation(v => Frame_son_1.HeightTo(10 + intervalle[0]/10, delay_anim));
            var Frame_son_2_anim = new Animation(v => Frame_son_2.HeightTo(10 + intervalle[1]/10, delay_anim));
            var Frame_son_3_anim = new Animation(v => Frame_son_3.HeightTo(10 + intervalle[2]/10, delay_anim));
            var Frame_son_4_anim = new Animation(v => Frame_son_4.HeightTo(10 + intervalle[3]/10, delay_anim));
            var Frame_son_5_anim = new Animation(v => Frame_son_5.HeightTo(10 + intervalle[4]/10, delay_anim));
            var Frame_son_6_anim = new Animation(v => Frame_son_6.HeightTo(10 + intervalle[5]/10, delay_anim));
            var Frame_son_7_anim = new Animation(v => Frame_son_7.HeightTo(10 + intervalle[6]/10, delay_anim));
            var Frame_son_8_anim = new Animation(v => Frame_son_8.HeightTo(10 + intervalle[7]/10, delay_anim));
            var Frame_son_9_anim = new Animation(v => Frame_son_9.HeightTo(10 + intervalle[8]/10, delay_anim));
            var Frame_son_10_anim = new Animation(v => Frame_son_10.HeightTo(10 + intervalle[9]/10, delay_anim));

            var Sound_Anim = new Animation
                {
                    { 0, 1, Frame_son_1_anim },
                    { 0, 1, Frame_son_2_anim },
                    { 0, 1, Frame_son_3_anim },
                    { 0, 1, Frame_son_4_anim },
                    { 0, 1, Frame_son_5_anim },
                    { 0, 1, Frame_son_6_anim },
                    { 0, 1, Frame_son_7_anim },
                    { 0, 1, Frame_son_8_anim },
                    { 0, 1, Frame_son_9_anim },
                    { 0, 1, Frame_son_10_anim }
                };
            Sound_Anim.Commit(this, "myAnim", 1, 0, Easing.Linear);

            return 0;
        }

      


        private void OnTouch_Grid_Menu(object sender, TouchActionEventArgs args)
        {
            // ------------ Position : X, Y ----------------

         double F_Historique_Xposition = 0;
         double F_Reglage_Xposition = 0;
         double F_Settings_Xposition = 0;

            //ScrollView
            var point = args.Location; //Point location

            

            if(delta_X != 0)
            {

                F_Historique_Xposition += point.X - delta_X;
                F_Reglage_Xposition += point.X - delta_X;
                F_Settings_Xposition += point.X - delta_X;
                //Console.WriteLine(View_Focus.IsFocused);
                Frame_nav_historique.TranslationX = F_Historique_Xposition - Frame_nav_historique.Width / 2;
                Frame_nav_reglage.TranslationX = F_Reglage_Xposition - Frame_nav_reglage.Width / 2;
                Frame_nav_settings.TranslationX = F_Settings_Xposition - Frame_nav_settings.Width / 2;
            }
            else
            {
                delta_X = point.X;
            }

           
            //Grid_Menu.Unfocus();

            


        }
        


        
        
        ~HomePage() { }

    }
}