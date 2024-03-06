namespace MovieCollection.TheMovieDatabase.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class PersonCombinedCredits : Response
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("cast")]
        public List<PersonCombinedCast> Cast { get; set; }

        [JsonProperty("crew")]
        public List<PersonCombinedCrew> Crew { get; set; }
    }
}
