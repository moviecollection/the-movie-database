namespace MovieCollection.TheMovieDatabase.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class EpisodeCreditsResult : CreditsResult
    {
        [JsonProperty("guest_stars")]
        public List<Cast> GuestStars { get; set; }
    }
}
