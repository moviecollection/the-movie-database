# The Movie Database API
Unofficial implementation of The Movie Database API for .NET

[![NuGet Version][nuget-shield]][nuget]
[![NuGet Downloads][nuget-shield-dl]][nuget]

## Installation
You can install this package via the `Package Manager Console` in Visual Studio.

```powershell
Install-Package MovieCollection.TheMovieDatabase -PreRelease
```

## Configuration
Get or create a new static `HttpClient` instance if you don't have one already.

```csharp
// HttpClient lifecycle management best practices:
// https://learn.microsoft.com/dotnet/fundamentals/networking/http/httpclient-guidelines#recommended-use
private static readonly HttpClient httpClient = new HttpClient();
```

Then, you need to set your api key and pass it to the service's constructor.

```csharp
// using MovieCollection.TheMovieDatabase;

var options = new TheMovieDatabaseOptions
{
    ApiKey = "your-api-key",
};

var service = new TheMovieDatabaseService(httpClient, options);
```

## Search Movies
You can search for movies via the `SearchMoviesAsync` method.

```csharp
var search = new NewSearchMovie
{
    Query = "the boy and the heron",
};

var result = await service.SearchMoviesAsync(search);
```

## Search TV Shows
You can search for tv shows via the `SearchTVShowsAsync` method.

```csharp
var search = new NewSearchTVShow
{
    Query = "shogun",
};

var result = await service.SearchTVShowsAsync(search);
```

## Movie Details
You can get movie details via the `GetMovieDetailsAsync` method.

```csharp
var item = await service.GetMovieDetailsAsync(508883);
```

## TV Show Details
You can get tv show details via the `GetTVShowDetailsAsync` method.

```csharp
var item = await service.GetTVShowDetailsAsync(126308);
```

Please see the demo project for more examples.

## Limitations
- Some methods has not been implemented. 
- Some combined results has not been implemented (e.g. KnownFor).

## Notes
- Please read [The Movie Database][tmdb]'s [terms of use][tmdb-terms] before using their services.

## License
This project is licensed under the [MIT License](LICENSE).

[nuget]: https://www.nuget.org/packages/MovieCollection.TheMovieDatabase
[nuget-shield]: https://img.shields.io/nuget/v/MovieCollection.TheMovieDatabase.svg?label=NuGet
[nuget-shield-dl]: https://img.shields.io/nuget/dt/MovieCollection.TheMovieDatabase?label=Downloads&color=red

[tmdb]: https://www.themoviedb.org
[tmdb-terms]: https://www.themoviedb.org/documentation/api/terms-of-use