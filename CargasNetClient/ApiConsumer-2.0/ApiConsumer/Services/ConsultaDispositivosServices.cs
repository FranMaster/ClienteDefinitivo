using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft;

namespace ApiConsumer.Services
{
    public class ConsultaDispositivosServices:BaseService
    {
        public GenericResponse<VerificacionResponse> VerificarUsuario(VerificacionRequest verificacionRequest)
        {
            string Url = "https://backcargas.herokuapp.com";
            string controller = "verify";
            return base.Post<VerificacionResponse>(Url, controller, verificacionRequest);
        }
    }

    public class UsuarioResponse
    {
        [JsonPropertyName("id")]
        public int Id;

        [JsonPropertyName("FechaAlta")]
        public DateTime FechaAlta;

        [JsonPropertyName("FeachaBaja")]
        public object FeachaBaja;

        [JsonPropertyName("numeroTel")]
        public string NumeroTel;

        [JsonPropertyName("pin")]
        public string Pin;

        [JsonPropertyName("email")]
        public string Email;
    }

    public class VerificacionResponse
    {
        [JsonPropertyName("data")]
        public List<UsuarioResponse> Data;
    }


}
