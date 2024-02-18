using System;
using System.Collections.Generic;
using System.Text;


using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;
using SNS.Models;
using SNS.Services;
using System.Threading.Tasks;
namespace SNS.ViewModels
{
    public class Reglage_PalierPageViewModel : BaseViewModel
    {
        //define Widht and Height of Round Slider Button
        public double Widht_and_Height_Round_Slider_Btn { get; set; }

        //define translation value
        public double Btn_Palier_1_Translation { get; set; }
        public double Btn_Palier_2_Translation { get; set; }
        public double Green_Bar_Translation { get; set; }
        public double Orange_Bar_Translation { get; set; }
        public double Red_Bar_Translation { get; set; }

        public double Label_Palier_1_Translation { get; set; }
        public double Label_Palier_2_Translation { get; set; }

        //define WidhtRequest
        public double Green_Bar_W { get; set; }
        public double Orange_Bar_W { get; set; }
        public double Red_Bar_W { get; set; }
        public double Label_Palier_1_W { get; set; }
        public double Label_Palier_2_W { get; set; }

        //define Label value
        public string Label_Palier_1_Value { get; set; }
        public string Label_Palier_2_Value { get; set; }


        //define command
        public ICommand Click_Back { get; set; }
        public ICommand Btn_Save { get; set; }

        public string Btn_Save_Opacity { get; set; }

        private string Token = Preferences.Get("token", "");
        public Reglage_PalierPageViewModel()
        {

            Btn_Save_Opacity = "0";

            API_Info API_info = MockDataStore.PostAsync_Palier(Token).Result;
            

            Widht_and_Height_Round_Slider_Btn = 40;
            Label_Palier_1_W = 50;
            Label_Palier_2_W = 50;


            Click_Back = new Command(async () =>
            {

                await Shell.Current.GoToAsync("..");
            });

            Btn_Save = new Command(async () =>
            {

                 API_Info retour = await MockDataStore.PutAsync_Palier(Token, Label_Palier_1_Value, Label_Palier_2_Value);

                if (retour.status == "Created")
                {
                    Btn_Save_Opacity = "0";

                }
                else
                {

                }

                OnPropertyChanged("Btn_Save_Opacity");
            });


            Label_Palier_1_Value = API_info.minimum;
            Label_Palier_2_Value = API_info.maximum;



            double Palier_1_Value = (double.Parse(Label_Palier_1_Value) - 20) * 3;
            double Palier_2_Value = (double.Parse(Label_Palier_2_Value) - 20) * 3;

            //----------------------------------------------

            Btn_Palier_1_Translation = Palier_1_Value - Widht_and_Height_Round_Slider_Btn / 2;
            Btn_Palier_2_Translation = Palier_2_Value - Widht_and_Height_Round_Slider_Btn / 2;
            Label_Palier_1_Translation = Btn_Palier_1_Translation - Label_Palier_1_W / 2 + Widht_and_Height_Round_Slider_Btn / 2;
            Label_Palier_2_Translation = Btn_Palier_2_Translation - Label_Palier_2_W / 2 + Widht_and_Height_Round_Slider_Btn / 2;
            Green_Bar_W = Btn_Palier_1_Translation + Widht_and_Height_Round_Slider_Btn / 2;
            Orange_Bar_Translation = Green_Bar_W;
            Orange_Bar_W = Btn_Palier_2_Translation - Btn_Palier_1_Translation;
            Red_Bar_Translation = Btn_Palier_2_Translation;
            Red_Bar_W = 300 - Red_Bar_Translation;


            //----------------------------------------------



        }




        ~Reglage_PalierPageViewModel() { }


    }
}
