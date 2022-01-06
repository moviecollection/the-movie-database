# The Movie Database API
Unofficial implementation of The Movie Database API for .NET

[![Nuget Version][nuget-shield]][nuget]
[![Nuget Downloads][nuget-shield-dl]][nuget]

## Installing
You can install this package by entering the following command into your `Package Manager Console`:
```powershell
Install-Package MovieCollection.TheMovieDatabase -PreRelease
```

## How to use
First, define an instance of the `HttpClient` class if you haven't already.
```csharp
// HttpClient is intended to be instantiated once per application, rather than per-use.
// See https://docs.microsoft.com/en-us/dotnet/api/system.net.http.httpclient
private static readonly HttpClient httpClient = new HttpClient();
```

Then, for searching movies:

```csharp
// using MovieCollection.TheMovieDatabase;

var options = new TheMovieDatabaseOptions("your-api-key-here");
var service = new TheMovieDatabaseService(httpClient, options);

var search = await service.SearchMoviesAsync("Avengers: Endgame");

foreach (var item in search.Results)
{
    Console.WriteLine("Title: {0}", item.Title);
    Console.WriteLine("ReleaseDate: {0}", item.ReleaseDate);
    Console.WriteLine("Overview: {0}", item.Overview);
    Console.WriteLine("******************************");
}

// Title: Avengers: Endgame
// ReleaseDate: 2019-04-24
// Overview: After the devastating events of...
```

Please checkout the demo project for more examples.

## Limitations
- Some methods has not been implemented. 
- Some combined results has not been implemented (e.g. KnownFor).

## Notes
- Thanks to [The Movie Database][tmdb] for providing free API services. 
- Please read The Movie Database's [terms of use][tmdb-terms] before using their API.

## License
This project is licensed under the [MIT License](LICENSE).

[nuget]: https://www.nuget.org/packages/MovieCollection.TheMovieDatabase
[nuget-shield]: https://img.shields.io/nuget/v/MovieCollection.TheMovieDatabase.svg?label=Release
[nuget-shield-dl]: https://img.shields.io/nuget/dt/MovieCollection.TheMovieDatabase?label=Downloads&color=red

[tmdb]: https://www.themoviedb.org
[tmdb-terms]: https://www.themoviedb.org/documentation/api/terms-of-use