namespace MovieCollection.TheMovieDatabase.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class PersonImageResult
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("profiles")]
        public List<Image> Profiles { get; set; }
    }
}
