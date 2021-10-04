namespace MovieCollection.TheMovieDatabase.Models
{
    using Newtonsoft.Json;

    public class PersonCombinedCredits : BasicCredits<PersonCombinedCast, PersonCombinedCrew>
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
