﻿using System;

namespace CargasNetClient.Model
{
    public class RecargasRealizadas
    {
        public string UrlImg { get; set; }
        public string Numero { get; set; }
        public string SaldoCargado { get; set; }
        public DateTime FechaRecargaT { get; set; }
        public string Descripcion { get; set; }
        public string FechaRecarga => FechaRecargaT.ToLongTimeString();
       
    }
}
