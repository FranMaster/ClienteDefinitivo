using System;
using System.Collections.Generic;
using System.Text;

namespace ApiConsumer
{
    public class VerificacionRequest
    {        
        public string numeroTel { get; set; }
        public string pin { get; set; }
        public string email { get; set; }
        public int id { get; set; }
  
    }
}
