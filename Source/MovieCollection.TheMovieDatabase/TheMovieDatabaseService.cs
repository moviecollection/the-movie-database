namespace MovieCollection.TheMovieDatabase
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    using MovieCollection.TheMovieDatabase.Enums;
    using MovieCollection.TheMovieDatabase.Models;
    using Newtonsoft.Json;

    /// <summary>
    /// The <c>TheMovieDatabaseService</c> Class.
    /// </summary>
    public class TheMovieDatabaseService
    {
        private readonly HttpClient _httpClient;
        private readonly TheMovieDatabaseOptions _options;

        /// <summary>
        /// Initializes a new instance of the <see cref="TheMovieDatabaseService"/> class.
        /// </summary>
        /// <param name="httpClient">An instance of <see cref="HttpClient"/>.</param>
        /// <param name="options">An instance of <see cref="TheMovieDatabaseOptions"/>.</param>
        public TheMovieDatabaseService(HttpClient httpClient, TheMovieDatabaseOptions options)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _options = options ?? throw new ArgumentNullException(nameof(options));

            if (string.IsNullOrWhiteSpace(_options.ApiAddress))
            {
                throw new ArgumentException($"'{nameof(_options.ApiAddress)}' cannot be null or whitespace.", nameof(options));
            }

            if (string.IsNullOrWhiteSpace(_options.ImageAddress))
            {
                throw new ArgumentException($"'{nameof(_options.ImageAddress)}' cannot be null or whitespace.", nameof(options));
            }

            if (string.IsNullOrWhiteSpace(_options.ApiKey))
            {
                throw new ArgumentException($"'{nameof(_options.ApiKey)}' cannot be null or whitespace.", nameof(options));
            }
        }

        /// <summary>
        /// Gets the account details by session id.
        /// </summary>
        /// <param name="sessionId">A valid session id.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<AccountDetails> GetAccountDetailsAsync(string sessionId)
        {
            if (string.IsNullOrWhiteSpace(sessionId))
            {
                throw new ArgumentException($"'{nameof(sessionId)}' cannot be null or whitespace.", nameof(sessionId));
            }

            var parameters = new Dictionary<string, object>()
            {
                ["session_id"] = sessionId,
            };

            return GetJsonAsync<AccountDetails>("/account", parameters);
        }

        // TODO: Account: GetAccountCreatedLists

        /// <summary>
        /// Get the list of your favorite movies.
        /// </summary>
        /// <param name="accountId">The account id.</param>
        /// <param name="sessionId">A valid session id.</param>
        /// <param name="page">The page number to query.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<PagedResult<Movie>> GetAccountFavoriteMoviesAsync(int accountId, string sessionId, int? page = null)
        {
            if (string.IsNullOrWhiteSpace(sessionId))
            {
                throw new ArgumentException($"'{nameof(sessionId)}' cannot be null or whitespace.", nameof(sessionId));
            }

            var parameters = new Dictionary<string, object>()
            {
                ["session_id"] = sessionId,
            };

            // TODO: Add sort by parameter.
            if (page.HasValue)
            {
                parameters.Add("page", page.Value);
            }

            return GetJsonAsync<PagedResult<Movie>>($"/account/{accountId}/favorite/movies", parameters);
        }

        /// <summary>
        /// Get the list of your favorite tv shows.
        /// </summary>
        /// <param name="accountId">The account id.</param>
        /// <param name="sessionId">A valid session id.</param>
        /// <param name="page">The page number to query.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<PagedResult<TVShow>> GetAccountFavoriteTVShowsAsync(int accountId, string sessionId, int? page = null)
        {
            if (string.IsNullOrWhiteSpace(sessionId))
            {
                throw new ArgumentException($"'{nameof(sessionId)}' cannot be null or whitespace.", nameof(sessionId));
            }

            var parameters = new Dictionary<string, object>()
            {
                ["session_id"] = sessionId,
            };

            // TODO: Add sort by parameter.
            if (page.HasValue)
            {
                parameters.Add("page", page.Value);
            }

            return GetJsonAsync<PagedResult<TVShow>>($"/account/{accountId}/favorite/tv", parameters);
        }

        /// <summary>
        /// Mark a movie as a favorite item.
        /// </summary>
        /// <param name="movieId">The id of the movie.</param>
        /// <param name="isFavorite">The value indicating whether the movie is favorite.</param>
        /// <param name="accountId">The account id.</param>
        /// <param name="sessionId">A valid session id.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<Response> SetMovieFavoriteAsync(int movieId, bool isFavorite, int accountId, string sessionId)
        {
            if (string.IsNullOrWhiteSpace(sessionId))
            {
                throw new ArgumentException($"'{nameof(sessionId)}' cannot be null or whitespace.", nameof(sessionId));
            }

            var parameters = new Dictionary<string, object>()
            {
                ["session_id"] = sessionId,
            };

            var request = new
            {
                media_type = "movie",
                media_id = movieId,
                favorite = isFavorite,
            };

            return PostJsonAsync<Response>($"/account/{accountId}/favorite", parameters, request);
        }

        /// <summary>
        /// Mark a tv show as a favorite item.
        /// </summary>
        /// <param name="tvShowId">The id of the tv show.</param>
        /// <param name="isFavorite">The value indicating whether the tv show is favorite.</param>
        /// <param name="accountId">The account id.</param>
        /// <param name="sessionId">A valid session id.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<Response> SetTVShowFavoriteAsync(int tvShowId, bool isFavorite, int accountId, string sessionId)
        {
            if (string.IsNullOrWhiteSpace(sessionId))
            {
                throw new ArgumentException($"'{nameof(sessionId)}' cannot be null or whitespace.", nameof(sessionId));
            }

            var parameters = new Dictionary<string, object>()
            {
                ["session_id"] = sessionId,
            };

            var request = new
            {
                media_type = "tv",
                media_id = tvShowId,
                favorite = isFavorite,
            };

            return PostJsonAsync<Response>($"/account/{accountId}/favorite", parameters, request);
        }

        /// <summary>
        /// Get a list of all the movies you have rated.
        /// </summary>
        /// <param name="accountId">The account id.</param>
        /// <param name="sessionId">A valid session id.</param>
        /// <param name="page">The page number to query.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<PagedResult<RatedMovie>> GetAccountRatedMoviesAsync(int accountId, string sessionId, int? page = null)
        {
            if (string.IsNullOrWhiteSpace(sessionId))
            {
                throw new ArgumentException($"'{nameof(sessionId)}' cannot be null or whitespace.", nameof(sessionId));
            }

            var parameters = new Dictionary<string, object>()
            {
                ["session_id"] = sessionId,
            };

            // TODO: Add sort by parameter.
            if (page.HasValue)
            {
                parameters.Add("page", page.Value);
            }

            return GetJsonAsync<PagedResult<RatedMovie>>($"/account/{accountId}/rated/movies", parameters);
        }

        /// <summary>
        /// Get a list of all the tv shows you have rated.
        /// </summary>
        /// <param name="accountId">The account id.</param>
        /// <param name="sessionId">A valid session id.</param>
        /// <param name="page">The page number to query.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<PagedResult<RatedTVShow>> GetAccountRatedTVShowsAsync(int accountId, string sessionId, int? page = null)
        {
            if (string.IsNullOrWhiteSpace(sessionId))
            {
                throw new ArgumentException($"'{nameof(sessionId)}' cannot be null or whitespace.", nameof(sessionId));
            }

            var parameters = new Dictionary<string, object>()
            {
                ["session_id"] = sessionId,
            };

            // TODO: Add sort by parameter.
            if (page.HasValue)
            {
                parameters.Add("page", page.Value);
            }

            return GetJsonAsync<PagedResult<RatedTVShow>>($"/account/{accountId}/rated/tv", parameters);
        }

        /// <summary>
        /// Get a list of all the tv episodes you have rated.
        /// </summary>
        /// <param name="accountId">The account id.</param>
        /// <param name="sessionId">A valid session id.</param>
        /// <param name="page">The page number to query.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<PagedResult<RatedEpisode>> GetAccountRatedTVShowEpisodesAsync(int accountId, string sessionId, int? page = null)
        {
            if (string.IsNullOrWhiteSpace(sessionId))
            {
                throw new ArgumentException($"'{nameof(sessionId)}' cannot be null or whitespace.", nameof(sessionId));
            }

            var parameters = new Dictionary<string, object>()
            {
                ["session_id"] = sessionId,
            };

            // TODO: Add sort by parameter.
            if (page.HasValue)
            {
                parameters.Add("page", page.Value);
            }

            return GetJsonAsync<PagedResult<RatedEpisode>>($"/account/{accountId}/rated/tv/episodes", parameters);
        }

        /// <summary>
        /// Get a list of all the movies you have added to your watchlist.
        /// </summary>
        /// <param name="accountId">The account id.</param>
        /// <param name="sessionId">A valid session id.</param>
        /// <param name="page">The page number to query.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<PagedResult<Movie>> GetAccountMovieWatchlistAsync(int accountId, string sessionId, int? page = null)
        {
            if (string.IsNullOrWhiteSpace(sessionId))
            {
                throw new ArgumentException($"'{nameof(sessionId)}' cannot be null or whitespace.", nameof(sessionId));
            }

            var parameters = new Dictionary<string, object>()
            {
                ["session_id"] = sessionId,
            };

            // TODO: Add sort by parameter.
            if (page.HasValue)
            {
                parameters.Add("page", page.Value);
            }

            return GetJsonAsync<PagedResult<Movie>>($"/account/{accountId}/watchlist/movies", parameters);
        }

        /// <summary>
        /// Get a list of all the tv shows you have added to your watchlist.
        /// </summary>
        /// <param name="accountId">The account id.</param>
        /// <param name="sessionId">A valid session id.</param>
        /// <param name="page">The page number to query.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<PagedResult<TVShow>> GetAccountTVShowWatchlistAsync(int accountId, string sessionId, int? page = null)
        {
            if (string.IsNullOrWhiteSpace(sessionId))
            {
                throw new ArgumentException($"'{nameof(sessionId)}' cannot be null or whitespace.", nameof(sessionId));
            }

            var parameters = new Dictionary<string, object>()
            {
                ["session_id"] = sessionId,
            };

            // TODO: Add sort by parameter.
            if (page.HasValue)
            {
                parameters.Add("page", page.Value);
            }

            return GetJsonAsync<PagedResult<TVShow>>($"/account/{accountId}/watchlist/tv", parameters);
        }

        /// <summary>
        /// Add (or remove) a movie from watchlist.
        /// </summary>
        /// <param name="movieId">The id of the movie.</param>
        /// <param name="isWatchlist">The value indicating whether the movie is on watchlist.</param>
        /// <param name="accountId">The account id.</param>
        /// <param name="sessionId">A valid session id.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<Response> SetMovieWatchlistAsync(int movieId, bool isWatchlist, int accountId, string sessionId)
        {
            if (string.IsNullOrWhiteSpace(sessionId))
            {
                throw new ArgumentException($"'{nameof(sessionId)}' cannot be null or whitespace.", nameof(sessionId));
            }

            var parameters = new Dictionary<string, object>()
            {
                ["session_id"] = sessionId,
            };

            var request = new
            {
                media_type = "movie",
                media_id = movieId,
                watchlist = isWatchlist,
            };

            return PostJsonAsync<Response>($"/account/{accountId}/watchlist", parameters, request);
        }

        /// <summary>
        /// Add (or remove) a tv show from watchlist.
        /// </summary>
        /// <param name="tvShowId">The id of the tv show.</param>
        /// <param name="isWatchlist">The value indicating whether the tv show is on watchlist.</param>
        /// <param name="accountId">The account id.</param>
        /// <param name="sessionId">A valid session id.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<Response> SetTVShowWatchlistAsync(int tvShowId, bool isWatchlist, int accountId, string sessionId)
        {
            if (string.IsNullOrWhiteSpace(sessionId))
            {
                throw new ArgumentException($"'{nameof(sessionId)}' cannot be null or whitespace.", nameof(sessionId));
            }

            var parameters = new Dictionary<string, object>()
            {
                ["session_id"] = sessionId,
            };

            var request = new
            {
                media_type = "tv",
                media_id = tvShowId,
                watchlist = isWatchlist,
            };

            return PostJsonAsync<Response>($"/account/{accountId}/watchlist", parameters, request);
        }

        // TODO: Authentication: CreateGuestSession

        /// <summary>
        /// Creates a temporary request token that can be used to validate a tmdb user login.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<RequestTokenResult> CreateRequestTokenAsync()
        {
            return GetJsonAsync<RequestTokenResult>("/authentication/token/new");
        }

        /// <summary>
        /// You can use this method to create a fully valid session id once a user has validated the request token.
        /// </summary>
        /// <param name="requestToken">The approved request token.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<SessionResult> CreateSessionAsync(string requestToken)
        {
            var request = new
            {
                request_token = requestToken,
            };

            return PostJsonAsync<SessionResult>("/authentication/session/new", request);
        }

        /// <summary>
        /// This method allows an application to validate a request token by entering a username and password.
        /// </summary>
        /// <remarks>
        /// Not all applications have access to a web view so this can be used as a substitute.
        /// Please note, the preferred method of validating a request token is to have a user authenticate the request via the tmdb website.
        /// </remarks>
        /// <param name="username">The username to login.</param>
        /// <param name="password">The password to login.</param>
        /// <param name="requestToken">The approved request token.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<SessionResult> CreateSessionWithLoginAsync(string username, string password, string requestToken)
        {
            var request = new
            {
                username = username,
                password = password,
                request_token = requestToken,
            };

            return PostJsonAsync<SessionResult>("/authentication/token/validate_with_login", request);
        }

        // TODO: Authentication: CreateSessionFromV4

        /// <summary>
        /// If you would like to delete (or "logout") from a session, call this method with a valid session id.
        /// </summary>
        /// <param name="sessionId">A valid session id.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<Response> DeleteSessionAsync(string sessionId)
        {
            if (string.IsNullOrWhiteSpace(sessionId))
            {
                throw new ArgumentException($"'{nameof(sessionId)}' cannot be null or whitespace.", nameof(sessionId));
            }

            var request = new
            {
                session_id = sessionId,
            };

            return DeleteJsonAsync<Response>("/authentication/session", request);
        }

        /// <summary>
        /// Get an up to date list of the officially supported movie certifications on tmdb.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<CertificationsResult> GetMovieCertificationsAsync()
        {
            return GetJsonAsync<CertificationsResult>("/certification/movie/list");
        }

        /// <summary>
        /// Get an up to date list of the officially supported TV show certifications on tmdb.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<CertificationsResult> GetTVShowCertificationsAsync()
        {
            return GetJsonAsync<CertificationsResult>("/certification/tv/list");
        }

        // TODO: Changes: GetMovieChanges
        // TODO: Changes: GetTVShowChanges
        // TODO: Changes: GetPersonChanges

        /// <summary>
        /// Get collection details by id.
        /// </summary>
        /// <param name="collectionId">Id of the collection.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<CollectionDetails> GetCollectionDetailsAsync(int collectionId)
        {
            return GetJsonAsync<CollectionDetails>($"/collection/{collectionId}");
        }

        /// <summary>
        /// Get the images for a collection by id.
        /// </summary>
        /// <param name="collectionId">Id of the collection.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<ImagesResult> GetCollectionImagesAsync(int collectionId)
        {
            return GetJsonAsync<ImagesResult>($"/collection/{collectionId}/images");
        }

        /// <summary>
        /// Get the list translations for a collection by id.
        /// </summary>
        /// <param name="collectionId">Id of the collection.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<TranslationsResult<CollectionTranslationData>> GetCollectionTranslationsAsync(int collectionId)
        {
            return GetJsonAsync<TranslationsResult<CollectionTranslationData>>($"/collection/{collectionId}/translations");
        }

        /// <summary>
        /// Get a company details by id.
        /// </summary>
        /// <param name="companyId">Id of the company.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<CompanyDetails> GetCompanyDetailsAsync(int companyId)
        {
            return GetJsonAsync<CompanyDetails>($"/company/{companyId}");
        }

        /// <summary>
        /// Get the alternative names of a company.
        /// </summary>
        /// <param name="companyId">Id of the company.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<BasicResult<CompanyName>> GetCompanyAlternativeNamesAsync(int companyId)
        {
            return GetJsonAsync<BasicResult<CompanyName>>($"/company/{companyId}/alternative_names");
        }

        /// <summary>
        /// Get a companies logos by id. See remarks.
        /// </summary>
        /// <remarks>
        /// There are two image formats that are supported for companies, PNG's and SVG's.
        /// You can see which type the original file is by looking at the file_type field.
        /// We prefer SVG's as they are resolution independent and as such,
        /// the width and height are only there to reflect the original asset that was uploaded.
        /// An SVG can be scaled properly beyond those dimensions if you call them as a PNG.
        /// </remarks>
        /// <param name="companyId">Id of the company.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<OrganizationImages> GetCompanyImagesAsync(int companyId)
        {
            return GetJsonAsync<OrganizationImages>($"/company/{companyId}/images");
        }

        // TODO: Configuration: GetApiConfiguration
        // TODO: Configuration: GetCountriesConfiguration
        // TODO: Configuration: GetJobsConfiguration
        // TODO: Configuration: GetLanguagesConfiguration
        // TODO: Configuration: GetPrimaryTranslationsConfiguration
        // TODO: Configuration: GetTimeZonesConfiguration

        /// <summary>
        /// Get a movie or TV credit details by id.
        /// </summary>
        /// <param name="creditId">Id of the credit.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<CreditDetailsResult> GetCreditDetailsAsync(string creditId)
        {
            return GetJsonAsync<CreditDetailsResult>($"/credit/{creditId}");
        }

        /// <summary>
        /// Discover movies by different types of data like average rating, number of votes, genres and certifications. See remarks.
        /// </summary>
        /// <remarks>
        /// Discover also supports a nice list of sort options.
        /// Please note, when using certification \ certification.lte you must also specify certification_country.
        /// These two parameters work together in order to filter the results.
        /// You can only filter results with the countries we have added to our.
        /// If you specify the region parameter, the regional release date will be used instead of the primary release date.
        /// The date returned will be the first date based on your query (ie. if a with_release_type is specified). It's important to note the order of the release types that are used.
        /// Specifying "2|3" would return the limited theatrical release date as opposed to "3|2" which would return the theatrical date.
        /// Also note that a number of filters support being comma(,) or pipe(|) separated.Comma's are treated like an AND and query while pipe's are an OR.
        /// </remarks>
        /// <param name="primaryReleaseYear">Primary Release Year of the movie.</param>
        /// <param name="page">Page number to query.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<PagedResult<Movie>> DiscoverMoviesAsync(int? primaryReleaseYear = null, int page = 1)
        {
            var discover = new NewDiscoverMovie
            {
                PrimaryReleaseYear = primaryReleaseYear,
                Page = page,
            };

            return DiscoverMoviesAsync(discover);
        }

        /// <summary>
        /// Discover movies by different types of data like average rating, number of votes, genres and certifications.
        /// </summary>
        /// <param name="discover">An instance of the <see cref="NewDiscoverMovie"/> class.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<PagedResult<Movie>> DiscoverMoviesAsync(NewDiscoverMovie discover)
        {
            if (discover is null)
            {
                throw new ArgumentNullException(nameof(discover));
            }

            var parameters = new Dictionary<string, object>()
            {
                ["include_video"] = false,
            };

            if (discover.SortBy.HasValue)
            {
                parameters.Add("sort_by", discover.GetSortByValue());
            }

            if (discover.Page.HasValue)
            {
                parameters.Add("page", discover.Page);
            }

            if (discover.PrimaryReleaseYear.HasValue)
            {
                parameters.Add("primary_release_year", discover.PrimaryReleaseYear);
            }

            if (discover.Year.HasValue)
            {
                parameters.Add("year", discover.Year);
            }

            if (discover.WithGenreIds?.Any() == true)
            {
                parameters.Add("with_genres", string.Join(",", discover.WithGenreIds));
            }

            if (discover.WithoutGenreIds?.Any() == true)
            {
                parameters.Add("without_genres", string.Join(",", discover.WithoutGenreIds));
            }

            return GetJsonAsync<PagedResult<Movie>>("/discover/movie", parameters);
        }

        /// <summary>
        /// Discover TV shows by different types of data like average rating, number of votes, genres, the network they aired on and air dates. See remarks.
        /// </summary>
        /// <remarks>
        /// Discover also supports a nice list of sort options.
        /// Also note that a number of filters support being comma(,) or pipe(|) separated.Comma's are treated like an AND and query while pipe's are an OR.
        /// </remarks>
        /// <param name="firstAirDateYear">First air date year.</param>
        /// <param name="page">Page number to query.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<PagedResult<TVShow>> DiscoverTVShowsAsync(int? firstAirDateYear = null, int page = 1)
        {
            var discover = new NewDiscoverTVShow
            {
                FirstAirDateYear = firstAirDateYear,
                IncludeNullFirstAirDates = false,
                Page = page,
            };

            return DiscoverTVShowsAsync(discover);
        }

        /// <summary>
        /// Discover TV shows by different types of data like average rating, number of votes, genres, the network they aired on and air dates.
        /// </summary>
        /// <param name="discover">A new instance of the <see cref="NewDiscoverTVShow"/> class.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<PagedResult<TVShow>> DiscoverTVShowsAsync(NewDiscoverTVShow discover)
        {
            if (discover is null)
            {
                throw new ArgumentNullException(nameof(discover));
            }

            var parameters = new Dictionary<string, object>();

            if (discover.SortBy.HasValue)
            {
                parameters.Add("sort_by", discover.GetSortByValue());
            }

            if (discover.Page.HasValue)
            {
                parameters.Add("page", discover.Page);
            }

            if (discover.FirstAirDateYear.HasValue)
            {
                parameters.Add("first_air_date_year", discover.FirstAirDateYear);
            }

            if (discover.WithGenreIds?.Any() == true)
            {
                parameters.Add("with_genres", string.Join(",", discover.WithGenreIds));
            }

            if (discover.WithoutGenreIds?.Any() == true)
            {
                parameters.Add("without_genres", string.Join(",", discover.WithoutGenreIds));
            }

            if (discover.IncludeNullFirstAirDates.HasValue)
            {
                parameters.Add("include_null_first_air_dates", discover.IncludeNullFirstAirDates);
            }

            return GetJsonAsync<PagedResult<TVShow>>("/discover/tv", parameters);
        }

        /// <summary>
        /// The find method makes it easy to search for objects in our database by an external id. For example, an IMDB ID.
        /// This method will search all objects(movies, TV shows and people) and return the results in a single response.
        /// </summary>
        /// <param name="externalId">External id (e.g. tt0141842 for imdb).</param>
        /// <param name="externalSource">External source name (e.g. imdb_id or tv_db_id).</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<Find> FindByExternalIdAsync(string externalId, string externalSource = "imdb_id")
        {
            var parameters = new Dictionary<string, object>()
            {
                ["external_id"] = externalId,
                ["external_source"] = externalSource,
            };

            return GetJsonAsync<Find>($"/find/{externalId}", parameters);
        }

        /// <summary>
        /// Get the list of official genres for movies.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<GenresResult> GetMovieGenresAsync()
        {
            return GetJsonAsync<GenresResult>("/genre/movie/list");
        }

        /// <summary>
        /// Get the list of official genres for TV shows.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<GenresResult> GetTVShowGenresAsync()
        {
            return GetJsonAsync<GenresResult>("/genre/tv/list");
        }

        // TODO: Guest Sessions: GetGuestSessionRatedMovies
        // TODO: Guest Sessions: GetGuestSessionRatedTVShows
        // TODO: Guest Sessions: GetGuestSessionRatedTVEpisodes

        /// <summary>
        /// Get details about a keyword by id.
        /// </summary>
        /// <param name="keywordId">Id of the keyword.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<KeywordDetails> GetKeywordDetailsAsync(int keywordId)
        {
            return GetJsonAsync<KeywordDetails>($"/keyword/{keywordId}");
        }

        /// <summary>
        /// Get the movies that belong to a keyword. See remarks.
        /// </summary>
        /// <remarks>
        /// We highly recommend using <seealso cref="DiscoverMoviesAsync(int?, int)"/> instead of this method as it is much more flexible.
        /// </remarks>
        /// <param name="keywordId">Id of the keyword.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<PagedResult<Movie>> GetKeywordMoviesAsync(int keywordId)
        {
            return GetJsonAsync<PagedResult<Movie>>($"/keyword/{keywordId}/movies");
        }

        // TODO: Lists: GetListDetails
        // TODO: Lists: CheckListItemStatus (Find a better method name.)
        // TODO: Lists: CreateList
        // TODO: Lists: AddMovieToList
        // TODO: Lists: RemoveMovieFromList
        // TODO: Lists: ClearList
        // TODO: Lists: DeleteList

        /// <summary>
        /// Get the primary information about a movie.
        /// </summary>
        /// <param name="movieId">Id of the movie.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<MovieDetails> GetMovieDetailsAsync(int movieId)
        {
            var parameters = new Dictionary<string, object>()
            {
                ["append_to_response"] = "credits,release_dates",
            };

            return GetJsonAsync<MovieDetails>($"/movie/{movieId}", parameters);
        }

        // TODO: Movies: GetMovieAccountStates

        /// <summary>
        /// Get all of the alternative titles for a movie.
        /// </summary>
        /// <param name="movieId">Id of the movie.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<BasicResult<AlternativeTitle>> GetMovieAlternativeTitlesAsync(int movieId)
        {
            return GetJsonAsync<BasicResult<AlternativeTitle>>($"/movie/{movieId}/alternative_titles");
        }

        // TODO: Movies: GetMovieChanges

        /// <summary>
        /// Get the cast and crew for a movie.
        /// </summary>
        /// <param name="movieId">Id of the movie.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<CreditsResult> GetMovieCreditsAsync(int movieId)
        {
            return GetJsonAsync<CreditsResult>($"/movie/{movieId}/credits");
        }

        /// <summary>
        /// Get the external ids for a movie.
        /// </summary>
        /// <param name="movieId">Id of the movie.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<ExternalIds> GetMovieExternalIdsAsync(int movieId)
        {
            return GetJsonAsync<ExternalIds>($"/movie/{movieId}/external_ids");
        }

        /// <summary>
        /// Get the images that belongs to a movie.
        /// </summary>
        /// <param name="movieId">Id of the movie.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<ImagesResult> GetMovieImagesAsync(int movieId)
        {
            var parameters = new Dictionary<string, object>();

            if (!string.IsNullOrWhiteSpace(_options.ImageFallbackLanguages))
            {
                parameters.Add("include_image_language", _options.ImageFallbackLanguages);
            }

            return GetJsonAsync<ImagesResult>($"/movie/{movieId}/images", parameters);
        }

        /// <summary>
        /// Get the movies that belong to a keyword.
        /// </summary>
        /// <param name="movieId">Id of the movie.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<KeywordsResult> GetMovieKeywordsAsync(int movieId)
        {
            return GetJsonAsync<KeywordsResult>($"/movie/{movieId}/keywords");
        }

        /// <summary>
        /// Get a list of lists that this movie belongs to.
        /// </summary>
        /// <param name="movieId">Id of the movie.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<MovieListResult> GetMovieListsAsync(int movieId)
        {
            return GetJsonAsync<MovieListResult>($"/movie/{movieId}/lists");
        }

        /// <summary>
        /// Get a list of recommended movies for a movie.
        /// </summary>
        /// <param name="movieId">Id of the movie.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<PagedResult<Movie>> GetMovieRecommendationsAsync(int movieId)
        {
            return GetJsonAsync<PagedResult<Movie>>($"/movie/{movieId}/recommendations");
        }

        /// <summary>
        /// Get the release date along with the certification for a movie.
        /// Release dates support different types:
        /// <list type="number">
        /// <item>Premiere</item>
        /// <item>Theatrical (limited)</item>
        /// <item>Theatrical</item>
        /// <item>Digital</item>
        /// <item>Physical</item>
        /// <item>TV</item>
        /// </list>
        /// </summary>
        /// <param name="movieId">Id of the movie.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<BasicResult<ReleaseDatesResult>> GetMovieReleaseDatesAsync(int movieId)
        {
            return GetJsonAsync<BasicResult<ReleaseDatesResult>>($"/movie/{movieId}/release_dates");
        }

        /// <summary>
        /// Get the user reviews for a movie.
        /// </summary>
        /// <param name="movieId">Id of the movie.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<ReviewResult> GetMovieReviewsAsync(int movieId)
        {
            return GetJsonAsync<ReviewResult>($"/movie/{movieId}/reviews");
        }

        /// <summary>
        /// Get a list of similar movies. This is not the same as the "Recommendation" system you see on the website.
        /// These items are assembled by looking at keywords and genres.
        /// </summary>
        /// <param name="movieId">Id of the movie.</param>
        /// <param name="page">Specify which page to query.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<PagedResult<Movie>> GetSimilarMoviesAsync(int movieId, int page = 1)
        {
            var parameters = new Dictionary<string, object>()
            {
                ["page"] = page.ToString(CultureInfo.InvariantCulture),
            };

            return GetJsonAsync<PagedResult<Movie>>($"/movie/{movieId}/similar", parameters);
        }

        /// <summary>
        /// Get a list of translations that have been created for a movie.
        /// </summary>
        /// <param name="movieId">Id of the movie.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<TranslationsResult<MovieTranslationData>> GetMovieTranslationsAsync(int movieId)
        {
            return GetJsonAsync<TranslationsResult<MovieTranslationData>>($"/movie/{movieId}/translations");
        }

        /// <summary>
        /// Get the videos that have been added to a movie.
        /// </summary>
        /// <param name="movieId">The id of the movie.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<BasicResult<Video>> GetMovieVideosAsync(int movieId)
        {
            return GetJsonAsync<BasicResult<Video>>($"/movie/{movieId}/videos");
        }

        // TODO: Movies: GetMovieWatchProviders

        /// <summary>
        /// Rate a movie.
        /// </summary>
        /// <param name="movieId">The id of the movie.</param>
        /// <param name="value">The value of the rating which is expected to be between 0.5 and 10.0.</param>
        /// <param name="sessionId">A valid session id.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<Response> SetMovieRatingAsync(int movieId, double value, string sessionId)
        {
            if (string.IsNullOrWhiteSpace(sessionId))
            {
                throw new ArgumentException($"'{nameof(sessionId)}' cannot be null or whitespace.", nameof(sessionId));
            }

            var parameters = new Dictionary<string, object>()
            {
                ["session_id"] = sessionId,
            };

            var request = new
            {
                value = value,
            };

            return PostJsonAsync<Response>($"/movie/{movieId}/rating", parameters, request);
        }

        /// <summary>
        /// Remove your rating for a movie.
        /// </summary>
        /// <param name="movieId">The id of the movie.</param>
        /// <param name="sessionId">A valid session id.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<Response> DeleteMovieRatingAsync(int movieId, string sessionId)
        {
            if (string.IsNullOrWhiteSpace(sessionId))
            {
                throw new ArgumentException($"'{nameof(sessionId)}' cannot be null or whitespace.", nameof(sessionId));
            }

            var parameters = new Dictionary<string, object>()
            {
                ["session_id"] = sessionId,
            };

            return DeleteJsonAsync<Response>($"/movie/{movieId}/rating", parameters);
        }

        /// <summary>
        /// Get the most newly created movie.
        /// This is a live response and will continuously change.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<MovieDetails> GetLatestMovieAsync()
        {
            return GetJsonAsync<MovieDetails>("/movie/latest");
        }

        /// <summary>
        /// Get a list of movies in theatres.
        /// This is a release type query that looks for all movies that have a release type of 2 or 3 within the specified date range.
        /// You can optionally specify a region prameter which will narrow the search to only look for theatrical release dates within the specified country.
        /// </summary>
        /// <param name="page">Page number to query.</param>
        /// <param name="region">Specific country.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<NowPlayingResult> GetNowPlayingAsync(int page = 1, string region = null)
        {
            var parameters = new Dictionary<string, object>()
            {
                ["page"] = page.ToString(CultureInfo.InvariantCulture),
            };

            if (!string.IsNullOrWhiteSpace(region))
            {
                parameters.Add("region", region);
            }

            return GetJsonAsync<NowPlayingResult>("/movie/now_playing");
        }

        /// <summary>
        /// Get a list of the current popular movies on tmdb.
        /// This list updates daily.
        /// </summary>
        /// <param name="page">Page number to query.</param>
        /// <param name="region">Specific country.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<PagedResult<Movie>> GetPopularMoviesAsync(int page = 1, string region = null)
        {
            var parameters = new Dictionary<string, object>()
            {
                ["page"] = page.ToString(CultureInfo.InvariantCulture),
            };

            if (!string.IsNullOrWhiteSpace(region))
            {
                parameters.Add("region", region);
            }

            return GetJsonAsync<PagedResult<Movie>>("/movie/popular");
        }

        /// <summary>
        /// Get the top rated movies on tmdb.
        /// </summary>
        /// <param name="page">Page number to query.</param>
        /// <param name="region">Specific country.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<PagedResult<Movie>> GetTopRatedMoviesAsync(int page = 1, string region = null)
        {
            var parameters = new Dictionary<string, object>()
            {
                ["page"] = page.ToString(CultureInfo.InvariantCulture),
            };

            if (!string.IsNullOrWhiteSpace(region))
            {
                parameters.Add("region", region);
            }

            return GetJsonAsync<PagedResult<Movie>>("/movie/top_rated");
        }

        /// <summary>
        /// Get a list of upcoming movies in theatres.
        /// This is a release type query that looks for all movies that have a release type of 2 or 3 within the specified date range.
        /// You can optionally specify a region prameter which will narrow the search to only look for theatrical release dates within the specified country.
        /// </summary>
        /// <param name="page">Page number to query.</param>
        /// <param name="region">Specific country.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<NowPlayingResult> GetUpcomingMoviesAsync(int page = 1, string region = null)
        {
            var parameters = new Dictionary<string, object>()
            {
                ["page"] = page.ToString(CultureInfo.InvariantCulture),
            };

            if (!string.IsNullOrWhiteSpace(region))
            {
                parameters.Add("region", region);
            }

            return GetJsonAsync<NowPlayingResult>("/movie/upcoming");
        }

        /// <summary>
        /// Get the details of a network.
        /// </summary>
        /// <param name="networkId">Id of the network.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<NetworkDetails> GetNetworkDetailsAsync(int networkId)
        {
            return GetJsonAsync<NetworkDetails>($"/network/{networkId}");
        }

        /// <summary>
        /// Get the alternative names of a network.
        /// </summary>
        /// <param name="networkId">Id of the network.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<BasicResult<CompanyName>> GetNetworkAlternativeNamesAsync(int networkId)
        {
            return GetJsonAsync<BasicResult<CompanyName>>($"/network/{networkId}/alternative_names");
        }

        /// <summary>
        /// Get the TV network logos by id.
        /// There are two image formats that are supported for networks, PNG's and SVG's.
        /// You can see which type the original file is by looking at the file_type field.
        /// We prefer SVG's as they are resolution independent and as such, the width and height are only there to reflect the original asset that was uploaded.
        /// An SVG can be scaled properly beyond those dimensions if you call them as a PNG.
        /// </summary>
        /// <param name="networkId">Id of the network.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<OrganizationImages> GetNetworkImagesAsync(int networkId)
        {
            return GetJsonAsync<OrganizationImages>($"/network/{networkId}/images");
        }

        /// <summary>
        /// Get the daily or weekly trending items.
        /// The daily trending list tracks items over the period of a day while items have a 24 hour half life.
        /// The weekly list tracks items over a 7 day period, with a 7 day half life.
        /// </summary>
        /// <param name="timeWindow">Time window (e.g. Day or Week).</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<PagedResult<Movie>> GetTrendingMoviesAsync(TimeWindow timeWindow)
        {
            return GetJsonAsync<PagedResult<Movie>>($"/trending/movie/{timeWindow.ToString().ToLowerInvariant()}");
        }

        /// <summary>
        /// Get the daily or weekly trending items.
        /// The daily trending list tracks items over the period of a day while items have a 24 hour half life.
        /// The weekly list tracks items over a 7 day period, with a 7 day half life.
        /// </summary>
        /// <param name="timeWindow">Time window (e.g. Day or Week).</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<PagedResult<TVShow>> GetTrendingTVShowsAsync(TimeWindow timeWindow)
        {
            return GetJsonAsync<PagedResult<TVShow>>($"/trending/tv/{timeWindow.ToString().ToLowerInvariant()}");
        }

        /// <summary>
        /// Get the daily or weekly trending items.
        /// The daily trending list tracks items over the period of a day while items have a 24 hour half life.
        /// The weekly list tracks items over a 7 day period, with a 7 day half life.
        /// </summary>
        /// <param name="timeWindow">Time window (e.g. Day or Week).</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<PagedResult<Person>> GetTrendingPeopleAsync(TimeWindow timeWindow)
        {
            return GetJsonAsync<PagedResult<Person>>($"/trending/person/{timeWindow.ToString().ToLowerInvariant()}");
        }

        /// <summary>
        /// Get the primary person details by id.
        /// </summary>
        /// <param name="personId">Id of the person.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<PersonDetails> GetPersonDetailsAsync(int personId)
        {
            return GetJsonAsync<PersonDetails>($"/person/{personId}");
        }

        // TODO: People: GetPersonChanges

        /// <summary>
        /// Get the movie credits for a person.
        /// </summary>
        /// <param name="personId">Id of the person.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<PersonMovieCredits> GetPersonMovieCreditsAsync(int personId)
        {
            return GetJsonAsync<PersonMovieCredits>($"/person/{personId}/movie_credits");
        }

        /// <summary>
        /// Get the TV show credits for a person.
        /// </summary>
        /// <param name="personId">Id of the person.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<PersonTVShowCredits> GetPersonTVShowCreditsAsync(int personId)
        {
            return GetJsonAsync<PersonTVShowCredits>($"/person/{personId}/tv_credits");
        }

        /// <summary>
        /// Get the movie and TV show credits together in a single response.
        /// </summary>
        /// <param name="personId">Id of the person.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<PersonCombinedCredits> GetPersonCombinedCreditsAsync(int personId)
        {
            return GetJsonAsync<PersonCombinedCredits>($"/person/{personId}/combined_credits");
        }

        /// <summary>
        /// Get the external ids for a person. We currently support the following external sources.
        /// </summary>
        /// <param name="personId">Id of the person.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<ExternalIds> GetPersonExternalIdsAsync(int personId)
        {
            return GetJsonAsync<ExternalIds>($"/person/{personId}/external_ids");
        }

        /// <summary>
        /// Get the images for a person.
        /// </summary>
        /// <param name="personId">Id of the person.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<PersonImageResult> GetPersonImagesAsync(int personId)
        {
            return GetJsonAsync<PersonImageResult>($"/person/{personId}/images");
        }

        /// <summary>
        /// Get the images that this person has been tagged in.
        /// </summary>
        /// <param name="personId">Id of the person.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<PagedResult<Image>> GetPersonTaggedImagesAsync(int personId)
        {
            return GetJsonAsync<PagedResult<Image>>($"/person/{personId}/tagged_images");
        }

        /// <summary>
        /// Get a list of translations that have been created for a person.
        /// </summary>
        /// <param name="personId">Id of the person.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<TranslationsResult<PersonTranslationData>> GetPersonTranslationsAsync(int personId)
        {
            return GetJsonAsync<TranslationsResult<PersonTranslationData>>($"/person/{personId}/translations");
        }

        /// <summary>
        /// Get the most newly created person. This is a live response and will continuously change.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<PersonDetails> GetLatestPersonAsync()
        {
            return GetJsonAsync<PersonDetails>("/person/latest");
        }

        /// <summary>
        /// Get the list of popular people on tmdb. This list updates daily.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<PagedResult<Person>> GetPopularPeopleAsync()
        {
            return GetJsonAsync<PagedResult<Person>>("/person/popular");
        }

        /// <summary>
        /// Get details of a review.
        /// </summary>
        /// <param name="reviewId">Id of the review.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<ReviewDetails> GetReviewDetailsAsync(string reviewId)
        {
            if (string.IsNullOrWhiteSpace(reviewId))
            {
                throw new ArgumentException($"'{nameof(reviewId)}' cannot be null or whitespace", nameof(reviewId));
            }

            return GetJsonAsync<ReviewDetails>($"/review/{reviewId}");
        }

        /// <summary>
        /// Search for companies.
        /// </summary>
        /// <param name="query">Query to search.</param>
        /// <param name="page">Page number to query.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<PagedResult<Organization>> SearchCompaniesAsync(string query, int page = 1)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                throw new ArgumentException($"'{nameof(query)}' cannot be null or whitespace", nameof(query));
            }

            var parameters = new Dictionary<string, object>()
            {
                ["query"] = query,
                ["page"] = page.ToString(CultureInfo.InvariantCulture),
            };

            return GetJsonAsync<PagedResult<Organization>>("/search/company", parameters);
        }

        /// <summary>
        /// Search for collections.
        /// </summary>
        /// <param name="query">Search query.</param>
        /// <param name="page">Page number to query.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<PagedResult<SearchCollection>> SearchCollectionsAsync(string query, int page = 1)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                throw new ArgumentException($"'{nameof(query)}' cannot be null or whitespace", nameof(query));
            }

            var parameters = new Dictionary<string, object>()
            {
                ["query"] = query,
                ["page"] = page.ToString(CultureInfo.InvariantCulture),
            };

            return GetJsonAsync<PagedResult<SearchCollection>>("/search/collection", parameters);
        }

        /// <summary>
        /// Search for keywords.
        /// </summary>
        /// <param name="query">Search query.</param>
        /// <param name="page">page number to query.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<PagedResult<Keyword>> SearchKeywordsAsync(string query, int page = 1)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                throw new ArgumentException($"'{nameof(query)}' cannot be null or whitespace", nameof(query));
            }

            var parameters = new Dictionary<string, object>()
            {
                ["query"] = query,
                ["page"] = page.ToString(CultureInfo.InvariantCulture),
            };

            return GetJsonAsync<PagedResult<Keyword>>("/search/keyword", parameters);
        }

        /// <summary>
        /// Search for movies.
        /// </summary>
        /// <param name="query">Search query.</param>
        /// <param name="primaryReleaseYear">Primary release year of the movie.</param>
        /// <param name="year">Year of the movie.</param>
        /// <param name="page">Page number to query.</param>
        /// <param name="region">Specific country.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<PagedResult<Movie>> SearchMoviesAsync(string query, int? primaryReleaseYear = null, int? year = null, int page = 1, string region = null)
        {
            var search = new NewSearchMovie
            {
                Query = query,
                Year = year,
                Page = page,
                Region = region,
                PrimaryReleaseYear = primaryReleaseYear,
            };

            return SearchMoviesAsync(search);
        }

        /// <summary>
        /// Search for movies.
        /// </summary>
        /// <param name="search">An instance of the <see cref="NewSearchMovie"/> class.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<PagedResult<Movie>> SearchMoviesAsync(NewSearchMovie search)
        {
            if (search is null)
            {
                throw new ArgumentNullException(nameof(search));
            }

            if (string.IsNullOrWhiteSpace(search.Query))
            {
                throw new ArgumentException($"'{nameof(search.Query)}' cannot be null or whitespace", nameof(search));
            }

            var parameters = new Dictionary<string, object>()
            {
                ["query"] = search.Query,
            };

            if (search.PrimaryReleaseYear.HasValue)
            {
                parameters.Add("primary_release_year", search.PrimaryReleaseYear);
            }

            if (search.Year.HasValue)
            {
                parameters.Add("year", search.Year);
            }

            if (!string.IsNullOrWhiteSpace(search.Language))
            {
                parameters.Add("language", search.Language);
            }

            if (!string.IsNullOrWhiteSpace(search.Region))
            {
                parameters.Add("region", search.Region);
            }

            if (search.Page.HasValue)
            {
                parameters.Add("page", search.Page);
            }

            return GetJsonAsync<PagedResult<Movie>>("/search/movie", parameters);
        }

        // TODO: Search: MultiSearch

        /// <summary>
        /// Search for people.
        /// </summary>
        /// <param name="query">Search query.</param>
        /// <param name="page">Page number to query.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<PagedResult<SearchPeople>> SearchPeopleAsync(string query, int page = 1)
        {
            var parameters = new Dictionary<string, object>()
            {
                ["query"] = query,
                ["page"] = page.ToString(CultureInfo.InvariantCulture),
            };

            return GetJsonAsync<PagedResult<SearchPeople>>("/search/person", parameters);
        }

        /// <summary>
        /// Search for a TV show.
        /// </summary>
        /// <param name="query">Query to search.</param>
        /// <param name="firstAirYear">First air year of the show.</param>
        /// <param name="page">Query page number.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<PagedResult<TVShow>> SearchTVShowsAsync(string query, int? firstAirYear = null, int page = 1)
        {
            var search = new NewSearchTVShow
            {
                Query = query,
                FirstAirDateYear = firstAirYear,
                Page = page,
            };

            return SearchTVShowsAsync(search);
        }

        /// <summary>
        /// Search for a TV show.
        /// </summary>
        /// <param name="search">An instance of the <see cref="NewSearchTVShow"/> class.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<PagedResult<TVShow>> SearchTVShowsAsync(NewSearchTVShow search)
        {
            if (search is null)
            {
                throw new ArgumentNullException(nameof(search));
            }

            if (string.IsNullOrWhiteSpace(search.Query))
            {
                throw new ArgumentException($"'{nameof(search.Query)}' cannot be null or whitespace", nameof(search));
            }

            var parameters = new Dictionary<string, object>()
            {
                ["query"] = search.Query,
            };

            if (search.FirstAirDateYear.HasValue)
            {
                parameters.Add("first_air_date_year", search.FirstAirDateYear);
            }

            if (!string.IsNullOrWhiteSpace(search.Language))
            {
                parameters.Add("language", search.Language);
            }

            if (search.Page.HasValue)
            {
                parameters.Add("page", search.Page);
            }

            return GetJsonAsync<PagedResult<TVShow>>("/search/tv", parameters);
        }

        /// <summary>
        /// Get the primary TV Show details by id.
        /// </summary>
        /// <param name="tvShowId">Id of the TV show.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<TVShowDetails> GetTVShowDetailsAsync(int tvShowId)
        {
            var parameters = new Dictionary<string, object>()
            {
                ["append_to_response"] = "credits,external_ids,content_ratings",
            };

            return GetJsonAsync<TVShowDetails>($"/tv/{tvShowId}", parameters);
        }

        // TODO: TV: GetTVShowAccountStates
        // TODO: TV: GetTVShowAggregateCredits

        /// <summary>
        /// Get all of the alternative titles for a TV show..
        /// </summary>
        /// <param name="tvShowId">Id of the tv show.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<BasicResult<AlternativeTitle>> GetTVShowAlternativeTitlesAsync(int tvShowId)
        {
            return GetJsonAsync<BasicResult<AlternativeTitle>>($"/tv/{tvShowId}/alternative_titles");
        }

        // TODO: TV: GetTVShowChanges

        /// <summary>
        /// Get the list of content ratings (certifications) that have been added to a TV show.
        /// </summary>
        /// <param name="tvShowId">Id of the TV show.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<BasicResult<ContentRatings>> GetTVShowContentRatingsAsync(int tvShowId)
        {
            return GetJsonAsync<BasicResult<ContentRatings>>($"/tv/{tvShowId}/content_ratings");
        }

        /// <summary>
        /// Get the credits (cast and crew) that have been added to a TV show.
        /// </summary>
        /// <param name="tvShowId">Id of the TV show.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<CreditsResult> GetTVShowCreditsAsync(int tvShowId)
        {
            return GetJsonAsync<CreditsResult>($"/tv/{tvShowId}/credits");
        }

        /// <summary>
        /// Get all of the episode groups that have been created for a TV show. See remarks.
        /// </summary>
        /// <remarks>
        /// With a groupId you can call the <see cref="GetTVShowEpisodeGroupsDetailsAsync(string)"/> method.
        /// </remarks>
        /// <param name="tvShowId">Id of the tv show.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<BasicResult<EpisodeGroup>> GetTVShowEpisodeGroupsAsync(int tvShowId)
        {
            return GetJsonAsync<BasicResult<EpisodeGroup>>($"/tv/{tvShowId}/episode_groups");
        }

        /// <summary>
        /// Get the external ids for a TV show.
        /// </summary>
        /// <param name="tvShowId">Id of the TV show.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<TVShowExternalIdsResult> GetTVShowExternalIdsAsync(int tvShowId)
        {
            return GetJsonAsync<TVShowExternalIdsResult>($"/tv/{tvShowId}/external_ids");
        }

        /// <summary>
        /// Get the images that belong to a TV show.
        /// </summary>
        /// <param name="tvShowId">Id of the TV show.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<ImagesResult> GetTVShowImagesAsync(int tvShowId)
        {
            var parameters = new Dictionary<string, object>();

            if (!string.IsNullOrWhiteSpace(_options.ImageFallbackLanguages))
            {
                parameters.Add("include_image_language", _options.ImageFallbackLanguages);
            }

            return GetJsonAsync<ImagesResult>($"/tv/{tvShowId}/images", parameters);
        }

        /// <summary>
        /// Get the keywords that have been added to a TV show.
        /// </summary>
        /// <param name="tvShowId">Id of the tv show.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<BasicResult<Keyword>> GetTVShowKeywordsAsync(int tvShowId)
        {
            return GetJsonAsync<BasicResult<Keyword>>($"/tv/{tvShowId}/keywords");
        }

        /// <summary>
        /// Get a list of recommended movies for a tv show.
        /// </summary>
        /// <param name="tvShowId">The id of the tv show.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<PagedResult<TVShow>> GetTVShowRecommendationsAsync(int tvShowId)
        {
            return GetJsonAsync<PagedResult<TVShow>>($"/tv/{tvShowId}/recommendations");
        }

        /// <summary>
        /// Get the reviews for a TV show.
        /// </summary>
        /// <param name="tvShowId">Id of the tv show.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<ReviewResult> GetTVShowReviewsAsync(int tvShowId)
        {
            return GetJsonAsync<ReviewResult>($"/tv/{tvShowId}/reviews");
        }

        /// <summary>
        /// Get a list of seasons or episodes that have been screened in a film festival or theatre.
        /// </summary>
        /// <param name="tvShowId">Id of the tv show.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<BasicResult<ScreenedTheatrically>> GetTVShowScreenedTheatricallyAsync(int tvShowId)
        {
            return GetJsonAsync<BasicResult<ScreenedTheatrically>>($"/tv/{tvShowId}/screened_theatrically");
        }

        /// <summary>
        /// Get a list of similar TV shows.
        /// These items are assembled by looking at keywords and genres.
        /// </summary>
        /// <param name="tvShowId">Id of the tv show.</param>
        /// <param name="page">Specify which page to query.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<PagedResult<Movie>> GetSimilarTVShowsAsync(int tvShowId, int page = 1)
        {
            var parameters = new Dictionary<string, object>()
            {
                ["page"] = page.ToString(CultureInfo.InvariantCulture),
            };

            return GetJsonAsync<PagedResult<Movie>>($"/tv/{tvShowId}/similar", parameters);
        }

        /// <summary>
        /// Get a list of the translations that exist for a TV show.
        /// </summary>
        /// <param name="tvShowId">Id of the tv show.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<TranslationsResult<TVShowTranslationData>> GetTVShowTranslationsAsync(int tvShowId)
        {
            return GetJsonAsync<TranslationsResult<TVShowTranslationData>>($"/tv/{tvShowId}/translations");
        }

        /// <summary>
        /// Get the videos that have been added to a TV show.
        /// </summary>
        /// <param name="tvShowId">Id of the tv show.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<BasicResult<Video>> GetTVShowVideosAsync(int tvShowId)
        {
            return GetJsonAsync<BasicResult<Video>>($"/tv/{tvShowId}/videos");
        }

        // TODO: TV: GetTVShowWatchProviders

        /// <summary>
        /// Rate a tv show.
        /// </summary>
        /// <param name="tvShowId">The id of the tv show.</param>
        /// <param name="value">The value of the rating which is expected to be between 0.5 and 10.0.</param>
        /// <param name="sessionId">A valid session id.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<Response> SetTVShowRatingAsync(int tvShowId, double value, string sessionId)
        {
            if (string.IsNullOrWhiteSpace(sessionId))
            {
                throw new ArgumentException($"'{nameof(sessionId)}' cannot be null or whitespace.", nameof(sessionId));
            }

            var parameters = new Dictionary<string, object>()
            {
                ["session_id"] = sessionId,
            };

            var request = new
            {
                value = value,
            };

            return PostJsonAsync<Response>($"/tv/{tvShowId}/rating", parameters, request);
        }

        /// <summary>
        /// Remove your rating for a tv show.
        /// </summary>
        /// <param name="tvShowId">The id of the tv show.</param>
        /// <param name="sessionId">A valid session id.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<Response> DeleteTVShowRatingAsync(int tvShowId, string sessionId)
        {
            if (string.IsNullOrWhiteSpace(sessionId))
            {
                throw new ArgumentException($"'{nameof(sessionId)}' cannot be null or whitespace.", nameof(sessionId));
            }

            var parameters = new Dictionary<string, object>()
            {
                ["session_id"] = sessionId,
            };

            return DeleteJsonAsync<Response>($"/tv/{tvShowId}/rating", parameters);
        }

        /// <summary>
        /// Get the most newly created TV show.
        /// This is a live response and will continuously change.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<TVShowDetails> GetLatestTVShowAsync()
        {
            return GetJsonAsync<TVShowDetails>("/tv/latest");
        }

        /// <summary>
        /// Get a list of TV shows that are airing today. This query is purely day based as we do not currently support airing times.
        /// </summary>
        /// <param name="page">Specify which page to query.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<PagedResult<TVShow>> GetAiringTodayTVShowsAsync(int page = 1)
        {
            var parameters = new Dictionary<string, object>()
            {
                ["page"] = page.ToString(CultureInfo.InvariantCulture),
            };

            return GetJsonAsync<PagedResult<TVShow>>("/tv/airing_today", parameters);
        }

        /// <summary>
        /// Get a list of shows that are currently on the air.
        /// This query looks for any TV show that has an episode with an air date in the next 7 days.
        /// </summary>
        /// <param name="page">Specify which page to query.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<PagedResult<TVShow>> GetOnTheAirTVShowsAsync(int page = 1)
        {
            var parameters = new Dictionary<string, object>()
            {
                ["page"] = page.ToString(CultureInfo.InvariantCulture),
            };

            return GetJsonAsync<PagedResult<TVShow>>("/tv/on_the_air", parameters);
        }

        /// <summary>
        /// Get a list of the current popular TV shows on tmdb. This list updates daily.
        /// </summary>
        /// <param name="page">Specify which page to query.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<PagedResult<TVShow>> GetPopularTVShowsAsync(int page = 1)
        {
            var parameters = new Dictionary<string, object>()
            {
                ["page"] = page.ToString(CultureInfo.InvariantCulture),
            };

            return GetJsonAsync<PagedResult<TVShow>>("/tv/popular", parameters);
        }

        /// <summary>
        /// Get a list of the top rated TV shows on tmdb.
        /// </summary>
        /// <param name="page">Specify which page to query.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<PagedResult<TVShow>> GetTopRatedTVShowsAsync(int page = 1)
        {
            var parameters = new Dictionary<string, object>()
            {
                ["page"] = page.ToString(CultureInfo.InvariantCulture),
            };

            return GetJsonAsync<PagedResult<TVShow>>("/tv/top_rated", parameters);
        }

        /// <summary>
        /// Get the TV season details by id.
        /// </summary>
        /// <param name="tvShowId">Id of the tv show.</param>
        /// <param name="seasonNumber">Season number.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<SeasonDetails> GetTVShowSeasonDetailsAsync(int tvShowId, int seasonNumber)
        {
            return GetJsonAsync<SeasonDetails>($"/tv/{tvShowId}/season/{seasonNumber}");
        }

        // TODO: TV Seasons: GetTVShowSeasonAccountStates
        // TODO: TV Seasons: GetTVShowSeasonAggregateCredits
        // TODO: TV Seasons: GetTVShowSeasonChanges

        /// <summary>
        /// Get the credits for TV season.
        /// </summary>
        /// <param name="tvShowId">Id of the tv show.</param>
        /// <param name="seasonNumber">Season number.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<CreditsResult> GetTVShowSeasonCreditsAsync(int tvShowId, int seasonNumber)
        {
            return GetJsonAsync<CreditsResult>($"/tv/{tvShowId}/season/{seasonNumber}/credits");
        }

        /// <summary>
        /// Get the external ids for a TV season.
        /// </summary>
        /// <param name="tvShowId">Id of the tv show.</param>
        /// <param name="seasonNumber">Season number.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<SeasonExternalIds> GetTVShowSeasonExternalIdsAsync(int tvShowId, int seasonNumber)
        {
            return GetJsonAsync<SeasonExternalIds>($"/tv/{tvShowId}/season/{seasonNumber}/external_ids");
        }

        /// <summary>
        /// Get the images that belong to a TV season.
        /// </summary>
        /// <param name="tvShowId">Id of the TV show.</param>
        /// <param name="seasonNumber">Season number.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<SeasonImagesResult> GetTVShowSeasonImagesAsync(int tvShowId, int seasonNumber)
        {
            var parameters = new Dictionary<string, object>();

            if (!string.IsNullOrWhiteSpace(_options.ImageFallbackLanguages))
            {
                parameters.Add("include_image_language", _options.ImageFallbackLanguages);
            }

            return GetJsonAsync<SeasonImagesResult>($"/tv/{tvShowId}/season/{seasonNumber}/images", parameters);
        }

        /// <summary>
        /// Get the translation data for a season.
        /// </summary>
        /// <param name="tvShowId">Id of the tv show.</param>
        /// <param name="seasonNumber">Season number.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<TranslationsResult<SeasonTranslationData>> GetTVShowSeasonTranslationsAsync(int tvShowId, int seasonNumber)
        {
            return GetJsonAsync<TranslationsResult<SeasonTranslationData>>($"/tv/{tvShowId}/season/{seasonNumber}/translations");
        }

        /// <summary>
        /// Get the videos that have been added to a TV season.
        /// </summary>
        /// <param name="tvShowId">Id of the TV show.</param>
        /// <param name="seasonNumber">Season number.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<BasicResult<Video>> GetTVShowSeasonVideosAsync(int tvShowId, int seasonNumber)
        {
            return GetJsonAsync<BasicResult<Video>>($"/tv/{tvShowId}/season/{seasonNumber}/videos");
        }

        /// <summary>
        /// Get the TV episode details by id.
        /// </summary>
        /// <param name="tvShowId">Id of the tv show.</param>
        /// <param name="seasonNumber">Season number.</param>
        /// <param name="episodeNumber">Episode number.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<EpisodeDetails> GetTVShowEpisodeDetailsAsync(int tvShowId, int seasonNumber, int episodeNumber)
        {
            return GetJsonAsync<EpisodeDetails>($"/tv/{tvShowId}/season/{seasonNumber}/episode/{episodeNumber}");
        }

        // TODO: TV Episodes: GetTVShowEpisodeAccountStates
        // TODO: TV Episodes: GetTVShowEpisodeChanges

        /// <summary>
        /// Get the credits (cast, crew and guest stars) for a TV episode.
        /// </summary>
        /// <param name="tvShowId">Id of the tv show.</param>
        /// <param name="seasonNumber">Season number.</param>
        /// <param name="episodeNumber">Episode number.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<EpisodeCreditsResult> GetTVShowEpisodeCreditsAsync(int tvShowId, int seasonNumber, int episodeNumber)
        {
            return GetJsonAsync<EpisodeCreditsResult>($"/tv/{tvShowId}/season/{seasonNumber}/episode/{episodeNumber}/credits");
        }

        /// <summary>
        /// Get the external ids for a TV episode.
        /// </summary>
        /// <param name="tvShowId">Id of the tv show.</param>
        /// <param name="seasonNumber">Season number.</param>
        /// <param name="episodeNumber">Episode number.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<EpisodeExternalIds> GetTVShowEpisodeExternalIdsAsync(int tvShowId, int seasonNumber, int episodeNumber)
        {
            return GetJsonAsync<EpisodeExternalIds>($"/tv/{tvShowId}/season/{seasonNumber}/episode/{episodeNumber}/external_ids");
        }

        /// <summary>
        /// Get the images that belong to a TV episode.
        /// </summary>
        /// <param name="tvShowId">Id of the tv show.</param>
        /// <param name="seasonNumber">Season number.</param>
        /// <param name="episodeNumber">Episode number.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<EpisodeImagesResult> GetTVShowEpisodeImagesAsync(int tvShowId, int seasonNumber, int episodeNumber)
        {
            return GetJsonAsync<EpisodeImagesResult>($"/tv/{tvShowId}/season/{seasonNumber}/episode/{episodeNumber}/images");
        }

        /// <summary>
        /// Get the translation data for an episode.
        /// </summary>
        /// <param name="tvShowId">Id of the tv show.</param>
        /// <param name="seasonNumber">Season number.</param>
        /// <param name="episodeNumber">Episode number.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<TranslationsResult<EpisodeTranslationData>> GetTVShowEpisodeTranslationsAsync(int tvShowId, int seasonNumber, int episodeNumber)
        {
            return GetJsonAsync<TranslationsResult<EpisodeTranslationData>>($"/tv/{tvShowId}/season/{seasonNumber}/episode/{episodeNumber}/translations");
        }

        /// <summary>
        /// Rate a tv episode.
        /// </summary>
        /// <param name="tvShowId">The id of the tv show.</param>
        /// <param name="seasonNumber">The season number.</param>
        /// <param name="episodeNumber">The episode number.</param>
        /// <param name="value">The value of the rating which is expected to be between 0.5 and 10.0.</param>
        /// <param name="sessionId">A valid session id.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<Response> SetTVShowEpisodeRatingAsync(int tvShowId, int seasonNumber, int episodeNumber, double value, string sessionId)
        {
            if (string.IsNullOrWhiteSpace(sessionId))
            {
                throw new ArgumentException($"'{nameof(sessionId)}' cannot be null or whitespace.", nameof(sessionId));
            }

            var parameters = new Dictionary<string, object>()
            {
                ["session_id"] = sessionId,
            };

            var request = new
            {
                value = value,
            };

            return PostJsonAsync<Response>($"/tv/{tvShowId}/season/{seasonNumber}/episode/{episodeNumber}/rating", parameters, request);
        }

        /// <summary>
        /// Remove your rating for a tv episode.
        /// </summary>
        /// <param name="tvShowId">The id of the tv show.</param>
        /// <param name="seasonNumber">The season number.</param>
        /// <param name="episodeNumber">The episode number.</param>
        /// <param name="sessionId">A valid session id.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<Response> DeleteTVShowEpisodeRatingAsync(int tvShowId, int seasonNumber, int episodeNumber, string sessionId)
        {
            if (string.IsNullOrWhiteSpace(sessionId))
            {
                throw new ArgumentException($"'{nameof(sessionId)}' cannot be null or whitespace.", nameof(sessionId));
            }

            var parameters = new Dictionary<string, object>()
            {
                ["session_id"] = sessionId,
            };

            return DeleteJsonAsync<Response>($"/tv/{tvShowId}/season/{seasonNumber}/episode/{episodeNumber}/rating", parameters);
        }

        /// <summary>
        /// Get the videos that have been added to a TV episode.
        /// </summary>
        /// <param name="tvShowId">Id of the tv show.</param>
        /// <param name="seasonNumber">Season number.</param>
        /// <param name="episodeNumber">Episode number.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<BasicResult<Video>> GetTVShowEpisodeVideosAsync(int tvShowId, int seasonNumber, int episodeNumber)
        {
            return GetJsonAsync<BasicResult<Video>>($"/tv/{tvShowId}/season/{seasonNumber}/episode/{episodeNumber}/videos");
        }

        /// <summary>
        /// Get the details of a TV episode group. See remarks.
        /// </summary>
        /// <remarks>
        /// Groups support 7 different types which are enumerated as the following:
        /// <list type="number">
        /// <item>Original air date</item>
        /// <item>Absolute</item>
        /// <item>DVD</item>
        /// <item>Digital</item>
        /// <item>Story arc</item>
        /// <item>Production</item>
        /// <item>TV</item>
        /// </list>
        /// </remarks>
        /// <param name="episodeGroupId">If of the episode group.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task<EpisodeGroupDetails> GetTVShowEpisodeGroupsDetailsAsync(string episodeGroupId)
        {
            return GetJsonAsync<EpisodeGroupDetails>($"/tv/episode_group/{episodeGroupId}");
        }

        /// <summary>
        /// Get url of a poster image.
        /// </summary>
        /// <param name="filename">Poster file name.</param>
        /// <param name="size">Size of the poster.</param>
        /// <returns>A string containing full path of the poster.</returns>
        /// <exception cref="ArgumentException">
        /// <paramref name="filename" /> should not be null or empty.
        /// </exception>
        public string GetPosterImageUrl(string filename, PosterSize size = PosterSize.W500)
            => GetImageUrl(filename, size.ToString());

        /// <summary>
        /// Get url of a backdrop image.
        /// </summary>
        /// <param name="filename">Backdrop file name.</param>
        /// <param name="size">Size of the backdrop.</param>
        /// <returns>A string containing full path of the backdrop.</returns>
        /// <exception cref="ArgumentException">
        /// <paramref name="filename" /> should not be null or empty.
        /// </exception>
        public string GetBackdropImageUrl(string filename, BackdropSize size = BackdropSize.W1280)
            => GetImageUrl(filename, size.ToString());

        /// <summary>
        /// Get url of a profile image.
        /// </summary>
        /// <param name="filename">Profile image file name.</param>
        /// <param name="size">Size of the profile image.</param>
        /// <returns>A string containing full path of the profile image.</returns>
        /// <exception cref="ArgumentException">
        /// <paramref name="filename" /> should not be null or empty.
        /// </exception>
        public string GetProfileImageUrl(string filename, ProfileSize size = ProfileSize.W185)
            => GetImageUrl(filename, size.ToString());

        /// <summary>
        /// Get url of a still image.
        /// </summary>
        /// <param name="filename">Still image file name.</param>
        /// <param name="size">Size of the still image.</param>
        /// <returns>A string containing full path of the still image.</returns>
        /// <exception cref="ArgumentException">
        /// <paramref name="filename" /> should not be null or empty.
        /// </exception>
        public string GetStillImageUrl(string filename, StillSize size = StillSize.W300)
            => GetImageUrl(filename, size.ToString());

        /// <summary>
        /// Get url of a logo image.
        /// </summary>
        /// <param name="filename">Logo image file name.</param>
        /// <param name="size">Size of the logo image.</param>
        /// <returns>A string containing full path of the logo image.</returns>
        /// <exception cref="ArgumentException">
        /// <paramref name="filename" /> should not be null or empty.
        /// </exception>
        public string GetLogoImageUrl(string filename, LogoSize size = LogoSize.W300)
            => GetImageUrl(filename, size.ToString());

        private string GetImageUrl(string filePath, string size)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException($"'{nameof(filePath)}' cannot be null or empty.", nameof(filePath));
            }

            return $"{_options.ImageAddress}/{size.ToLowerInvariant()}{filePath}";
        }

        private static string GetParametersString(Dictionary<string, object> parameters)
        {
            var builder = new StringBuilder();

            foreach (var item in parameters)
            {
                builder.Append(builder.Length == 0 ? "?" : "&");
                builder.Append($"{item.Key}={item.Value}");
            }

            return builder.ToString();
        }

        private async Task<T> DeleteJsonAsync<T>(string requestUrl, object obj)
            where T : Response
        {
            using var request = CreateRequest(HttpMethod.Delete, requestUrl, null);

            string json = JsonConvert.SerializeObject(obj);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");

            return await SendRequestAsync<T>(request)
                .ConfigureAwait(false);
        }

        private async Task<T> DeleteJsonAsync<T>(string requestUrl, Dictionary<string, object> parameters)
            where T : Response
        {
            using var request = CreateRequest(HttpMethod.Delete, requestUrl, parameters);

            return await SendRequestAsync<T>(request)
                .ConfigureAwait(false);
        }

        private async Task<T> PostJsonAsync<T>(string requestUrl, object obj)
            where T : Response
        {
            using var request = CreateRequest(HttpMethod.Post, requestUrl, null);

            string json = JsonConvert.SerializeObject(obj);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");

            return await SendRequestAsync<T>(request)
                .ConfigureAwait(false);
        }

        private async Task<T> PostJsonAsync<T>(string requestUrl, Dictionary<string, object> parameters, object obj)
            where T : Response
        {
            using var request = CreateRequest(HttpMethod.Post, requestUrl, parameters);

            string json = JsonConvert.SerializeObject(obj);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");

            return await SendRequestAsync<T>(request)
                .ConfigureAwait(false);
        }

        private async Task<T> GetJsonAsync<T>(string requestUrl, Dictionary<string, object> parameters = null)
            where T : Response
        {
            using var request = CreateRequest(HttpMethod.Get, requestUrl, parameters);

            return await SendRequestAsync<T>(request)
                .ConfigureAwait(false);
        }

        private HttpRequestMessage CreateRequest(HttpMethod httpMethod, string requestUrl, Dictionary<string, object> parameters)
        {
            string url = _options.ApiAddress + requestUrl;

            if (parameters is null)
            {
                parameters = new Dictionary<string, object>();
            }

            parameters.Add("api_key", _options.ApiKey);

            if (!parameters.ContainsKey("language") &&
                !string.IsNullOrWhiteSpace(_options.Language))
            {
                parameters.Add("language", _options.Language);
            }

            if (_options.IsAdultIncluded.HasValue)
            {
                parameters.Add("include_adult", _options.IsAdultIncluded);
            }

            url += GetParametersString(parameters);

            return new HttpRequestMessage(httpMethod, url);
        }

        private async Task<T> SendRequestAsync<T>(HttpRequestMessage request)
            where T : Response
        {
            // Set the user agent if it was explicitly set via the options.
            // This overrides the default request headers.
            if (_options.ProductInformation != null)
            {
                request.Headers.UserAgent.Add(new ProductInfoHeaderValue(_options.ProductInformation));
            }

            using var response = await _httpClient.SendAsync(request)
                .ConfigureAwait(false);

            if (_options.UseEnsureSuccessStatusCode)
            {
                response.EnsureSuccessStatusCode();
            }

            string json = await response.Content.ReadAsStringAsync()
                .ConfigureAwait(false);

            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}

// TODO: Add Region to options, Note: some methods already have region parameter.
