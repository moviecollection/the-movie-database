namespace MovieCollection.TheMovieDatabase
{
    using System.Net.Http.Headers;

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
        /// Gets or sets the api endpoint.
        /// </summary>
        public string ApiAddress { get; set; }

        /// <summary>
        /// Gets or sets the images endpoint.
        /// </summary>
        public string ImageAddress { get; set; }

        /// <summary>
        /// Gets or sets the api key.
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Gets or sets the default language.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the image fallback languages.
        /// </summary>
        /// <remarks>
        /// This should be a comma seperated value like: en,null.
        /// </remarks>
        public string ImageFallbackLanguages { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether adult content should be included in the results.
        /// </summary>
        public bool? IsAdultIncluded { get; set; }

        /// <summary>
        /// Gets or sets the name (and version) of the product using this library.
        /// </summary>
        /// <remarks>
        /// This overrides the <see cref="System.Net.Http.HttpClient.DefaultRequestHeaders"/>.
        /// </remarks>
        public ProductHeaderValue ProductInformation { get; set; }
    }
}
