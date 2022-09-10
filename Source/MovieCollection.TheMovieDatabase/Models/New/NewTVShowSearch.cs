namespace MovieCollection.TheMovieDatabase.Models
{
    public class NewTVShowSearch
    {
        /// <summary>
        /// Gets or sets the query to search.
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// Gets or sets a filter to only include TV shows that have a original air date year that equal to the specified value.
        /// </summary>
        public int? FirstAirDateYear { get; set; }

        /// <summary>
        /// Gets or sets the language.
        /// </summary>
        /// <remarks>
        /// An ISO 639-1 value to display translated data for the fields that support it.
        /// </remarks>
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the page of results to query.
        /// </summary>
        public int? Page { get; set; }

        // TODO: Add the missing filters.
    }
}
