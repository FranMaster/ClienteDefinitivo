

using CargasNetClient.Model;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ClaroNet3.ViewModels
{
    public class ListadoRecargasViewModel : BaseViewModel
    {
        private ObservableCollection<RecargasRealizadas> _RecargasRealizadass;

        public ObservableCollection<RecargasRealizadas> RecargasRealizadass
        {
            get { return _RecargasRealizadass; }
            set { _RecargasRealizadass = value;
                OnPropertyChanged(nameof(RecargasRealizadass));
            }
        }

       
        public ListadoRecargasViewModel()
        {
            RecargasRealizadass = new ObservableCollection<RecargasRealizadas>();
            RecargasRealizadass.Add(new RecargasRealizadas
            {
                Numero = "+541163069305",
                FechaRecarga = DateTime.Now.ToLongDateString(),
                UrlImg = "checked"
            });
            RecargasRealizadass.Add(new RecargasRealizadas
            {
                Numero = "+541163069305",
                FechaRecarga = DateTime.Now.ToLongDateString(),
                UrlImg = "checked"
            });



        }


        public RelayCommand BtnRecargar
        => new RelayCommand(BuscarRecargasRealizadas);



        public void BuscarRecargasRealizadas()
        {
            RefreshAction = true;
            var Recargas = MainVewModel.GetInstance.ListarDatos();
            RecargasRealizadass  = 
                new ObservableCollection<RecargasRealizadas>( AdecuarRespuesta(Recargas));
            RefreshAction = false;
        }

        private List<RecargasRealizadas> AdecuarRespuesta(List<string> recargas)
        {
            List<RecargasRealizadas> Recargas = 
                new List<RecargasRealizadas>();

            foreach (var item in recargas)
            {
                if (item.ToUpper().Contains("SU SOLICITUD"))
                {
                    var rec = new RecargasRealizadas();
                    rec.Descripcion = item.Split('.')[1];
                    rec.UrlImg = "fail";
                    Recargas.Add(rec);
                }
            }
            return Recargas;
        }

        private bool _RefreshAction;

        public bool RefreshAction
        {
            get { return _RefreshAction; }
            set { _RefreshAction = value;
                OnPropertyChanged(nameof(RefreshAction));
            }
        }



    }
}
