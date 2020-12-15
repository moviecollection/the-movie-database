namespace MovieCollection.TheMovieDatabase.Models
{
    using Newtonsoft.Json;

    public class SearchPeople : Person
    {
        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("known_for_department")]
        public string KnownForDepartment { get; set; }
    }
}
