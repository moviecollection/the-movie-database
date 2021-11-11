namespace MovieCollection.TheMovieDatabase
{
    using System;
    using MovieCollection.TheMovieDatabase.Models;

    /// <summary>
    /// Internal extensions for enums.
    /// </summary>
    internal static class EnumExtensions
    {
        /// <summary>
        /// Gets the actual sort by value from <see cref="NewDiscoverMovie"/>.
        /// </summary>
        /// <param name="discover">The discover movie instance.</param>
        /// <returns>A string value specific to the service.</returns>
        public static string GetSortByValue(this NewDiscoverMovie discover)
        {
            string value = discover.SortBy switch
            {
                NewDiscoverMovie.SortOptions.Popularity => "popularity",
                NewDiscoverMovie.SortOptions.ReleaseDate => "release_date",
                NewDiscoverMovie.SortOptions.Revenue => "revenue",
                NewDiscoverMovie.SortOptions.PrimaryReleaseDate => "primary_release_date",
                NewDiscoverMovie.SortOptions.OriginalTitle => "original_title",
                NewDiscoverMovie.SortOptions.VoteAverage => "vote_average",
                NewDiscoverMovie.SortOptions.VoteCount => "vote_count",
                _ => throw new NotImplementedException(),
            };

            return GetStringValueWithDirection(value, discover.IsSortByAscending);
        }

        /// <summary>
        /// Gets the actual sort by value from <see cref="NewDiscoverTVShow"/>.
        /// </summary>
        /// <param name="discover">The discover tv show instance.</param>
        /// <returns>A string value specific to the service.</returns>
        public static string GetSortByValue(this NewDiscoverTVShow discover)
        {
            string value = discover.SortBy switch
            {
                NewDiscoverTVShow.SortOptions.Popularity => "popularity",
                NewDiscoverTVShow.SortOptions.VoteAverage => "vote_average",
                NewDiscoverTVShow.SortOptions.FirstAirDate => "first_air_date",
                _ => throw new NotImplementedException(),
            };

            return GetStringValueWithDirection(value, discover.IsSortByAscending);
        }

        private static string GetStringValueWithDirection(string value, bool isAscending)
        {
            if (isAscending)
            {
                return $"{value}.asc";
            }

            return $"{value}.desc";
        }
    }
}
