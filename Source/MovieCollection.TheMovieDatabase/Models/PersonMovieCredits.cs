namespace MovieCollection.TheMovieDatabase.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class PersonMovieCredits
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("cast")]
        public List<PersonMovieCast> Cast { get; set; }

        [JsonProperty("crew")]
        public List<PersonMovieCrew> Crew { get; set; }
    }
}
