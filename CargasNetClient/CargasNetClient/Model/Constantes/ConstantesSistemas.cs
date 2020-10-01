namespace CargasNetClient.Model.Constantes
{
    public class ConstantesSistemas
    {

        public static string HtmlBase = "<!DOCTYPE html> <html lang='en'> <head> <meta charset='UTF-8'> <meta name='viewport' content='width=device-width, initial-scale=1.0'> <title>Document</title> </head> <body style='margin: 0;'> <section style='display: flex; justify-content: center; align-items: center; height: 100vh; width: 100vw; background-color:white;'> <div style='width: 80vw; height: 90vh; background-color:white; box-shadow: -4px 5px 27px 1px rgba(0,0,0,0.75); border-radius: 15px; padding: 20px; '> <div style='display: flex;justify-content: space-between;'> <h1 style='margin: 0;padding: 0;font-size: xx-large;'>Comprobante</h1> <em>Fecha:<strong>{0}</strong></em> </div> <div> <div> <h3 style='margin: 0;padding: 0; color: black;'>Cargas Net</h3> <em>{1}</em> </div> <div> <h3 style='margin: 0;padding: 0;color: black;'>Cliente</h3> <em>{2}</em> </div> </div> <hr> <div style='display: flex; justify-content: center; align-items: center;'> <table> <thead style='background-color: navy; color: white;'> <tr> <th style='padding: 5%; width: 100px;'>Tipo Operacion</th> <th style='padding: 5%; width: 100px;'>Hora</th> <th style='padding: 5%; width: 100px; text-align: center;'>Descripción</th> </tr> </thead> <tr> <td style='padding: 5%; width: 100px; text-align: center;'>{3}</td> <td>{4}</td> <td>$ {5}</td> </tr> </table> </div> <div style='position: absolute; left: 60; '> No valido como factura </div> </div> </section> </body> </html>";
    }

    public enum FechaAtras
    {
        Hoy = 0, Mes = 30
    }

}
