using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;

using SNS.Models;
using SNS.Services;
using System.Threading.Tasks;
using System.IO;
namespace SNS.ViewModels
{
    public class ProfilePageViewModel : BaseViewModel
    {
        //define command
        public ICommand Click_Back { get; set; }
        public ICommand Btn_Save { get; set; }
        public ICommand Deconnexion_Click { get; set; }

        //define string
        public string Complete_Name { get; set; }
        public string Status { get; set; }
        public string Password { get; set; }


        public string Btn_Save_Opacity { get; set; }
        public ImageSource profile_img { get; set; }

        public ProfilePageViewModel() {

            string img64 = Preferences.Get("image", "");
            profile_img = ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(img64)));

            Complete_Name = Preferences.Get("name", "");
            Status = Preferences.Get("status", "");

            Password = Preferences.Get("password", "");

            Btn_Save_Opacity = "0";

            Deconnexion_Click = new Command(async () => {

                await App.Disconnect();
            });

            Click_Back = new Command(async () => {

                await Shell.Current.GoToAsync("..");
            });

            Btn_Save = new Command(async () => {

                string Token = Preferences.Get("token", "");

                Task<User> task_Put_Paliers_info = MockDataStore.PutAsync_Password(Token, Password);
                var retour = task_Put_Paliers_info.Result;

                if (retour.status == "Created")
                {
                    Btn_Save_Opacity = "0";

                }
                else
                {

                }


                OnPropertyChanged("Btn_Save_Opacity");
            });



        }



        ~ProfilePageViewModel() { }
    }
}
