namespace MovieCollection.TheMovieDatabase.Models
{
    public class NewDiscoverMovie
    {
        /// <summary>
        /// Gets or sets the page of results to query.
        /// </summary>
        public int? Page { get; set; }

        /// <summary>
        /// Gets or sets a filter to limit the results to a specific primary release year.
        /// </summary>
        public int? PrimaryReleaseYear { get; set; }

        // TODO: Add the missing filters.
    }
}
