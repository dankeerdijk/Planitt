   using System;
using Microsoft.WindowsAzure.MobileServices;
using planitt.model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace planitt
{
    public partial class App : Application
    {
        public static User user = new User();
        public static MobileServiceClient MobileService =
                 new MobileServiceClient(
            "https://plannit.azurewebsites.net" );



        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
