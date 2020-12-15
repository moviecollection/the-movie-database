namespace MovieCollection.TheMovieDatabase.Models
{
    using System;
    using Newtonsoft.Json;

    public class SeasonExternalIds
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("freebase_mid")]
        [Obsolete("Defunct or no longer available as a service.")]
        public string FreebaseMid { get; set; }

        [JsonProperty("freebase_id")]
        [Obsolete("Defunct or no longer available as a service.")]
        public string FreebaseId { get; set; }

        [JsonProperty("tvdb_id")]
        public int? TvdbId { get; set; }

        [JsonProperty("tvrage_id")]
        [Obsolete("Defunct or no longer available as a service.")]
        public int? TvrageId { get; set; }
    }
}
