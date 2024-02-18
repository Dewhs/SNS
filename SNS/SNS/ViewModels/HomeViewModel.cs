using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;
using System.Timers;
using System.Windows.Input;
using Xamarin.Essentials;
using SNS.Models;
using SNS.Services;
using System.Threading.Tasks;
using System.IO;
namespace SNS.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public ICommand Click_nav_reglage { get; set; }
        public ICommand Click_nav_profile { get; set; }
        public ICommand Click_Configuration_Adresse { get; set; }

        // ---------------- TIMER ---------------------
        private static System.Timers.Timer Sound_Value_Timer;

        // ------------------ Sound -------------------
        public string Sound_Value { get; set; }
        public string Sound_Value_Description { get; set; }
        // ----------------- Color --------------------
        public Color Sound_Value_Description_Color { get; set; }
        public Color F_Sound_BG_Color { get; set; }
        // ----------------- Randomiser ---------------
        Random rnd = new Random();

        public ImageSource profile_img { get; set; }


        public string Name { get; set; }

        public string Widht_Nav_Reglage { get; set; }
        public string Margin_Nav_Reglage { get; set; }


        public HomeViewModel()
        {


            string status = Preferences.Get("status", "");
            if (status != "admin")
            {
                Widht_Nav_Reglage = "0";
                Margin_Nav_Reglage = "0";
            }
            else
            {
                Widht_Nav_Reglage = "115";
                Margin_Nav_Reglage = "2,0";
            }
            OnPropertyChanged("Nav_reglage_widht");
            OnPropertyChanged("Margin_Nav_Reglage");


            string img64 = Preferences.Get("image", "");
            profile_img = ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(img64)));

            Name = Preferences.Get("name", "");

            Sound_Value = "0";
            Sound_Value_Description = "Disconnected";
            Sound_Value_Description_Color = Color.FromHex("FF6666"); //Color App_Red
            F_Sound_BG_Color = Color.White;

            Sound_Value_Timer = new System.Timers.Timer(1000);
            // Hook up the Elapsed event for the timer. 
            Sound_Value_Timer.Elapsed += Change_Sound_Value_Declancher;
            Sound_Value_Timer.AutoReset = true;
            Sound_Value_Timer.Enabled = true;



            Click_nav_reglage = new Command(async () =>
            {
                // Sound_Value_Timer.Close();
                //await Task.Delay(TimeSpan.FromSeconds(2));
                await Shell.Current.GoToAsync("Reglage_PalierPage");

            });

            Click_nav_profile = new Command(async () =>
            {

                await Shell.Current.GoToAsync("ProfilePage");

            });

            Click_Configuration_Adresse = new Command(async () =>
            {
                await Shell.Current.GoToAsync("Configuration_AdressePage");
            });
        }

        private void Change_Sound_Value_Declancher(Object source, ElapsedEventArgs e)
        {
            change_sound_value();
        }


        void change_sound_value()
        {

            string Token = Preferences.Get("token", "");

            //Post du token pour la recuperation de valeur de son + descritpon + couleurs
            Task<API_Info> task_Load_API_info = MockDataStore.PostAsync_Sound_value(Token);
            

            if (task_Load_API_info.Status.ToString() != "RanToCompletion")
            {
                Sound_disconnected();
            }
            else
            {
                var API_info = task_Load_API_info.Result; //Recuperation des information de l'utilisateur


                if (API_info.valeur != null)
                {
                    Sound_Value_Description = API_info.alerte;
                    Sound_Value_Description_Color = Color.FromHex(API_info.couleur);
                    F_Sound_BG_Color = Color.FromHex(API_info.couleur);
                    Sound_Value = API_info.valeur;
                }
                else
                {
                    Sound_disconnected();
                }
            }



            //index_of_sound = rnd.Next(0, 5);
            /*int sound_Value = rnd.Next(0, 120);

            
            Sound_Value = sound_Value.ToString();

            if(sound_Value == 0)
            {
                Sound_Value_Description = "Deconnecter";
                Sound_Value_Description_Color = Color.FromHex("FF6666");
                F_Sound_BG_Color = Color.FromHex("FFFFFF");
            }
            else if (sound_Value < 61)
            {
                Sound_Value_Description = "Bien";
                Sound_Value_Description_Color = Color.FromHex("B2FFC8");
                F_Sound_BG_Color = Color.FromHex("B2FFC8");
            }

            else if (sound_Value >= 61 && sound_Value <= 80)
            {
                Sound_Value_Description = "Attention !";
                Sound_Value_Description_Color = Color.FromHex("FFDF8C");
                F_Sound_BG_Color = Color.FromHex("FFDF8C");

            }

            else if (sound_Value > 80)
            {
                Sound_Value_Description = "Trop Fort !!";
                Sound_Value_Description_Color = Color.FromHex("FF6666");
                F_Sound_BG_Color = Color.FromHex("FF6666");

            }*/

            //Refresh UI



            OnPropertyChanged("Sound_Value");
            OnPropertyChanged("Sound_Value_Description");
            OnPropertyChanged("Sound_Value_Description_Color");
            OnPropertyChanged("F_Sound_BG_Color");


        }


        int Sound_disconnected()
        {
            Sound_Value = "0";
            Sound_Value_Description = "Disconnected";
            Sound_Value_Description_Color = Color.FromHex("FF6666"); //Color App_Red
            F_Sound_BG_Color = Color.White;

            OnPropertyChanged("Sound_Value");
            OnPropertyChanged("Sound_Value_Description");
            OnPropertyChanged("Sound_Value_Description_Color");
            OnPropertyChanged("F_Sound_BG_Color");

            return 0;
        }

        /* //Refresh UI
          OnPropertyChanged("BG_BTN_Connect");
          OnPropertyChanged("Invalid_id_pass");*/
        ~HomeViewModel() { }
    }
}
