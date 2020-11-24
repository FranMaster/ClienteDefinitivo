using ApiConsumer;
using ApiConsumer.Services;
using CargasNetClient.Model;
using ClaroNet3.ViewModels;
using ClaroNet3.Views;
using GalaSoft.MvvmLight.Command;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CargasNetClient.ViewModels
{
    public class RegistroViewModel : BaseViewModel
    {

        private bool _Running;

        public bool Running
        {
            get { return _Running; }
            set { _Running = value; OnPropertyChanged(nameof(Running)); }
        }


        private bool _habilitarBoton=true;

        public bool HabilitarBoton
        {
            get { return _habilitarBoton; }
            set { _habilitarBoton = value; OnPropertyChanged(nameof(HabilitarBoton)); }
        }









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
                return new RelayCommand(Hacerlo);
            }

        }

        public  void Corriendo()
        {
            Running = true;
            HabilitarBoton = false;
        }

        public  void Finalizado()
        {
            Running = false;
            HabilitarBoton = true;
        }


        public async void Hacerlo()
        {
            await Task.Run(Corriendo);
            var response = await Task.Run(EnviarDatos);
            if (response=="ok")
            {
                MainVewModel.GetInstance.ConfiguracionInicial();
                Application.Current.MainPage = new NavigationPage(new MasterPage());
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Advertencia", response, "Volver");
            }
            await Task.Run(Finalizado);
        }



        private  Task<string> EnviarDatos()
        {
           
            var current = Connectivity.NetworkAccess;
                
            if (current == NetworkAccess.Internet)
            {
                ConsultaDispositivosServices servicio = new ConsultaDispositivosServices();
                var res = servicio.VerificarUsuario(new VerificacionRequest
                {
                    numeroTel = Telefono?.Trim(),
                    pin = Pin?.Trim(),
                    email = Mail?.Trim()
                });
                if (res.Success)
                {
                    if (res.ObjectData.Data.Count == 0)                                                                   
                        return  Task.FromResult("Esta terminal aun no se ha dado de alta");                    
                    var datos = res.ObjectData.Data[0];
                    int sql = UserRepository.GetInstancia.AddNewUser(
                             datos.Email,
                             datos.Pin,
                             datos.Email,
                             datos.Id.ToString()
                     );
                    if (sql > 0)
                        return Task.FromResult("ok");                
                    else
                        return Task.FromResult("Esta terminal aun no se ha dado de alta");
                    
                }
                else
                {

                    return Task.FromResult("Esta terminal aun no se ha dado de alta");
                }
            }
            else
            {

                return Task.FromResult("No tienes conexión a internet");
            }

        }
    }
}
