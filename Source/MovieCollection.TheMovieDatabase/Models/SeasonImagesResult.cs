namespace MovieCollection.TheMovieDatabase.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class SeasonImagesResult : Response
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("posters")]
        public List<Image> Posters { get; set; }
    }
}
