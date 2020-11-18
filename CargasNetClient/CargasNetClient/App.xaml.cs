using ClaroNet3.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CargasNetClient.Views;
using CargasNetClient.Model;
using ClaroNet3.ViewModels;
using CargasNetClient.ViewModels;

namespace CargasNetClient
{
    public partial class App : Application
    {
        public App( string fileName)
        {
            UserRepository.Inicializador(fileName);
            InitializeComponent();
            var Usuarios = UserRepository.GetInstancia.GetAllUsers();
            if (Usuarios.Count > 0)
            {
                MainVewModel.GetInstance.ConfiguracionInicial();
                MainPage = new NavigationPage(new MasterPage());
            }
            else
            {
                MainVewModel.GetInstance.Registro = new RegistroViewModel();
                MainPage = new NavigationPage(new  Registro());

            }
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
