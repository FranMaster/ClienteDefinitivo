using CargasNetClient.Views;
using ClaroNet3.ViewModels;
using ClaroNet3.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ClaroNet3.Model
{
    public class ItemMenuModel
    {
        public string Title { get; set; }
        public string Icon { get; set; }

        public RelayCommand NavigateCommand => new RelayCommand(Navegar);

       public async void Navegar()
       {
            try
            {
                if (Title.Equals("Soporte"))
                    await Application.Current.MainPage.Navigation.PushAsync(new SoporteView());
                if (Title.Equals("Consultar Saldo"))
                    await MainVewModel.GetInstance.ConsultaSaldo();
                if (Title.Equals("listar"))
                    await Application.Current.MainPage.Navigation.PushAsync(new MenuStadisticas());
            
            }
            catch (Exception e)
            {
               await Application.Current.MainPage.DisplayAlert("AVISO", e.Message,  "volver");
            }
       }
    }
}

