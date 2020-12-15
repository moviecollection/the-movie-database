namespace MovieCollection.TheMovieDatabase.Models
{
    using System;
    using Newtonsoft.Json;

    public class CompanyDetails : Organization
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("headquarters")]
        public string Headquarters { get; set; }

        [JsonProperty("homepage")]
        public Uri Homepage { get; set; }

        [JsonProperty("parent_company")]
        public Organization ParentCompany { get; set; }
    }
}
