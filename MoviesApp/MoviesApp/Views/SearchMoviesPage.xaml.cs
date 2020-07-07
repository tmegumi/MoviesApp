using Xamarin.Forms;

namespace MoviesApp.Views
{
    public partial class SearchMoviesPage
    {
        private bool _isFirstAppearing = true;

        public SearchMoviesPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override void OnAppearing()
        {
            if (_isFirstAppearing)
            {
                EntrySearch.Focus();
                _isFirstAppearing = false;
            }
        }

        private void ListMovies_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListMovies.SelectedItem = null;
        }
    }
}