using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MoviesApp.Models;
using MoviesApp.Services;
using MoviesApp.ViewModels.Base;
using Prism.Navigation;
using Xamarin.Forms;

namespace MoviesApp.ViewModels
{
    public class MoviesPageViewModel : ViewModelBase
    {
        private int _pageNumber;
        private bool _isListEnd;

        private readonly IMovieService _movieService;

        public MoviesPageViewModel(INavigationService navigationService, IMovieService movieService)
            : base(navigationService)
        {
            _movieService = movieService;
            _pageNumber = 1;
            _isListEnd = false;
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            await GetMovieGenresAsync();
            await LoadMoviesAsync();
        }

        #region Properties

        private IList<Movie> _movies;
        public IList<Movie> Movies
        {
            get => _movies;
            set => SetProperty(ref _movies, value);
        }

        private IList<Genre> _genres;
        public IList<Genre> Genres
        {
            get => _genres;
            set => SetProperty(ref _genres, value);
        }

        #endregion

        #region Commands

        private ICommand _loadMoreMoviesCommand;
        public ICommand LoadMoreMoviesCommand =>
            _loadMoreMoviesCommand ?? (_loadMoreMoviesCommand = new Command(async () => await LoadMoviesAsync()));

        private async Task LoadMoviesAsync()
        {
            if (_isListEnd || IsBusy)
                return;

            IsBusy = true;

            var movies = await _movieService.GetUpcomingMoviesAsync(_pageNumber);
            if (movies != null)
            {
                if (movies.Any())
                {
                    await LoadMoviesToViewAsync(movies);
                    _pageNumber++;
                }
                else _isListEnd = true;
            }

            IsBusy = false;
        }

        private ICommand _movieDetailCommand;
        public ICommand MovieDetailCommand =>
            _movieDetailCommand ?? (_movieDetailCommand = new Command<Movie>(async (movie) => await NavigateToMovieDetailAsync(movie)));

        private async Task NavigateToMovieDetailAsync(Movie movie)
        {
            if (movie == null)
                return;

            var navigationParams = new NavigationParameters { { "movie", movie } };
            await NavigationService.NavigateAsync("MovieDetailPage", navigationParams);
        }

        private ICommand _searchMovieCommand;
        public ICommand SearchMovieCommand =>
            _searchMovieCommand ?? (_searchMovieCommand = new Command(async () => await NavigateToSearchMoviesAsync()));

        private async Task NavigateToSearchMoviesAsync()
        {
            await NavigationService.NavigateAsync("SearchMoviesPage");
        }

        #endregion

        #region Methods

        private async Task GetMovieGenresAsync()
        {
            Genres = await _movieService.GetGenresAsync();
        }

        private Task LoadMoviesToViewAsync(IEnumerable<Movie> movies)
        {
            return Task.Run(async () =>
            {
                foreach (var movie in movies)
                {
                    movie.GenreNames = movie.GetGenreNames(movie.GenreIds, _genres);
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        if (_movies == null)
                            Movies = new List<Movie>();

                        Movies = _movies.Append(movie).ToList();
                    });
                    await Task.Delay(1);
                }
            });
        }

        #endregion
    }
}
