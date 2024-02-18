using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SNS.ViewModels;

namespace SNS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginViewModel myLoginViewModel;
        public LoginPage()
        {
            InitializeComponent();

            BindingContext = myLoginViewModel = new LoginViewModel();
            
        }

        //BTN Animation
        private async void BTN_Connect_Click(object sender, EventArgs e)
        {
            await BTN_Connect.ScaleTo(0.90,75,Easing.Linear);
            await BTN_Connect.ScaleTo(1,75,Easing.Linear);
            //await Loading.FadeTo(1,75);
        }

    }
}