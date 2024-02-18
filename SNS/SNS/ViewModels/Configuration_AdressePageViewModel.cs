using System;
using System.Collections.Generic;
using System.Text;

using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Timers;
using SNS.Services;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
namespace SNS.ViewModels
{




    public class Configuration_AdressePageViewModel : BaseViewModel
    {
        public ICommand Click_Back { get; set; }

        public string uri_Reseau { get; set; }
        public string uri_API { get; set; }

        public string Corner_Radius_Bar_1 { get; set; }
        public string Corner_Radius_Bar_2 { get; set; }
        public string Corner_Radius_Bar_API_1 { get; set; }
        public string Corner_Radius_Bar_API_2 { get; set; }

        public string BTN_Save_Opacity { get; set; }
        public string TB_Adresse_Text { get; set; }
        public ICommand API_Adress_Changed { get; set; }
        public ICommand Btn_Save_Click { get; set; }



        // ---------------- TIMER ---------------------
        private static System.Timers.Timer aTimer;

        public Configuration_AdressePageViewModel()
        {

            TB_Adresse_Text = Preferences.Get("API_Url", "");

            CheckAll();

            BTN_Save_Opacity = "0";

            Corner_Radius_Bar_API_1 = "999998";
            Corner_Radius_Bar_API_2 = "999998";
            Corner_Radius_Bar_2 = "999998";
            Corner_Radius_Bar_2 = "999998";

            API_Adress_Changed = new Command(async () =>
            {
                await CheckAll();
                BTN_Save_Opacity = "1";
                OnPropertyChanged("BTN_Save_Opacity");
            });

            Btn_Save_Click = new Command(() =>
            {
                Preferences.Set("API_Url", TB_Adresse_Text);
                BTN_Save_Opacity = "0";
                OnPropertyChanged("BTN_Save_Opacity");

            });

            Click_Back = new Command(async () =>
            {
                if (Preferences.ContainsKey("identifiant"))
                {
                    if (await CheckAPIAccess())
                    {
                        await Shell.Current.GoToAsync("..");
                    }
                    else
                    {
                        await App.Disconnect();
                    }
                }
                else
                {
                    await Shell.Current.GoToAsync("..");
                }

            });

            OnPropertyChanged("TB_Adresse_Text");
        }

        async Task CheckAll()
        {
            await CheckNetworkAccess();
            await CheckAPIAccess();
            await CheckBDDAccess();
            return;
        }

        async Task<bool> CheckBDDAccess()
        {
            bool BDD_State = await MockDataStore.CheckAPIConnection(TB_Adresse_Text);
            Preferences.Set("BDD_State", BDD_State);
            return BDD_State;
        }

        async Task<bool> CheckAPIAccess()
        {
            bool API_State = await MockDataStore.CheckAPIConnection(TB_Adresse_Text);
            Preferences.Set("API_State", API_State);
            return API_State;
        }

        async Task<bool> CheckNetworkAccess()
        {
            bool network_access = Connectivity.NetworkAccess == NetworkAccess.Internet;
            Preferences.Set("Network_State", network_access);
            return network_access;
        }


        ~Configuration_AdressePageViewModel() { }
    }
}
