using System.Collections.Generic;
using Newtonsoft.Json;

namespace MoviesApp.Models
{
    public class GenreRootObject
    {
        [JsonProperty("genres")]
        public IList<Genre> Genres { get; set; }
    }
}
