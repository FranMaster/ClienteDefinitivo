using CargasNetClient.Model;
using System;
using System.Collections.Generic;

namespace ClaroNet3.Interfaces
{
    public interface IServiceSms
    {
        event EventHandler Mensajes;
        List<InboxSms> GetAllSms();
    }
}
