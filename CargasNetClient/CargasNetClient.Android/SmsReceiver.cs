
using Android.App;
using Android.Content;
using Android.Database;
using Android.Provider;
using CargasNetClient.Model;
using ClaroClient3.Droid;
using ClaroNet3.Interfaces;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

[assembly: Dependency(typeof(SMSReceiver))]
namespace ClaroClient3.Droid
{
    [BroadcastReceiver(Label = "SMS Receiver")]
    [IntentFilter(new string[] { "android.provider.Telephony.SMS_RECEIVED" })]
    public class SMSReceiver : BroadcastReceiver, IServiceSms
    {
        public static readonly string IntentAction = "android.provider.Telephony.SMS_RECEIVED";
        public event EventHandler Mensajes;

        public void AvisoMensaje(List<InboxSms> MensajeInbox)
        {
            Mensajes.Invoke(MensajeInbox, new EventArgs());
        }

        public override void OnReceive(Context context, Intent intent)
        {
            var listado = GetAllSms(true);
            AvisoMensaje(listado);
        }

        public List<InboxSms> GetAllSms(bool last=false)
        {
            try
            {
                List<InboxSms> smsList = new List<InboxSms>();
                Context context = Android.App.Application.Context;
                ContentResolver contentResolver = context.ContentResolver;
                ICursor c = contentResolver.Query(Telephony.Sms.ContentUri, null, null, null, null);

                if (c != null)
                {
                    var totalSMS = c.Count;
                    if (!last)
                    {
                        while (c.MoveToNext())
                        {
                            if (c.GetString(c.GetColumnIndexOrThrow("ADDRESS")).Equals("RecargaCLR"))
                            {
                                var i = c.GetLong(c.GetColumnIndexOrThrow("DATE"));
                                DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                                DateTime date = start.AddMilliseconds(i).ToLocalTime();
                                smsList.Add(new InboxSms
                                {
                                    CuerpoMensaje = c.GetString(c.GetColumnIndexOrThrow("BODY")),
                                    FechaSms = date,
                                    Id = c.GetInt(c.GetColumnIndexOrThrow("_ID"))
                                });

                            }
                        }
                    }
                    else
                    {
                        while (c.MoveToLast())
                        {
                            if (c.GetString(c.GetColumnIndexOrThrow("ADDRESS")).Equals("RecargaCLR"))
                            {
                                var i = c.GetLong(c.GetColumnIndexOrThrow("DATE"));
                                DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                                DateTime date = start.AddMilliseconds(i).ToLocalTime();
                                smsList.Add(new InboxSms
                                {
                                    CuerpoMensaje = c.GetString(c.GetColumnIndexOrThrow("BODY")),
                                    FechaSms = date,
                                    Id = c.GetInt(c.GetColumnIndexOrThrow("_ID"))
                                });

                            }
                        }
                    }
                  
                }
                return smsList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}