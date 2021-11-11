namespace MovieCollection.TheMovieDatabase.Models
{
    using System.Collections.Generic;

    public class NewDiscoverMovie
    {
        /// <summary>
        /// The discover movie sort options.
        /// </summary>
        public enum SortOptions
        {
            Popularity,
            ReleaseDate,
            Revenue,
            PrimaryReleaseDate,
            OriginalTitle,
            VoteAverage,
            VoteCount,
        }

        /// <summary>
        /// Gets or sets the sort options.
        /// </summary>
        public SortOptions? SortBy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether movies should be sort by ascending (false by default).
        /// </summary>
        /// <remarks>
        /// Should be used with the <seealso cref="SortBy"/> property.
        /// </remarks>
        public bool IsSortByAscending { get; set; }

        /// <summary>
        /// Gets or sets the page of results to query.
        /// </summary>
        public int? Page { get; set; }

        /// <summary>
        /// Gets or sets a filter to limit the results to a specific primary release year.
        /// </summary>
        public int? PrimaryReleaseYear { get; set; }

        /// <summary>
        /// Gets or sets a filter to limit the results to a specific year (looking at all release dates).
        /// </summary>
        public int? Year { get; set; }

        /// <summary>
        /// Gets or sets the genre ids that you want to include in the results.
        /// </summary>
        public List<int> WithGenreIds { get; set; }

        /// <summary>
        /// Gets or sets the genre ids that you want to exclude from the results.
        /// </summary>
        public List<int> WithoutGenreIds { get; set; }

        // TODO: Add the missing filters.
    }
}
