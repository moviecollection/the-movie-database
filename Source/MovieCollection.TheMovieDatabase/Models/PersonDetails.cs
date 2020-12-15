﻿namespace MovieCollection.TheMovieDatabase.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class PersonDetails : BasePerson
    {
        [JsonProperty("birthday")]
        public string Birthday { get; set; }

        /// <summary>
        /// Gets or sets known for department. See remarks.
        /// </summary>
        /// <remarks>
        /// Be advised <see cref="TheMovieDatabaseService.GetLatestMovieAsync" /> does not provide this value.
        /// </remarks>
        [JsonProperty("known_for_department")]
        public string KnownForDepartment { get; set; }

        [JsonProperty("deathday")]
        public string Deathday { get; set; }

        [JsonProperty("also_known_as")]
        public List<string> AlsoKnownAs { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("biography")]
        public string Biography { get; set; }

        [JsonProperty("place_of_birth")]
        public string PlaceOfBirth { get; set; }

        [JsonProperty("imdb_id")]
        public string ImdbId { get; set; }

        [JsonProperty("homepage")]
        public string Homepage { get; set; }
    }
}
