namespace MovieCollection.TheMovieDatabase
{
    /// <summary>
    /// The <c>TheMovieDatabaseOptions</c> class.
    /// </summary>
    public class TheMovieDatabaseOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TheMovieDatabaseOptions"/> class.
        /// </summary>
        public TheMovieDatabaseOptions()
            : base()
        {
            ApiAddress = "https://api.themoviedb.org/3";
            ImageAddress = "https://image.tmdb.org/t/p";
            ImageFallbackLanguages = "en,null";
            Language = "en-US";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TheMovieDatabaseOptions"/> class.
        /// </summary>
        /// <param name="apiKey">Your api key.</param>
        /// <param name="language">Desired language.</param>
        public TheMovieDatabaseOptions(string apiKey, string language = "en-US")
            : this()
        {
            ApiKey = apiKey;
            Language = language;
            IsAdultIncluded = false;
        }

        /// <summary>
        /// Gets or sets api base address.
        /// </summary>
        public string ApiAddress { get; set; }

        /// <summary>
        /// Gets or sets images base address.
        /// </summary>
        public string ImageAddress { get; set; }

        /// <summary>
        /// Gets or sets api key.
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Gets or sets language.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets image fallback languages. See remarks.
        /// </summary>
        /// <remarks>
        /// This should be a comma seperated value like: en,null.
        /// </remarks>
        public string ImageFallbackLanguages { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether adult content should be included in the results.
        /// </summary>
        public bool IsAdultIncluded { get; set; }
    }
}
