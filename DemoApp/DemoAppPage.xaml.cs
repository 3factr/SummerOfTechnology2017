using System;
using Xamarin.Forms;

namespace DemoApp
{
    public partial class DemoAppPage : ContentPage
    {
        public DemoAppPage()
        {
            InitializeComponent();
        }

        void BtVotePage_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Stempagina", "We moeten de stempagina nog maken!", "Oké, ik probeer later opnieuw");
        }
    }
}
