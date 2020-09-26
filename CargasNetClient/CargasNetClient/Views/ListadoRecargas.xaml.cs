using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClaroNet3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListadoRecargas : ContentPage
    {
       
        public IList<Monkey> Monkeys { get; private set; }

        public ListadoRecargas()
        {
            InitializeComponent();

            Monkeys = new List<Monkey>();
          ;

            Monkeys.Add(new Monkey
            {
                Name = "+541163069305",
                Location = DateTime.Now.ToLongDateString(),
                ImageUrl = "checked"
            });

            Monkeys.Add(new Monkey
            {
                Name = "+541163069305",
                Location = DateTime.Now.ToLongDateString(),
                ImageUrl = "fail"
            }); Monkeys.Add(new Monkey
            {
                Name = "+541163069305",
                Location = DateTime.Now.ToLongDateString(),
                ImageUrl = "checked"
            });

            Monkeys.Add(new Monkey
            {
                Name = "+541163069305",
                Location = DateTime.Now.ToLongDateString(),
                ImageUrl = "fail"
            }); Monkeys.Add(new Monkey
            {
                Name = "+541163069305",
                Location = DateTime.Now.ToLongDateString(),
                ImageUrl = "checked"
            });

            Monkeys.Add(new Monkey
            {
                Name = "+541163069305",
                Location = DateTime.Now.ToLongDateString(),
                ImageUrl = "fail"
            }); Monkeys.Add(new Monkey
            {
                Name = "+541163069305",
                Location = DateTime.Now.ToLongDateString(),
                ImageUrl = "checked"
            });

            Monkeys.Add(new Monkey
            {
                Name = "+541163069305",
                Location = DateTime.Now.ToLongDateString(),
                ImageUrl = "fail"
            });


         
        }

    }



    public class Monkey
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string ImageUrl { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }


}