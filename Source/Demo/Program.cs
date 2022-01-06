using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using MovieCollection.TheMovieDatabase;
using MovieCollection.TheMovieDatabase.Enums;
using MovieCollection.TheMovieDatabase.Models;

namespace Demo
{
    class Program
    {
        // HttpClient is intended to be instantiated once per application, rather than per-use.
        // See https://docs.microsoft.com/en-us/dotnet/api/system.net.http.httpclient
        private static readonly HttpClient _httpClient = new HttpClient();

        private static TheMovieDatabaseOptions _options;
        private static TheMovieDatabaseService _service;

        private static async Task Main()
        {
            _options = new TheMovieDatabaseOptions("your-api-key", "en");
            _service = new TheMovieDatabaseService(_httpClient, _options);

            await InitializeMenu();
        }

        private static async Task InitializeMenu()
        {
Start:
            Console.Clear();
            Console.WriteLine("Welcome to 'The Movie Database' demo.\n");

            Console.WriteLine("1. Get Movie Details.");
            Console.WriteLine("2. Get TV Show Details");
            Console.WriteLine("3. Get Movie Images");
            Console.WriteLine("4. Get TV Show Images");
            Console.WriteLine("5. Get Movie Recommendations");
            Console.WriteLine("6. Get TV Show Recommendations");
            Console.WriteLine("7. Get Collection Details");
            Console.WriteLine("8. Get Person Movie Credits");
            Console.WriteLine("9. Get Person TV Show Credits");
            Console.WriteLine("10. Get Person Combined Credits");
            Console.WriteLine("11. Discover Movies");
            Console.WriteLine("12. Discover TV Shows");
            Console.WriteLine("13. Authenticate");
            Console.WriteLine("14. Get Account Details");

            Console.Write("\nPlease select an option: ");
            int input = Convert.ToInt32(Console.ReadLine());

            Console.Clear();

            var task = input switch
            {
                1 => GetMovieDetailsAsync(),
                2 => GetTVShowDetailsAsync(),
                3 => GetMovieImagesAsync(),
                4 => GetTVShowImagesAsync(),
                5 => GetMovieRecommendationsAsync(),
                6 => GetTVShowRecommendationsAsync(),
                7 => GetCollectionDetailsAsync(),
                8 => GetPersonMovieCreditsAsync(),
                9 => GetPersonTVShowCreditsAsync(),
                10 => GetPersonCombinedCreditsAsync(),
                11 => DiscoverMoviesAsync(),
                12 => DiscoverTVShowsAsync(),
                13 => AuthenticateAsync(),
                14 => GetAccountDetailsAsync(),
                _ => null,
            };

            if (task != null)
            {
                await task;
            }

            // Wait for user to Exit
            Console.WriteLine("Press any key to go back to the menu...");
            Console.ReadKey();

            goto Start;
        }

        private static async Task GetMovieDetailsAsync()
        {
            // Captain Marvel
            var item = await _service.GetMovieDetailsAsync(299537);

            Console.WriteLine("Title: {0}", item.Title);
            Console.WriteLine("ReleaseDate: {0}", item.ReleaseDate);
            Console.WriteLine("Overview: {0}", item.Overview);
            Console.WriteLine("******************************");
        }

        private static async Task GetTVShowDetailsAsync()
        {
            // Fleabag
            var item = await _service.GetTVShowDetailsAsync(67070);

            Console.WriteLine("Name: {0}", item.Name);
            Console.WriteLine("FirstAirDate: {0}", item.FirstAirDate);
            Console.WriteLine("NumberOfSeasons: {0}", item.NumberOfSeasons);
            Console.WriteLine("NumberOfEpisodes: {0}", item.NumberOfEpisodes);
            Console.WriteLine("Overview: {0}", item.Overview);
            Console.WriteLine("******************************");
        }

