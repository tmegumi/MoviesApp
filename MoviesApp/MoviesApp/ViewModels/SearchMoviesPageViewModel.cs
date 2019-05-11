using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Input;
using MoviesApp.Models;
using MoviesApp.Services;
using MoviesApp.ViewModels.Base;
using Prism.Navigation;
using Xamarin.Forms;

namespace MoviesApp.ViewModels
{
    public class SearchMoviesPageViewModel : ViewModelBase
    {
        private int _pageNumber;
        private bool _isListEnd;

        private readonly IMovieService _movieService;

        public SearchMoviesPageViewModel(INavigationService navigationService, IMovieService movieService)
            : base(navigationService)
        {
            _movieService = movieService;
            _pageNumber = 1;
            _isListEnd = false;
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            IsBusy = true;

            var movies = await GetPopularMoviesAsync();
            if (movies != null) await LoadMoviesToViewAsync(movies);

            IsBusy = false;
        }

        #region Properties

        private IList<Movie> _movies;
        public IList<Movie> Movies
        {
            get => _movies;
            set => SetProperty(ref _movies, value);
        }

        private string _searchTerm;
        public string SearchTerm
        {
            get => _searchTerm;
            set => SetProperty(ref _searchTerm, value);
        }

        private bool _isSearchBusy;
        public bool IsSearchBusy
        {
            get => _isSearchBusy;
            set => SetProperty(ref _isSearchBusy, value);
        }

        #endregion

        #region Commands

        private ICommand _searchMovieCommand;
        public ICommand SearchMovieCommand =>
            _searchMovieCommand ?? (_searchMovieCommand = new Command(async () => await SearchMovieAsync()));

        private async Task SearchMovieAsync()
        {
            IsSearchBusy = true;

            ResetList();

            IList<Movie> movies;
            if (string.IsNullOrEmpty(_searchTerm))
            {
                movies = await _movieService.GetPopularMoviesAsync();
            }
            else
            {
                movies = await GetMoviesBySearchTermAsync();
            }

            if (movies != null)
            {
                if (movies.Any())
                {
                    await LoadMoviesToViewAsync(movies);
                    _pageNumber++;
                }
                else _isListEnd = true;
            }

            IsSearchBusy = false;
        }

        private ICommand _loadMoreMoviesCommand;
        public ICommand LoadMoreMoviesCommand =>
            _loadMoreMoviesCommand ?? (_loadMoreMoviesCommand = new Command(async () => await LoadMoviesAsync()));

        private async Task LoadMoviesAsync()
        {
            if (_isListEnd || IsBusy)
                return;

            IsBusy = true;

            var movies = await GetMoviesBySearchTermAsync();
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

        private ICommand _navigateBackCommand;
        public ICommand NavigateBackCommand =>
            _navigateBackCommand ?? (_navigateBackCommand = new Command(async () => await GoBackAsync()));

        private async Task GoBackAsync()
        {
            await NavigationService.GoBackAsync();
        }

        private ICommand _clearCommand;
        public ICommand ClearCommand =>
            _clearCommand ?? (_clearCommand = new Command(ClearSearchTerm));

        private void ClearSearchTerm()
        {
            SearchTerm = string.Empty;
        }

        #endregion

        #region Methods

        private void ResetList()
        {
            _pageNumber = 1;
            _isListEnd = false;
            _movies = null;
        }

        private async Task<IList<Movie>> GetPopularMoviesAsync()
        {
            return await _movieService.GetPopularMoviesAsync();
        }

        private async Task<IList<Movie>> GetMoviesBySearchTermAsync()
        {
            var searchTermEncoded = HttpUtility.UrlEncode(_searchTerm);
            return await _movieService.SearchMoviesAsync(searchTermEncoded, _pageNumber);
        }

        private Task LoadMoviesToViewAsync(IList<Movie> movies)
        {
            return Task.Run(async () =>
            {
                foreach (var movie in movies)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        if (_movies == null)
                            _movies = new List<Movie>();

                        Movies = _movies.Append(movie).ToList();
                    });
                    await Task.Delay(1);
                }
            });
        }

        #endregion
    }
}
