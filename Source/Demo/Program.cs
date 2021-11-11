using System;
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

            Console.Write("\nPlease select an option: ");
            int input = Convert.ToInt32(Console.ReadLine());

            Console.Clear();

            switch (input)
            {
                default:
                case 1:
                    await GetMovieDetailsAsync();
                    break;
                case 2:
                    await GetTVShowDetailsAsync();
                    break;
                case 3:
                    await GetMovieImagesAsync();
                    break;
                case 4:
                    await GetTVShowImagesAsync();
                    break;
                case 5:
                    await GetMovieRecommendationsAsync();
                    break;
                case 6:
                    await GetTVShowRecommendationsAsync();
                    break;
                case 7:
                    await GetCollectionDetailsAsync();
                    break;
                case 8:
                    await GetPersonMovieCreditsAsync();
                    break;
                case 9:
                    await GetPersonTVShowCreditsAsync();
                    break;
                case 10:
                    await GetPersonCombinedCreditsAsync();
                    break;
                case 11:
                    await DiscoverMoviesAsync();
                    break;
                case 12:
                    await DiscoverTVShowsAsync();
                    break;
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
    }
}
