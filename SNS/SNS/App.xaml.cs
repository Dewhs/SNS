using SNS.Services;
using SNS.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading;
using Xamarin.Essentials;
using System.Threading.Tasks;

[assembly: ExportFont("PoppinsThinItalic.ttf", Alias = "PoppinsThinItalic")]
[assembly: ExportFont("PoppinsThin.ttf", Alias = "PoppinsThin")]
[assembly: ExportFont("PoppinsSemiBoldItalic.ttf", Alias = "PoppinsSemiBoldItalic")]
[assembly: ExportFont("PoppinsSemiBold.ttf", Alias = "PoppinsSemiBold")]
[assembly: ExportFont("PoppinsRegular.ttf", Alias = "PoppinsRegular")]
[assembly: ExportFont("PoppinsMediumItalic.ttf", Alias = "PoppinsMediumItalic")]
[assembly: ExportFont("PoppinsMedium.ttf", Alias = "PoppinsMedium")]
[assembly: ExportFont("PoppinsLightItalic.ttf", Alias = "PoppinsLightItalic")]
[assembly: ExportFont("PoppinsLight.ttf", Alias = "PoppinsLight")]
[assembly: ExportFont("PoppinsItalic.ttf", Alias = "PoppinsItalic")]
[assembly: ExportFont("PoppinsExtraLightItalic.ttf", Alias = "PoppinsExtraLightItalic")]
[assembly: ExportFont("PoppinsExtraLight.ttf", Alias = "PoppinsExtraLight")]
[assembly: ExportFont("PoppinsExtraBoldItalic.ttf", Alias = "PoppinsExtraBoldItalic")]
[assembly: ExportFont("PoppinsExtraBold.ttf", Alias = "PoppinsExtraBold")]
[assembly: ExportFont("PoppinsBoldItalic.ttf", Alias = "PoppinsBoldItalic")]
[assembly: ExportFont("PoppinsBold.ttf", Alias = "PoppinsBold")]
[assembly: ExportFont("PoppinsBlackItalic.ttf", Alias = "PoppinsBlackItalic")]
[assembly: ExportFont("PoppinsBlack.ttf", Alias = "PoppinsBlack")]



namespace SNS
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            VersionTracking.Track();
            Preferences.Set("App_Version", VersionTracking.CurrentVersion);

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        public static async Task<bool> Disconnect()
        {
            string API_Url = Preferences.Get("API_Url", ""); //Recupere L'url de l'API
            Preferences.Clear();//Clear les preferences
            Preferences.Set("API_Url", API_Url);//Cree une clef "API_Url" avec comme valeur l'url de l'API
            await Shell.Current.GoToAsync("//LoginPage");
            //await Shell.Current.GoToAsync("//LoginPage");

            return true;
        }

    }
}
