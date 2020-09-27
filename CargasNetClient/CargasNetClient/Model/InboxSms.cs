using System;
using System.Collections.Generic;
using System.Text;

namespace CargasNetClient.Model
{
    public class InboxSms
    {
        public int Id { get; set; }
        public DateTime FechaSms { get; set; }
        public string CuerpoMensaje  { get; set; }

    }
}
