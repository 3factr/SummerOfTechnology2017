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
    }
}
