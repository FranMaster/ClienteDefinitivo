﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using static ClaroNet3.Model.EventsUtilities;

namespace ClaroNet3.Model
{
    public static class Utilities
    {
        private static readonly object cc = new object();
        public static void Subscribe<TArgs>(this object subscriber, Events eventSubscribed, Action<TArgs> callBack)
        {
            MessagingCenter.Subscribe(subscriber, eventSubscribed.ToString(), new Action<object, TArgs>((e, a) => { callBack(a); }));
        }
        public static void Notify<TArgs>(Events eventNotified, TArgs argument)
        {
            MessagingCenter.Send(cc, eventNotified.ToString(), argument);
        }

    }
}
