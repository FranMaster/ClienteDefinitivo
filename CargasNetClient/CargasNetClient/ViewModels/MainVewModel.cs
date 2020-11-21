using CargasNetClient.Model;
using CargasNetClient.ViewModels;
using ClaroNet3.Interfaces;
using ClaroNet3.Model;
using ClaroNet3.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using static ClaroNet3.Model.EventsUtilities;

namespace ClaroNet3.ViewModels
{
    public class MainVewModel
    {
        #region Properties
        public LoginViewModel Login { get; set; }
        public RecargasViewModel Recargas { get; set; }
        public RegistroViewModel Registro { get; set; }
        public ListadoRecargasViewModel ListadoRecargas { get; set; }
        public ObservableCollection<ItemMenuModel> Menu { get; set; }
        #endregion

        #region Constructor
        private MainVewModel()
        {
               
        }

        private void Notificacion(List<string> Inbox)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Singleton
        private static MainVewModel instance;

        public static MainVewModel GetInstance
        {
            get
            {

                if (instance == null)
                    instance = new MainVewModel();
                return instance;
            }

        }
        #endregion


        public void LoadMenu()
        {
            Menu = new ObservableCollection<ItemMenuModel>
            {
                new ItemMenuModel{Icon="financial",Title="Consultar Saldo"},
                new ItemMenuModel{Icon="home",Title="Soporte"}                
             
            };
            IdDispositivos = UserRepository.GetInstancia.GetAllUsers()[0]?.CodigoSql;
        }


        public async Task ConsultaSaldo()
        {
            var datos = (List<Users>)UserRepository.GetInstancia.GetAllUsers();
            string pinGuardado = datos[0].Password;
            if (!string.IsNullOrEmpty(pinGuardado))
                await Task.Run(() =>
            DependencyService.Get<IServiceCaller>()
                       .RealizarLLamadaSaldo(pinGuardado));
        }

        public List<InboxSms> ListarDatos()
        {
            var Respuesta = DependencyService.Get<IServiceSms>()
                           .GetAllSms();
            return Respuesta;      
        }


        private void MainVewModel_Mensajes(object sender, EventArgs e)
        {
            Application.Current.MainPage
                .DisplayAlert("Aviso de mensaje recibido", "e", "volver");
        }



        public void ConfiguracionInicial()
        {
            Recargas = new RecargasViewModel();
            ListadoRecargas = new ListadoRecargasViewModel();
            Recargas.ComponentesVisibles = true;
            LoadMenu();
        }

        private string _IdDispositivos;

        public string IdDispositivos
        {
            get { return _IdDispositivos; }
            set { _IdDispositivos = value;  }
        }

    }
}
