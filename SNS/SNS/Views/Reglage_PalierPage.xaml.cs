using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


using SNS.ViewModels;
using TouchTracking;


using Xamarin.Essentials;
using SNS.Models;
using SNS.Services;

namespace SNS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Reglage_PalierPage : ContentPage
    {
        public Reglage_PalierPageViewModel myReglage_PalierPageViewModel;

        // ------------ Position : X, Y ----------------

        public float F1_Xposition;
        public float F2_Xposition;
        public int total_slider_widht;
        public Reglage_PalierPage()
        {

            InitializeComponent();

            BindingContext = myReglage_PalierPageViewModel = new Reglage_PalierPageViewModel();

            /*Slider_bar_orange.TranslationX = 100;
            Slider_bar_rouge.TranslationX = 200;
            L_Palier_1.TranslationX = 90;
            L_Palier_2.TranslationX = 190;*/

            F1_Xposition = float.Parse(Frame_Palier_1.TranslationX.ToString());
            F2_Xposition = float.Parse(Frame_Palier_2.TranslationX.ToString());
            total_slider_widht = 300;
        }

        

        private void OnTouch_F1(object sender, TouchActionEventArgs args)
        {
            

            var point = args.Location; //Point location
            var type = args.Type; //Entered, Pressed, Moved ... etc.

            Console.WriteLine("X1 = " + point.X);
            float F1_width = float.Parse(Frame_Palier_1.Width.ToString());

            F1_Xposition += point.X - F1_width / 2;

            if (F1_Xposition < 0 - F1_width / 2)
            {
                F1_Xposition = 0 - F1_width / 2;
            }
            else if (F1_Xposition >= F2_Xposition)
            {
                F1_Xposition = F2_Xposition;
            }
            else { }

            Frame_Palier_1.TranslationX = F1_Xposition;
            L_Palier_1.TranslationX = F1_Xposition + Frame_Palier_1.Width / 2 - L_Palier_1.Width / 2;
            L_Palier_1.Text = Math.Round(20 + (F1_Xposition + F1_width / 2) / 3).ToString();
            Slider_bar_green.WidthRequest = Frame_Palier_1.Width / 2 + F1_Xposition;
            Slider_bar_orange.TranslationX = Slider_bar_green.WidthRequest;
            Slider_bar_orange.WidthRequest = F2_Xposition - F1_Xposition;


            //await Frame_Palier_1.TranslateTo(point.X, 0,0,Easing.CubicOut);
            BTN_Save.Opacity = 1;
        }

        private void OnTouch_F2(object sender, TouchActionEventArgs args)
        {
            

            var point = args.Location; //Point location
            var type = args.Type; //Entered, Pressed, Moved ... etc.

            Console.WriteLine("X2 = " + point.X);
            float F2_width = float.Parse(Frame_Palier_2.Width.ToString());



            F2_Xposition += point.X - F2_width / 2;

            if (F2_Xposition > total_slider_widht - F2_width / 2)
            {
                F2_Xposition = total_slider_widht - F2_width / 2;
            }
            else if (F2_Xposition <= F1_Xposition)
            {
                F2_Xposition = F1_Xposition;
            }
            else { }

            Frame_Palier_2.TranslationX = F2_Xposition;
            L_Palier_2.TranslationX = F2_Xposition + Frame_Palier_2.Width / 2 - L_Palier_2.Width / 2;
            L_Palier_2.Text = Math.Round(20 + (F2_Xposition + F2_width / 2) / 3).ToString();
            Slider_bar_orange.WidthRequest = F2_Xposition - F1_Xposition;
            Slider_bar_rouge.TranslationX = F2_Xposition;
            Slider_bar_rouge.WidthRequest = total_slider_widht - F2_Xposition;

            BTN_Save.Opacity = 1;
        }

    }
}