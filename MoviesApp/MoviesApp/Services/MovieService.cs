using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MoviesApp.Models;
using Newtonsoft.Json;

namespace MoviesApp.Services
{
    public class MovieService : IMovieService
    {
        public async Task<IList<Movie>> GetPopularMoviesAsync()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    const string requestUri = "https://api.themoviedb.org/3/movie/popular?language=en-US&api_key=1f54bd990f1cdfb230adb312546d765d";
                    var response = await httpClient.GetAsync(requestUri);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseBody = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<MovieRootObject>(responseBody);
                        return result.Results;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return null;
        }

        public async Task<IList<Movie>> GetUpcomingMoviesAsync(int pageNumber)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    const string requestUri = "https://api.themoviedb.org/3/movie/upcoming?language=en-US&api_key=1f54bd990f1cdfb230adb312546d765d";
                    var response = await httpClient.GetAsync($"{requestUri}&page={pageNumber}");
                    if (response.IsSuccessStatusCode)
                    {
                        var responseBody = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<MovieRootObject>(responseBody);
                        return result.Results;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return null;
        }

        public async Task<IList<Genre>> GetGenresAsync()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    const string requestUri = "https://api.themoviedb.org/3/genre/movie/list?language=en-US&api_key=1f54bd990f1cdfb230adb312546d765d";
                    var response = await httpClient.GetAsync(requestUri);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseBody = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<GenreRootObject>(responseBody);
                        return result.Genres;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return null;
        }

        public async Task<IList<Movie>> SearchMoviesAsync(string query, int pageNumber)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    const string requestUri = "https://api.themoviedb.org/3/search/movie?language=en-US&api_key=1f54bd990f1cdfb230adb312546d765d&include_adult=false";
                    var response = await httpClient.GetAsync($"{requestUri}&page={pageNumber}&query={query}");
                    if (response.IsSuccessStatusCode)
                    {
                        var responseBody = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<MovieRootObject>(responseBody);
                        return result.Results;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return null;
        }
    }
}
