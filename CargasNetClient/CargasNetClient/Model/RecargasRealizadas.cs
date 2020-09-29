using ClaroNet3.Views;
using GalaSoft.MvvmLight.Command;
using System;
using Xamarin.Forms;

namespace CargasNetClient.Model
{
    public class RecargasRealizadas
    {
        public string UrlImg { get; set; }
        public string Numero { get; set; }
        public string SaldoCargado { get; set; }
        public DateTime FechaRecargaT { get; set; }
        public string Descripcion { get; set; }
        public string FechaRecarga => FechaRecargaT.ToLongTimeString();

        public RelayCommand NavigateCommand => new RelayCommand(navegar);
        private async void navegar()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new EnviarMailView(this));
        }
    }
}
