using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SNS.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SNS.Anim;
using System.Timers;
using Xamarin.Essentials;

namespace SNS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Configuration_AdressePage : ContentPage
    {
        Configuration_AdressePageViewModel myConfiguration_AdressePageViewModel;

        // ---------------- TIMER ---------------------
        private static System.Timers.Timer aTimer;
        // ----------------------- Pair -------------------
        bool pair;

        const int anim_speed = 100;

        public Configuration_AdressePage()
        {
            pair = true;

            InitializeComponent();

            BindingContext = myConfiguration_AdressePageViewModel = new Configuration_AdressePageViewModel();


            //--------------- Timer_Anim --------------------
            aTimer = new System.Timers.Timer(500);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;

        }


        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            if (Preferences.Get("Network_State", false))
            {
                Anim_to_Check(F_Bar_1, F_Bar_2);
            }
            else
            {
                Anim_to_Croix(F_Bar_1, F_Bar_2);
            }


            if (Preferences.Get("API_State", false))
            {
                Anim_to_Check(F_Bar_API_1, F_Bar_API_2);
            }
            else
            {
                Anim_to_Croix(F_Bar_API_1, F_Bar_API_2);
            }

            if (Preferences.Get("BDD_State", false))
            {
                Anim_to_Check(F_Bar_BDD_1, F_Bar_BDD_2);
            }
            else
            {
                Anim_to_Croix(F_Bar_BDD_1, F_Bar_BDD_2);
            }

        }

        void Anim_to_Check(Frame F_Bar_1, Frame F_Bar_2)
        {
            F_Bar_2.HeightTo(15, anim_speed, Easing.CubicOut);
            F_Bar_2.TranslateTo(-5, 1, anim_speed, Easing.CubicOut);
            F_Bar_1.TranslateTo(5, -1, anim_speed, Easing.CubicOut);
            F_Bar_1.BackgroundColor = Color.FromHex("B2FFC8");
            F_Bar_2.BackgroundColor = Color.FromHex("B2FFC8");

        }


        void Anim_to_Croix(Frame F_Bar_1, Frame F_Bar_2)
        {
            F_Bar_2.HeightTo(20, anim_speed, Easing.CubicOut);
            F_Bar_2.TranslateTo(0, 0, anim_speed, Easing.CubicOut);
            F_Bar_1.TranslateTo(0, 0, anim_speed, Easing.CubicOut);
            F_Bar_1.BackgroundColor = Color.FromHex("FF6666");
            F_Bar_2.BackgroundColor = Color.FromHex("FF6666");
        }


    }
}