using MoviesApp.Models;
using MoviesApp.Services;
using MoviesApp.ViewModels.Base;
using Prism.Navigation;

namespace MoviesApp.ViewModels
{
    public class MovieDetailPageViewModel : ViewModelBase
    {
        private readonly IMovieService _movieService;

        public MovieDetailPageViewModel(INavigationService navigationService, IMovieService movieService) : base(navigationService)
        {
            _movieService = movieService;
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            IsBusy = true;

            Movie = (Movie)parameters["movie"];
            if (string.IsNullOrEmpty(_movie.GenreNames))
            {
                var genres = await _movieService.GetGenresAsync();
                if (genres != null)
                    Movie.GenreNames = _movie.GetGenreNames(_movie.GenreIds, genres);
            }

            GenreNames = _movie.GenreNames;

            IsBusy = false;
        }

        private string _genreNames;
        public string GenreNames
        {
            get => _genreNames;
            set => SetProperty(ref _genreNames, value);
        }

        private Movie _movie;
        public Movie Movie
        {
            get => _movie;
            set => SetProperty(ref _movie, value);
        }
    }
}
