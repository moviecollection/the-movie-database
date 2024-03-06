namespace MovieCollection.TheMovieDatabase.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class TVShowDetails : Response
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("original_name")]
        public string OriginalName { get; set; }

        [JsonProperty("vote_count")]
        public int VoteCount { get; set; }

        [JsonProperty("vote_average")]
        public double VoteAverage { get; set; }

        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }

        [JsonProperty("first_air_date")]
        public string FirstAirDate { get; set; }

        [JsonProperty("popularity")]
        public double Popularity { get; set; }

        [JsonProperty("original_language")]
        public string OriginalLanguage { get; set; }

        [JsonProperty("backdrop_path")]
        public string BackdropPath { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("origin_country")]
        public List<string> OriginCountry { get; set; }

        [JsonProperty("created_by")]
        public List<BaseCredit> CreatedBy { get; set; }

        [JsonProperty("episode_run_time")]
        public List<int> EpisodeRunTime { get; set; }

        [JsonProperty("genres")]
        public List<Genre> Genres { get; set; }

        [JsonProperty("homepage")]
        public Uri Homepage { get; set; }

        [JsonProperty("in_production")]
        public bool InProduction { get; set; }

        [JsonProperty("languages")]
        public List<string> Languages { get; set; }

        [JsonProperty("last_air_date")]
        public string LastAirDate { get; set; }

        [JsonProperty("last_episode_to_air")]
        public BaseEpisode LastEpisodeToAir { get; set; }

        [JsonProperty("next_episode_to_air")]
        public BaseEpisode NextEpisodeToAir { get; set; }

        [JsonProperty("networks")]
        public List<Organization> Networks { get; set; }

        [JsonProperty("number_of_episodes")]
        public int NumberOfEpisodes { get; set; }

        [JsonProperty("number_of_seasons")]
        public int NumberOfSeasons { get; set; }

        [JsonProperty("production_companies")]
        public List<Organization> ProductionCompanies { get; set; }

        [JsonProperty("seasons")]
        public List<BaseSeason> Seasons { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("credits")]
        public Credits Credits { get; set; }

        [JsonProperty("external_ids")]
        public TVShowExternalIds ExternalIds { get; set; }

        [JsonProperty("content_ratings")]
        public Items<ContentRatings> ContentRatings { get; set; }

        [JsonProperty("tagline")]
        public string Tagline { get; set; }
    }
}
