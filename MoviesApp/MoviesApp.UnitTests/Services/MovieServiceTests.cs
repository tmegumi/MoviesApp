using System.Threading.Tasks;
using MoviesApp.Services;
using Xunit;

namespace MoviesApp.UnitTests.Services
{
    public class MovieServiceTests
    {
        [Fact]
        public async Task GetUpcomingMoviesTest()
        {
            // Arrange
            var movieService = new MovieService();

            // Act
            var movies = await movieService.GetUpcomingMoviesAsync(1);

            // Assert
            Assert.NotEmpty(movies);
        }

        [Fact]
        public async Task GetPopularMoviesTest()
        {
            // Arrange
            var movieService = new MovieService();

            // Act
            var movies = await movieService.GetPopularMoviesAsync();

            // Assert
            Assert.NotEmpty(movies);
        }

        [Fact]
        public async Task GetGenresTest()
        {
            // Arrange
            var movieService = new MovieService();

            // Act
            var genres = await movieService.GetGenresAsync();

            // Assert
            Assert.NotEmpty(genres);
        }

        [Theory]
        [InlineData("A")]
        [InlineData("Aven")]
        [InlineData("Avengers")]
        public async Task SearchMoviesTest(string query)
        {
            // Arrange
            var movieService = new MovieService();

            // Act
            var movies = await movieService.SearchMoviesAsync(query, 1);

            // Assert
            Assert.NotEmpty(movies);
        }
    }
}
