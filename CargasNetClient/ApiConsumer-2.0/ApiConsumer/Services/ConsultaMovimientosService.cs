using System;
using System.Collections.Generic;
using System.Text;

namespace ApiConsumer.Services
{
    public class ConsultaMovimientosService:BaseService
    {

        public GenericResponse<MovimientosResponse> InsertarMovimiento(MovimientosRequest verificacionRequest)
        {
            string Url = "https://backcargas.herokuapp.com";
            string controller = "InsertarMovimientos";
            return base.Post<MovimientosResponse>(Url, controller, verificacionRequest);
        }



    }


    public class MovimientosRequest
    {    
        public string description;        
        public string IdDispositivo;       
        public string Fecha;
    }


    public class MovimientosResponse
    {
      
        public int Data;

        
        public bool Succes;
    }




}
