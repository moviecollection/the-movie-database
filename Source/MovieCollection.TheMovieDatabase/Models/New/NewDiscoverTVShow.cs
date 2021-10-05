namespace MovieCollection.TheMovieDatabase.Models
{
    public class NewDiscoverTVShow
    {
        /// <summary>
        /// Gets or sets the page of results to query.
        /// </summary>
        public int? Page { get; set; }

        /// <summary>
        /// Gets or sets a filter to only include TV shows that have a original air date year that equal to the specified value.
        /// </summary>
        /// <remarks>
        /// Can be used in conjunction with the "include_null_first_air_dates" filter if you want to include items with no air date.
        /// </remarks>
        public int? FirstAirDateYear { get; set; }

        /// <summary>
        /// Gets or sets a filter to include TV shows that don't have an air date while using any of the "first_air_date" filters.
        /// </summary>
        public bool? IncludeNullFirstAirDates { get; set; }

        // TODO: Add the missing filters.
    }
}
