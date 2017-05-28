using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace DemoApp
{
    public partial class VotePage : ContentPage
    {
        public ObservableCollection<string> VoteOptions { get; }

        public VotePage()
        {
            VoteOptions = new ObservableCollection<string>{"Pizza", "Frietjes", "Kebab", "Pita", "Broodje gezond"};
            BindingContext = this;

            InitializeComponent();
        }

        async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem == null)
            {
                return;
            }

            var selected = (string)e.SelectedItem;

            var listView = (ListView)sender;
            listView.SelectedItem = null;

            await DisplayAlert("Gestemd!", $"We hebben je stem voor {selected} goed ontvangen.", "OK");

            await Navigation.PopAsync(true);
        }
    }
}
