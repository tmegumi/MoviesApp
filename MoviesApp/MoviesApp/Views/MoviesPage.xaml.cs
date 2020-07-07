using Xamarin.Forms;

namespace MoviesApp.Views
{
    public partial class MoviesPage
    {
        public MoviesPage()
        {
            InitializeComponent();
        }

        private void ListMovies_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListMovies.SelectedItem = null;
        }
    }
}