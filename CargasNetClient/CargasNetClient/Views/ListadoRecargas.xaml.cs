using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CargasNetClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListadoRecargas : ContentPage
    {
        void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Monkey selectedItem = e.SelectedItem as Monkey;
        }

        void OnListViewItemTapped(object sender, ItemTappedEventArgs e)
        {
            Monkey tappedItem = e.Item as Monkey;
        }
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


            BindingContext = this;
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