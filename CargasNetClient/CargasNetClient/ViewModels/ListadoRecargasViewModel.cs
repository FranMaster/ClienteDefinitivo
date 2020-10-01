

using CargasNetClient.Model;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace ClaroNet3.ViewModels
{
    public class ListadoRecargasViewModel : BaseViewModel
    {
        private ObservableCollection<RecargasRealizadas> _RecargasRealizadass;

        private long? _VentasHoy;

        public long? VentasHoy
        {
            get { return _VentasHoy; }
            set { 
                _VentasHoy = value;                             
                OnPropertyChanged(nameof(VentasHoy)); 
            }
        }

        private long? _VentasMes;

        public long? VentasMes
        {
            get { return _VentasMes; }
            set
            {
                _VentasMes = value;
                OnPropertyChanged(nameof(VentasMes));
            }
        }


        public ObservableCollection<RecargasRealizadas> RecargasRealizadass
        {
            get { return _RecargasRealizadass; }
            set
            {
                _RecargasRealizadass = value;
                OnPropertyChanged(nameof(RecargasRealizadass));
            }
        }


        public ListadoRecargasViewModel()
        {          

        }


        public RelayCommand BtnRecargar
        => new RelayCommand(BuscarRecargasRealizadas);



        public async void BuscarRecargasRealizadas()
        {
            DateTime xmas = new DateTime(2020, 10, 09);
            double daysUntilChristmas = xmas.Subtract(DateTime.Today).TotalDays;
            if ((!(DateTime.Now <= xmas)))
            {
                await Application.Current.MainPage.DisplayAlert("Aviso", "Su Periodo de Evaluación Termino.", "Volver");
                return;
            }
            RefreshAction = true;
            var Recargas = MainVewModel.GetInstance.ListarDatos();
            RecargasRealizadass =
                new ObservableCollection<RecargasRealizadas>(AdecuarRespuesta(Recargas));
            RefreshAction = false;
            CalcularVentasHoy();
            CalcularVentasMes();
        }

        private List<RecargasRealizadas> AdecuarRespuesta(List<InboxSms> recargas)
        {
            List<RecargasRealizadas> Recargas =
                new List<RecargasRealizadas>();
            Filtro(recargas, ref Recargas, "ALL");
            return Recargas;
        }

        private bool _RefreshAction;

        public bool RefreshAction
        {
            get { return _RefreshAction; }
            set
            {
                _RefreshAction = value;
                OnPropertyChanged(nameof(RefreshAction));
            }
        }

        public void Filtro(IList<InboxSms> recargas, ref List<RecargasRealizadas> Recargas, string Filtro)
        {
            foreach (InboxSms item in recargas)
            {
                switch (Filtro)
                {
                    case "FALLO":
                        if (item.CuerpoMensaje.ToUpper().Contains(Filtro))
                        {
                            var rec = new RecargasRealizadas();
                            rec.Descripcion = item.CuerpoMensaje.Split('.')[1] + " " + item.FechaSms.ToLongDateString();
                            rec.UrlImg = "fail";
                            Recargas.Add(rec);
                        }
                        break;
                    case "TRANSACCION EXITOSA":
                        if (item.CuerpoMensaje.ToUpper().Contains(Filtro))
                        {
                            var rec = new RecargasRealizadas();
                            rec.Descripcion = string.Empty;
                            rec.UrlImg = "checked";
                            rec.FechaRecargaT = item.FechaSms;
                            Recargas.Add(rec);
                        }
                        break;
                    case "ALL":
                        if (item.CuerpoMensaje.ToUpper().Contains("FALLO"))
                        {
                            var rec = new RecargasRealizadas();
                            rec.Numero = item.CuerpoMensaje.Split('.')[0];
                            rec.Descripcion = string.Empty;
                            rec.FechaRecargaT = item.FechaSms;
                            rec.UrlImg = "fail";
                            Recargas.Add(rec);
                        }
                        else if (item.CuerpoMensaje.ToUpper().Contains("TRANSACCION EXITOSA"))
                        {
                            var Fecha = DateTime.Now;
                            var rec = new RecargasRealizadas();
                            rec.UrlImg = "checked";
                            var mess = item.CuerpoMensaje.Split('.');
                            rec.Numero = mess[1];
                            rec.FechaRecargaT = item.FechaSms;
                            Recargas.Add(rec);
                       
                        }
                        break;
                }
            }
        }
      

        public void CalcularVentasHoy()
        {
            VentasHoy = 0;
            VentasHoy = null;
            if (RecargasRealizadass != null && RecargasRealizadass.Count > 0)
            {
                foreach (var item in RecargasRealizadass)
                {
                    if (string.IsNullOrEmpty(item.Descripcion) &&
                        item.Numero.ToUpper().Contains("VENTA"))
                    {
                        if (item.FechaRecargaT == DateTime.Today)
                        {
                            var mess = int.Parse(item.Numero.Split(' ')[5]);
                            if (VentasHoy==null)
                              VentasHoy = mess;
                            else
                            VentasHoy += mess;
                        }                       

                    }
                }

            }
                   
                     
        }


        public void CalcularVentasMes()
        {
            VentasMes = 0;
            VentasMes = null;
            if (RecargasRealizadass != null && RecargasRealizadass.Count > 0)
            {
                foreach (var item in RecargasRealizadass)
                {
                    if (string.IsNullOrEmpty(item.Descripcion) &&
                        item.Numero.ToUpper().Contains("VENTA"))
                    {
                        if (item.FechaRecargaT > DateTime.Now.AddDays(-30))
                        {
                            var mess = int.Parse(item.Numero.Split(' ')[5]);
                            if (VentasMes == null)
                                VentasMes = mess;
                            else
                                VentasMes += mess;
                        }

                    }
                }

            }


        }

    }
}
