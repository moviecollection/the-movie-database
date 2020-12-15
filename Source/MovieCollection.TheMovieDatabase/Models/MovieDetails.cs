namespace MovieCollection.TheMovieDatabase.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class MovieDetails : BaseMovie
    {
        [JsonProperty("belongs_to_collection")]
        public Collection BelongsToCollection { get; set; }

        [JsonProperty("budget")]
        public int Budget { get; set; }

        [JsonProperty("genres")]
        public List<Genre> Genres { get; set; }

        [JsonProperty("homepage")]
        public Uri Homepage { get; set; }

        [JsonProperty("imdb_id")]
        public string ImdbId { get; set; }

        [JsonProperty("production_companies")]
        public List<Organization> ProductionCompanies { get; set; }

        [JsonProperty("production_countries")]
        public List<ProductionCountry> ProductionCountries { get; set; }

        [JsonProperty("revenue")]
        public string Revenue { get; set; }

        [JsonProperty("runtime")]
        public int? Runtime { get; set; }

        [JsonProperty("spoken_languages")]
        public List<SpokenLanguage> SpokenLanguages { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("tagline")]
        public string Tagline { get; set; }

        [JsonProperty("credits")]
        public Credits Credits { get; set; }

        [JsonProperty("release_dates")]
        public BasicResult<ReleaseDatesResult> ReleaseDates { get; set; }
    }
}
