﻿using ClaroNet3.Interfaces;
using GalaSoft.MvvmLight.Command;
using System;
using System.Net.Mail;
using Xamarin.Forms;

namespace ClaroNet3.ViewModels
{
    public class RecargasViewModel : BaseViewModel
    {
        #region Attributes
        private bool _componentesVisibles;
        private string _Telefono;
        private string _Monto;
        private string _Pin;
        private string _dni;
        #endregion

        #region Properties
        public bool ComponentesVisibles
        {
            get { return _componentesVisibles; }
            set { _componentesVisibles = value; OnPropertyChanged(nameof(ComponentesVisibles)); }
        }

        public string Monto
        {
            get { return _Monto; }
            set { _Monto = value; OnPropertyChanged(nameof(Monto)); }
        }

        public string Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; OnPropertyChanged(nameof(Telefono)); }
        }
        public string Pin
        {
            get { return _Pin; }
            set { _Pin = value; OnPropertyChanged(nameof(Pin)); }
        }
        public string Dni
        {
            get { return _dni; }
            set { _dni = value; OnPropertyChanged(nameof(Dni)); }
        }
        #endregion

        #region Commands
        public RelayCommand BtnRecarga => new RelayCommand(Recargar);
        #endregion  

        #region Methods

        public async void Recargar()
        {
            try
            {
               
                if (string.IsNullOrEmpty(Telefono)
                    || (string.IsNullOrEmpty(Monto))
                    || (string.IsNullOrEmpty(Pin))
                    || (string.IsNullOrEmpty(Dni)))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", $"LLene todos los campos", "Accept");
                    return;
                }

                DependencyService.Get<IServiceCaller>()
                        .RealizarLLamadaRecarga(Telefono, Monto, Pin);


            }
            catch (Exception ed)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"{ed.Message}.", "Accept");

            }
        }

        #endregion

        public RecargasViewModel()
        {
            DependencyService.Get<IServiceSms>().Mensajes += RecargasViewModel_Mensajes;
        }

        private void RecargasViewModel_Mensajes(object sender, EventArgs e)
        {
            throw new NotImplementedException();

        }


        private void EnviarMensajeDeTexto(string destinatario, string mensaje)
        {
            try
            {

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("pruebascarganet2020@gmail.com");
                mail.To.Add(destinatario);
                mail.Subject = "Factura";
                mail.Body = mensaje;
                mail.CC.Add("pruebascarganet2020@gmail.com");
                mail.IsBodyHtml = true;
                SmtpServer.Port = 587;
                SmtpServer.Host = "smtp.gmail.com";
                SmtpServer.EnableSsl = true;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("pruebascarganet2020@gmail.com", "Adrian123456");
                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Faild", ex.Message, "OK");
            }
        }





    }
}
