namespace MovieCollection.TheMovieDatabase.Models
{
    using System;
    using Newtonsoft.Json;

    public class NetworkDetails : Organization
    {
        [JsonProperty("headquarters")]
        public string Headquarters { get; set; }

        [JsonProperty("homepage")]
        public Uri Homepage { get; set; }
    }
}
