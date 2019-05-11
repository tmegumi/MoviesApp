using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using MoviesApp.Models;
using MoviesApp.Services;
using MoviesApp.ViewModels;
using Prism.Navigation;
using Xunit;

namespace MoviesApp.UnitTests.ViewModels
{
    public class MoviesPageViewModelTests
    {
        [Fact]
        public void CommandsAreNotNullWhenViewModelInstantiatedTest()
        {
            // Arrange
            var navigationMockService = new Mock<INavigationService>();
            var movieMockService = new Mock<IMovieService>();

            // Act
            var moviesPageViewModel = new MoviesPageViewModel(navigationMockService.Object, movieMockService.Object);

            // Assert
            Assert.NotNull(moviesPageViewModel.MovieDetailCommand);
            Assert.NotNull(moviesPageViewModel.SearchMovieCommand);
            Assert.NotNull(moviesPageViewModel.LoadMoreMoviesCommand);
        }

        [Fact]
        public void MoviesPropertyIsNullWhenViewModelInstantiatedTest()
        {
            // Arrange
            var navigationMockService = new Mock<INavigationService>();
            var movieMockService = new Mock<IMovieService>();

            // Act
            var moviesPageViewModel = new MoviesPageViewModel(navigationMockService.Object, movieMockService.Object);

            // Assert
            Assert.Null(moviesPageViewModel.Movies);
        }

        [Fact]
        public void GenresPropertyIsNullWhenViewModelInstantiatedTest()
        {
            // Arrange
            var navigationMockService = new Mock<INavigationService>();
            var movieMockService = new Mock<IMovieService>();

            // Act
            var moviesPageViewModel = new MoviesPageViewModel(navigationMockService.Object, movieMockService.Object);

            // Assert
            Assert.Null(moviesPageViewModel.Genres);
        }

        [Fact]
        public void MovieDetailCommandCanBeExecutedAlwaysTest()
        {
            // Arrange
            var navigationMockService = new Mock<INavigationService>();
            var movieMockService = new Mock<IMovieService>();
            var movie = new Movie
            {
                Title = "Title",
                GenreIds = new[] { 1, 2, 3 },
                BackdropPath = "backdroppath.jpg",
                Overview = "Overview about movie",
                PosterPath = "posterpath.jpg",
                ReleaseDate = DateTime.Now
            };

            // Act
            var moviesPageViewModel = new MoviesPageViewModel(navigationMockService.Object, movieMockService.Object);
            moviesPageViewModel.Movies = new List<Movie>();

            // Assert
            Assert.True(moviesPageViewModel.MovieDetailCommand.CanExecute(null));
            Assert.True(moviesPageViewModel.MovieDetailCommand.CanExecute(new Movie()));

            moviesPageViewModel.Movies.Add(movie);
            Assert.True(moviesPageViewModel.MovieDetailCommand.CanExecute(movie));
        }

        [Fact]
        public void SearchMovieCommandCanBeExecutedAlwaysTest()
        {
            // Arrange
            var navigationMockService = new Mock<INavigationService>();
            var movieMockService = new Mock<IMovieService>();

            // Act
            var moviesPageViewModel = new MoviesPageViewModel(navigationMockService.Object, movieMockService.Object);

            // Assert
            Assert.True(moviesPageViewModel.SearchMovieCommand.CanExecute(null));
        }

        [Fact]
        public void LoadMoreMoviesCommandCanBeExecutedAlwaysTest()
        {
            // Arrange
            var navigationMockService = new Mock<INavigationService>();
            var movieMockService = new Mock<IMovieService>();

            // Act
            var moviesPageViewModel = new MoviesPageViewModel(navigationMockService.Object, movieMockService.Object);

            // Assert
            Assert.True(moviesPageViewModel.LoadMoreMoviesCommand.CanExecute(null));
        }
    }
}
