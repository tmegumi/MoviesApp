using Moq;
using MoviesApp.Services;
using MoviesApp.ViewModels;
using Prism.Navigation;
using Xunit;

namespace MoviesApp.UnitTests.ViewModels
{
    public class SearchMoviesPageViewModelTests
    {
        [Fact]
        public void CommandsAreNotNullWhenViewModelInstantiatedTest()
        {
            // Arrange
            var navigationMockService = new Mock<INavigationService>();
            var movieMockService = new Mock<IMovieService>();

            // Act
            var searchMoviesPageViewModel = new SearchMoviesPageViewModel(navigationMockService.Object, movieMockService.Object);

            // Assert
            Assert.NotNull(searchMoviesPageViewModel.ClearCommand);
            Assert.NotNull(searchMoviesPageViewModel.LoadMoreMoviesCommand);
            Assert.NotNull(searchMoviesPageViewModel.MovieDetailCommand);
            Assert.NotNull(searchMoviesPageViewModel.NavigateBackCommand);
            Assert.NotNull(searchMoviesPageViewModel.SearchMovieCommand);
        }
        

        [Fact]
        public void SearchTermPropertyIsNullAfterClearCommandExcecutedTest()
        {
            // Arrange
            var navigationMockService = new Mock<INavigationService>();
            var movieMockService = new Mock<IMovieService>();

            // Act
            var searchMoviesPageViewModel = new SearchMoviesPageViewModel(navigationMockService.Object, movieMockService.Object);
            searchMoviesPageViewModel.SearchTerm = "some term";
            searchMoviesPageViewModel.ClearCommand.Execute(null);

            // Assert
            Assert.True(string.IsNullOrEmpty(searchMoviesPageViewModel.SearchTerm));
        }
    }
}