        private static async Task GetMovieImagesAsync()
        {
            // Captain Marvel
            var items = await _service.GetMovieImagesAsync(299537);

            foreach (var item in items.Posters)
            {
                string posterUrl = _service.GetPosterImageUrl(item.FilePath);
                Console.WriteLine(posterUrl);
            }
        }

        private static async Task GetTVShowImagesAsync()
        {
            // Fleabag
            var items = await _service.GetTVShowImagesAsync(67070);

            foreach (var item in items.Posters)
            {
                string posterUrl = _service.GetPosterImageUrl(item.FilePath);
                Console.WriteLine(posterUrl);
            }
        }

        private static async Task GetMovieRecommendationsAsync()
        {
            // Captain Marvel
            var items = await _service.GetMovieRecommendationsAsync(299537);

            foreach (var item in items.Results)
            {
                Console.WriteLine("Title: {0}", item.Title);
                Console.WriteLine("ReleaseDate: {0}", item.ReleaseDate);
                Console.WriteLine("Overview: {0}", item.Overview);
                Console.WriteLine("******************************");
            }
        }


        private static async Task GetTVShowRecommendationsAsync()
        {
            // Fleabag
            var items = await _service.GetTVShowRecommendationsAsync(67070);

            foreach (var item in items.Results)
            {
                Console.WriteLine("Name: {0}", item.Name);
                Console.WriteLine("FirstAirDate: {0}", item.FirstAirDate);
                Console.WriteLine("Overview: {0}", item.Overview);
                Console.WriteLine("******************************");
            }
        }

        private static async Task GetCollectionDetailsAsync()
        {
            // Avengers
            var collection = await _service.GetCollectionDetailsAsync(86311);

            string posterUrl = _service.GetPosterImageUrl(collection.PosterPath, PosterSize.Original);

            Console.WriteLine("Name: {0}", collection.Name);
            Console.WriteLine("Overview: {0}", collection.Overview);
            Console.WriteLine("PosterPath: {0}", posterUrl);

            foreach (var part in collection.Parts)
            {
                Console.WriteLine("\n- Title: {0}", part.Title);
                Console.WriteLine("- ReleaseDate: {0}", part.ReleaseDate);
                Console.WriteLine("- Overview: {0}", part.Overview);
                Console.WriteLine("******************************");
            }
        }

        private static async Task GetPersonMovieCreditsAsync()
        {
            // Cate Blanchett
            var result = await _service.GetPersonMovieCreditsAsync(112);

            Console.WriteLine("- As Cast:");

            foreach (var item in result.Cast)
            {
                Console.WriteLine("Title: {0}", item.Title);
                Console.WriteLine("Character: {0}", item.Character);
                Console.WriteLine("******************************");
            }

            Console.WriteLine("\n- As Crew:\n");

            foreach (var item in result.Crew)
            {
                Console.WriteLine("Title: {0}", item.Title);
                Console.WriteLine("Job: {0}", item.Job);
                Console.WriteLine("Department: {0}", item.Department);
                Console.WriteLine("******************************");
            }
        }

        private static async Task GetPersonTVShowCreditsAsync()
        {
            // Phoebe Waller-Bridge
            var result = await _service.GetPersonTVShowCreditsAsync(1023483);

            Console.WriteLine("- As Cast:");

            foreach (var item in result.Cast)
            {
                Console.WriteLine("Name: {0}", item.Name);
                Console.WriteLine("Character: {0}", item.Character);
                Console.WriteLine("EpisodeCount: {0}", item.EpisodeCount);
                Console.WriteLine("******************************");
            }

            Console.WriteLine("\n- As Crew:\n");

            foreach (var item in result.Crew)
            {
                Console.WriteLine("Name: {0}", item.Name);
                Console.WriteLine("Job: {0}", item.Job);
                Console.WriteLine("Department: {0}", item.Department);
                Console.WriteLine("EpisodeCount: {0}", item.EpisodeCount);
                Console.WriteLine("******************************");
            }
        }

