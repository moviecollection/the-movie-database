using System;
using System.Net.Http;
using Xunit;

namespace MovieCollection.TheMovieDatabase.Tests
{
    public class BasicTests
    {
        private readonly HttpClient _httpClient;

        public BasicTests()
        {
            _httpClient = new HttpClient();
        }

        [Fact]
        public void ShouldThrowExceptionWhenOptionsIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var service = new TheMovieDatabaseService(_httpClient, null);
            });
        }

        [Fact]
        public void ShouldThrowExceptionWhenHttpClientIsNull()
        {
            var options = new TheMovieDatabaseOptions();

            Assert.Throws<ArgumentNullException>(() =>
            {
                var service = new TheMovieDatabaseService(null, options);
            });
        }

        [Fact]
        public void ShouldThrowExceptionWhenApiAddressIsNullOrWhiteSpace()
        {
            var options = new TheMovieDatabaseOptions
            {
                ApiAddress = null,
                ApiKey = "something",
                ImageAddress = "something",
            };

            Assert.Throws<ArgumentException>(() =>
            {
                var service = new TheMovieDatabaseService(_httpClient, options);
            });
        }

        [Fact]
        public void ShouldThrowExceptionWhenImageAddressIsNullOrWhiteSpace()
        {
            var options = new TheMovieDatabaseOptions
            {
                ImageAddress = null,
                ApiKey = "something",
                ApiAddress = "something",
            };

            Assert.Throws<ArgumentException>(() =>
            {
                var service = new TheMovieDatabaseService(_httpClient, options);
            });
        }

        [Fact]
        public void ShouldThrowExceptionWhenApiKeyIsNullOrWhiteSpace()
        {
            var options = new TheMovieDatabaseOptions
            {
                ApiKey = null,
            };

            Assert.Throws<ArgumentException>(() =>
            {
                var service = new TheMovieDatabaseService(_httpClient, options);
            });
        }
    }
}
