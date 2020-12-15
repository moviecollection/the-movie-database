namespace MovieCollection.TheMovieDatabase.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class Credits
    {
        [JsonProperty("cast")]
        public List<Cast> Cast { get; set; }

        [JsonProperty("crew")]
        public List<Crew> Crew { get; set; }
    }
}
