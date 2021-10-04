namespace MovieCollection.TheMovieDatabase.Models
{
    using Newtonsoft.Json;

    public class PersonTVShowCredits : BasicCredits<PersonTVShowCast, PersonTVShowCrew>
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
