using SNS.ViewModels;
using SNS.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SNS
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            
            //Routing.RegisterRoute("LoginPage", typeof(LoginPage));
            Routing.RegisterRoute("HomePage", typeof(HomePage));
            Routing.RegisterRoute("HomePage/Reglage_PalierPage", typeof(Reglage_PalierPage));
            Routing.RegisterRoute("HomePage/ProfilePage", typeof(ProfilePage));
            Routing.RegisterRoute("HomePage/Configuration_AdressePage", typeof(Configuration_AdressePage));
            Routing.RegisterRoute("LoginPage/Configuration_AdressePage", typeof(Configuration_AdressePage));
            /* Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
             Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));*/
        }

/*Routing.RegisterRoute("//HomePage", typeof(HomePage));*/
        /*private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }*/
    }
}
