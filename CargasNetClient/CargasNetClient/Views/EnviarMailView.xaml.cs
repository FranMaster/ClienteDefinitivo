using CargasNetClient.Model;
using CargasNetClient.Model.Constantes;
using System;
using System.Net.Mail;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClaroNet3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnviarMailView : ContentPage
    {
        public RecargasRealizadas RecargasRealizadas { set; get; }
        public EnviarMailView(RecargasRealizadas item = null)
        {
            InitializeComponent();
            if (item != null)
            {
                RecargasRealizadas = item;
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                string CuerpoMenssaje = string.Format(ConstantesSistemas.HtmlBase, DateTime.Now.ToShortDateString(),
                                                     "pruebascarganet2020@gmail.com",
                                                     this.TxtEmail?.Text,
                                                     "Recarga de Saldo",
                                                     RecargasRealizadas.FechaRecarga,
                                                     this.RecargasRealizadas.Numero);
                EnviarMensajeDeTexto(this.TxtEmail.Text, CuerpoMenssaje);
                await DisplayAlert("Aviso", "Se envio Mail con exito.","Volver");
                Application.Current.MainPage = new NavigationPage(new MasterPage());
            
            }
            catch (Exception)
            {
                await DisplayAlert("Aviso", "No se Pudo Realizar envio de mensaje.","Volver");
            }
        }


        private void EnviarMensajeDeTexto(string destinatario, string mensaje)
        {
            try
            {

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("pruebascarganet2020@gmail.com", "Adrian123456");
                mail.To.Add(destinatario);
                mail.Subject = "Factura";
                mail.CC.Add("pruebascarganet2020@gmail.com");
                mail.Body = mensaje;
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
                Application.Current.MainPage.DisplayAlert("Failed", ex.Message, "OK");
            }
        }
    }
}