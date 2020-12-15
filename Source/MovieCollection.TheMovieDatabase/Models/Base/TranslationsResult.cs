namespace MovieCollection.TheMovieDatabase.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class TranslationsResult<TData>
        where TData : class
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("translations")]
        public List<Translation<TData>> Translations { get; set; }
    }
}
