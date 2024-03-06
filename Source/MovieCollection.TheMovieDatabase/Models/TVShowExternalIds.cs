namespace MovieCollection.TheMovieDatabase.Models
{
    using System;
    using Newtonsoft.Json;

    public class TVShowExternalIds
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("imdb_id")]
        public string ImdbId { get; set; }

        [JsonProperty("facebook_id")]
        public string FacebookId { get; set; }

        [JsonProperty("instagram_id")]
        public string InstagramId { get; set; }

        [JsonProperty("twitter_id")]
        public string TwitterId { get; set; }

        [JsonProperty("freebase_mid")]
        [Obsolete("Defunct or no longer available as a service.")]
        public string FreebaseMid { get; set; }

        [JsonProperty("freebase_id")]
        [Obsolete("Defunct or no longer available as a service.")]
        public string FreebaseId { get; set; }

        [JsonProperty("tvdb_id")]
        public int? TvdbId { get; set; }

        [JsonProperty("tvrage_id")]
        public int? TvrageId { get; set; }
    }
}
