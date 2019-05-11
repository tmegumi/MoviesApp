using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using MoviesApp.Models;
using MoviesApp.Services;
using MoviesApp.ViewModels;
using Prism.Navigation;
using Xunit;

namespace MoviesApp.UnitTests.ViewModels
{
    public class MovieDetailPageViewModelTests
    {
        [Fact]
        public void MoviePropertyIsNullWhenViewModelInstantiatedTest()
        {
            // Arrange
            var navigationMockService = new Mock<INavigationService>();
            var movieMockService = new Mock<IMovieService>();

            // Act
            var movieDetailPageViewModel = new MovieDetailPageViewModel(navigationMockService.Object, movieMockService.Object);

            // Assert
            Assert.Null(movieDetailPageViewModel.Movie);
        }

        [Fact]
        public void MoviePropertyIsNotNullWhenOnNavigatedToViewModelTest()
        {
            // Arrange
            var navigationMockService = new Mock<INavigationService>();
            var movieMockService = new Mock<IMovieService>();
            var movie = new Movie
            {
                Title = "Title",
                GenreIds = new[] { 1, 2, 3 },
                GenreNames = "Adventure",
                BackdropPath = "backdroppath.jpg",
                Overview = "Overview about movie",
                PosterPath = "posterpath.jpg",
                ReleaseDate = DateTime.Now
            };
            var navigationParams = new NavigationParameters { { "movie", movie } };

            // Act
            var movieDetailPageViewModel = new MovieDetailPageViewModel(navigationMockService.Object, movieMockService.Object);
            movieDetailPageViewModel.OnNavigatedTo(navigationParams);

            // Assert
            Assert.NotNull(movieDetailPageViewModel.Movie);
        }
    }
}
