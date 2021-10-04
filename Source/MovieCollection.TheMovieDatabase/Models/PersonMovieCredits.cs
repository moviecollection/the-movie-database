namespace MovieCollection.TheMovieDatabase.Models
{
    using Newtonsoft.Json;

    public class PersonMovieCredits : BasicCredits<PersonMovieCast, PersonMovieCrew>
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
