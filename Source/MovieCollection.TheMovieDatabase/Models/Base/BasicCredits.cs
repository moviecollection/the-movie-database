namespace MovieCollection.TheMovieDatabase.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class BasicCredits<TCast, TCrew>
        where TCast : class
        where TCrew : class
    {
        [JsonProperty("cast")]
        public List<TCast> Cast { get; set; }

        [JsonProperty("crew")]
        public List<TCrew> Crew { get; set; }
    }
}
