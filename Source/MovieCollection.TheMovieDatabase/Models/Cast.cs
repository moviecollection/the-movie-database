namespace MovieCollection.TheMovieDatabase.Models
{
    using Newtonsoft.Json;

    public class Cast : BaseCredit
    {
        /// <summary>
        /// Gets or sets CastId for movies only. See remarks.
        /// </summary>
        /// <remarks>
        /// TV Shows cast does not provide <c>CastId</c> value.
        /// We used a shared class for both Movies and TV Shows for simplicity.
        /// </remarks>
        [JsonProperty("cast_id")]
        public int? CastId { get; set; }

        [JsonProperty("character")]
        public string Character { get; set; }

        [JsonProperty("order")]
        public int Order { get; set; }
    }
}
