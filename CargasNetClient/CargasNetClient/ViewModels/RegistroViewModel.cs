﻿using ApiConsumer;
using ApiConsumer.Services;
using CargasNetClient.Model;
using ClaroNet3.ViewModels;
using ClaroNet3.Views;
using GalaSoft.MvvmLight.Command;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CargasNetClient.ViewModels
{
    public class RegistroViewModel : BaseViewModel
    {
        private string _Telefono;

        public string Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; OnPropertyChanged(nameof(Telefono)); }
        }
        private string _pin;

        public string Pin
        {
            get { return _pin; }
            set { _pin = value; OnPropertyChanged(nameof(Pin)); }
        }
        private string _mail;

        public string Mail
        {
            get { return _mail; }
            set { _mail = value; OnPropertyChanged(nameof(Mail)); }
        }

        public RelayCommand EnviarCommand
        {
            get
            {
                return new RelayCommand(EnviarDatos);
            }

        }


        private async void EnviarDatos()
        {

            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                ConsultaDispositivosServices servicio = new ConsultaDispositivosServices();
                var res = servicio.VerificarUsuario(new VerificacionRequest
                {
                    numeroTel = Telefono?.Trim(),
                    pin = Pin?.Trim(),
                    email=Mail?.Trim()
                });
                if (res.Success)
                {
                    if (res.ObjectData.Data.Count==0)
                    {
                        await Application.Current.MainPage
                            .DisplayAlert("No encontrado", 
                                          "Esta terminal aun no se ha dado de alta",
                                          "Volver");
                        return;
                    }
                    var datos = res.ObjectData.Data[0];
                    int sql = UserRepository.GetInstancia.AddNewUser(
                             datos.Email,
                             datos.Pin,
                             datos.Email,
                             datos.Id.ToString()
                     );
                    if (sql > 0)
                    {
                        MainVewModel.GetInstance.ConfiguracionInicial();
                        Application.Current.MainPage = new NavigationPage(new MasterPage());
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("No encontrado", "Esta terminal aun no se ha dado de alta", "Volver");
                    }
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("No encontrado", "Esta terminal aun no se ha dado de alta", "Volver");
                }
            }
            else
            {
               await Application.Current.MainPage.DisplayAlert("Revise su Conexión", "No tienes conexión a internet", "Volver");
            }
         
        }
    }
}
