using System.Threading.Tasks;
using PublicApiGenerator;
using VerifyXunit;
using Xunit;

namespace MovieCollection.TheMovieDatabase.Tests
{
    public class PublicApiTests
    {
        [Fact]
        public Task PublicApiShouldNotChange()
        {
            var publicApi = typeof(TheMovieDatabaseService).Assembly
                .GeneratePublicApi();

            return Verifier.Verify(publicApi);
        }
    }
}
