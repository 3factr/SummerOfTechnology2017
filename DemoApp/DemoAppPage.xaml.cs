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
            Navigation.PushAsync(new VotePage(), true);
        }

        void BtResultsPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ResultsPage(), true);
        }
    }
}
