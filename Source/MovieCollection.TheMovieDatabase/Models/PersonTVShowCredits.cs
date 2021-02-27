namespace MovieCollection.TheMovieDatabase.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class PersonTVShowCredits
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("cast")]
        public List<PersonTVShowCast> Cast { get; set; }

        [JsonProperty("crew")]
        public List<PersonTVShowCrew> Crew { get; set; }
    }
}
