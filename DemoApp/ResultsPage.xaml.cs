using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DemoApp
{
    public partial class ResultsPage : ContentPage
    {
        public ObservableCollection<VoteResult> Results { get; }
        public ICommand RefreshCommand { get; }

        public ResultsPage()
        {
            InitializeComponent();
            Results = new ObservableCollection<VoteResult>();
            RefreshCommand = new Command(async () => await UpdateVotes());

            BindingContext = this;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ResultsList.IsRefreshing = true;
            UpdateVotes();
        }

        async Task UpdateVotes()
        {
            var voteService = new VoteService();
            var votes = await voteService.GetVotes();

            if (votes != null && votes.Count > 0)
            {
                Results.Clear();
                foreach (var result in votes)
                {
                    Results.Add(result);
                }
            }
            else
            {
                await DisplayAlert("Oeps...", "Het ophalen van de resulaten lukt even niet. Probeer het later opnieuw", "Terug");
                await Navigation.PopAsync(true);
            }

            ResultsList.IsRefreshing = false;
        }

        void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }
    }
}