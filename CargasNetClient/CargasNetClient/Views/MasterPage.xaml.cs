using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClaroNet3.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : MasterDetailPage
    {
        public MasterPage()
        {
            InitializeComponent();
            _instance = this;
        }

        private static MasterPage _instance;

        public static MasterPage Instance
        {
            get {

                if (_instance==null)
                {
                    _instance = new MasterPage();
                }
                
                return  _instance; }
    
        }


    }
}