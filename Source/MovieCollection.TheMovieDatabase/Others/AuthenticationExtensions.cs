namespace MovieCollection.TheMovieDatabase
{
    using System;
    using MovieCollection.TheMovieDatabase.Models;

    /// <summary>
    /// Authentication extensions.
    /// </summary>
    public static class AuthenticationExtensions
    {
        /// <summary>
        /// Gets the authentication url to approve a request token.
        /// </summary>
        /// <param name="result">The request token result.</param>
        /// <param name="redirectTo">A url to redirect to after user approved the request token.</param>
        /// <returns>A string contaning the url to authenticate the user.</returns>
        public static string GetAuthenticationUrl(this RequestTokenResult result, string redirectTo = null)
        {
            if (result is null)
            {
                throw new ArgumentNullException(nameof(result));
            }

            string url = $"https://www.themoviedb.org/authenticate/{result.RequestToken}";

            if (!string.IsNullOrWhiteSpace(redirectTo))
            {
                url += $"?redirect_to={redirectTo}";
            }

            return url;
        }
    }
}
