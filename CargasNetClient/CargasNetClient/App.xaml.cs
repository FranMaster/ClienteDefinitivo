using ClaroNet3.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CargasNetClient.Views;
namespace CargasNetClient
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new  Registro());
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
    }
}