        private static async Task GetPersonCombinedCreditsAsync()
        {
            // Benedict Cumberbatch
            var result = await _service.GetPersonCombinedCreditsAsync(71580);

            foreach (var item in result.Cast)
            {
                if (item.MediaType == "movie")
                {
                    Console.WriteLine("Title: {0}", item.Title);
                    Console.WriteLine("ReleaseDate: {0}", item.ReleaseDate);
                }
                else
                {
                    Console.WriteLine("Name: {0}", item.Name);
                    Console.WriteLine("FirstAirDate: {0}", item.FirstAirDate);
                    Console.WriteLine("EpisodeCount: {0}", item.EpisodeCount);
                }

                Console.WriteLine("MediaType: {0}", item.MediaType);
                Console.WriteLine("Character: {0}", item.Character);
                Console.WriteLine("******************************");
            }
        }

        private static async Task DiscoverMoviesAsync()
        {
            var discover = new NewDiscoverMovie
            {
                SortBy = NewDiscoverMovie.SortOptions.ReleaseDate,
            };

            var items = await _service.DiscoverMoviesAsync(discover);

            foreach (var item in items.Results)
            {
                Console.WriteLine("Title: {0}", item.Title);
                Console.WriteLine("ReleaseDate: {0}", item.ReleaseDate);
                Console.WriteLine("Overview: {0}", item.Overview);
                Console.WriteLine("******************************");
            }
        }

        private static async Task DiscoverTVShowsAsync()
        {
            var discover = new NewDiscoverTVShow
            {
                SortBy = NewDiscoverTVShow.SortOptions.FirstAirDate,
            };

            var items = await _service.DiscoverTVShowsAsync(discover);

            foreach (var item in items.Results)
            {
                Console.WriteLine("Name: {0}", item.Name);
                Console.WriteLine("FirstAirDate: {0}", item.FirstAirDate);
                Console.WriteLine("Overview: {0}", item.Overview);
                Console.WriteLine("******************************");
            }
        }

        // This is used for caching the session id.
        private static string sessionId = string.Empty;

        private static async Task AuthenticateAsync()
        {
            if (!string.IsNullOrEmpty(sessionId))
            {
                Console.WriteLine("You're already logged in.");
                return;
            }

            // Step 1: Create a request token.
            var result = await _service.CreateRequestTokenAsync();

            Console.WriteLine("Success: {0}", result.Success);
            Console.WriteLine("ExpiresAt: {0}", result.ExpiresAt);
            Console.WriteLine("RequestToken: {0}", result.RequestToken);

            // Step 2: Ask for the user permission.
            var url = result.GetAuthenticationUrl();

            // Open the browser to authenticate.
            var info = new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            };

            Process.Start(info);

            // Wait for the user to complete the login.
            Console.WriteLine("\nPress any key after you approved the request...\n");
            Console.ReadKey();

            // Step 3: Create a session id.
            var session = await _service.CreateSessionAsync(result.RequestToken);

            Console.WriteLine("Success: {0}", session.Success);
            Console.WriteLine("SessionId: {0}", session.SessionId);

            // Store the session id.
            sessionId = session.SessionId;
        }

        private static async Task GetAccountDetailsAsync()
        {
            if (string.IsNullOrEmpty(sessionId))
            {
                Console.WriteLine("Please log in first.");
                return;
            }

            var account = await _service.GetAccountDetailsAsync(sessionId);

            Console.WriteLine("Id: {0}", account.Id);
            Console.WriteLine("Name: {0}", account.Name);
            Console.WriteLine("Username: {0}", account.Username);
            Console.WriteLine("Iso639_1: {0}", account.Iso639_1);
            Console.WriteLine("Iso3166_1: {0}", account.Iso3166_1);
            Console.WriteLine("IncludeAdult: {0}", account.IncludeAdult);
        }
    }
}
