namespace MovieCollection.TheMovieDatabase.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class OrganizationImages : Response
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("logos")]
        public List<Image> Logos { get; set; }
    }
}
