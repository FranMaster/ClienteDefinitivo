using ApiConsumer;
using ApiConsumer.Services;
using CargasNetClient.Model;
using ClaroNet3.ViewModels;
using ClaroNet3.Views;
using GalaSoft.MvvmLight.Command;
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


        private void EnviarDatos()
        {
            ConsultaDispositivosServices servicio = new ConsultaDispositivosServices();
            var res = servicio.VerificarUsuario(new VerificacionRequest
            {
                numeroTel = "1042436738",
                pin = "0"
            });
            if (res.Success)
            {
                var datos = res.ObjectData;
                int sql = UserRepository.GetInstancia.AddNewUser(
                         datos.email,
                         "",
                         datos.email,
                         datos.id.ToString()
                 );
                if (sql > 0)
                {
                    //continuar con la siguiente pagina
                }
                else
                {
                    //mandar pagina de error
                }
            }
            else
            {
                var b = 0;
            }
        }
    }
}
