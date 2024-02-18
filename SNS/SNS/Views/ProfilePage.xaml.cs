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
    public partial class ProfilePage : ContentPage
    {
        private bool first_time;

        public ProfilePageViewModel myProfilePageViewModel;
        public ProfilePage()
        {
            first_time = true;
            InitializeComponent();
            BindingContext = myProfilePageViewModel = new ProfilePageViewModel();
        }

        private void TB_Profile_Password_changed(object sender, TextChangedEventArgs e)
        {
            if (!first_time)
            {
                BTN_Save.Opacity = 1;
            }
            else
            {
                first_time = false;
            }

        }
    }
}