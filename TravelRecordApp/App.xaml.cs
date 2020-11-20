using System;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
    public partial class App : Application
    {
        public static string DatabaseLocation = string.Empty;

        public static MobileServiceClient client = new MobileServiceClient("https://travelappxam.azurewebsites.net");

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        //This is being called insted of the initial public App but it is still needed incase of a crash
        public App(string databaseLocation)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());

            DatabaseLocation = databaseLocation;
        }

        protected override void OnStart()
        {
            // Handels when your app starts
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
