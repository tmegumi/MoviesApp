using System.Collections.Generic;
using Newtonsoft.Json;

namespace MoviesApp.Models
{
    public class MovieRootObject
    {
        [JsonProperty("results")]
        public IList<Movie> Results { get; set; }
    }
}
