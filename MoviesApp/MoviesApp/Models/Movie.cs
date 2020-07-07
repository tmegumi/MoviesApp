using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace MoviesApp.Models
{
    public class Movie
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("backdrop_path")]
        public string BackdropPath { get; set; }

        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }

        [JsonProperty("genre_ids")]
        public int[] GenreIds { get; set; }

        [JsonProperty("release_date")]
        public DateTime ReleaseDate { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        public string GenreNames { get; set; }

        public string GetGenreNames(int[] genreIds, IEnumerable<Genre> genres)
        {
            var genreNames = string.Empty;
            var movieGenres = genres.Where(item => genreIds.Contains(item.Id));
            foreach (var genre in movieGenres)
            {
                genreNames += $" • {genre.Name}";
            }
            genreNames = genreNames.TrimStart(' ').TrimStart('•').TrimStart(' ');
            return genreNames;
        }
    }
}
