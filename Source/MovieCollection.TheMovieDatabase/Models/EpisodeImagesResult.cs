namespace MovieCollection.TheMovieDatabase.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class EpisodeImagesResult : Response
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("stills")]
        public List<Image> Stills { get; set; }
    }
}
