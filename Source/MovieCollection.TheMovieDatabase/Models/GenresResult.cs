﻿namespace MovieCollection.TheMovieDatabase.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class GenresResult : Response
    {
        [JsonProperty("genres")]
        public List<Genre> Genres { get; set; }
    }
}
