namespace MovieCollection.TheMovieDatabase.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class EpisodeDetails : BaseEpisode
    {
        [JsonProperty("crew")]
        public List<Crew> Crew { get; set; }

        [JsonProperty("guest_stars")]
        public List<Cast> GuestStars { get; set; }
    }
}
