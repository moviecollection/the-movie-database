namespace MovieCollection.TheMovieDatabase.Models
{
    public class NewSearchMovie
    {
        /// <summary>
        /// Gets or sets the query to search.
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        public int? Year { get; set; }

        /// <summary>
        /// Gets or sets the primary release year.
        /// </summary>
        public int? PrimaryReleaseYear { get; set; }

        /// <summary>
        /// Gets or sets the language.
        /// </summary>
        /// <remarks>
        /// An ISO 639-1 value to display translated data for the fields that support it.
        /// </remarks>
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the region to filter release dates.
        /// </summary>
        /// <remarks>
        /// An ISO 3166-1 code to filter release dates. Must be uppercase.
        /// </remarks>
        public string Region { get; set; }

        /// <summary>
        /// Gets or sets the page of results to query.
        /// </summary>
        public int? Page { get; set; }

        // TODO: Add the missing filters.
    }
}
