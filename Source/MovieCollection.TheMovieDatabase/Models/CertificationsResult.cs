namespace MovieCollection.TheMovieDatabase.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class CertificationsResult : Response
    {
        [JsonProperty("certifications")]
        public Dictionary<string, List<Certification>> Certifications { get; set; }
    }
}
