namespace MovieCollection.TheMovieDatabase.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class ImagesResult : Response
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("backdrops")]
        public List<Image> Backdrops { get; set; }

        [JsonProperty("posters")]
        public List<Image> Posters { get; set; }
    }
}
