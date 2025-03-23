using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using System.Net;
using System.Text.Json;
using ToastyWatches.Web.Helpers;
using ToastyWatches.Web.Models;

namespace ToastyWatches.Web.Services.Tests;

public class MovieDbServiceTests
{
    private readonly MovieDeserializer _movieDeserializer;
    private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;
    private readonly HttpClient _httpClient;
    private readonly Mock<ILogger<MovieDbService>> _loggerMock;
    private readonly MovieDbService _movieDbService;

    public MovieDbServiceTests()
    {
        JsonSerializerOptions jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        _movieDeserializer = new MovieDeserializer(jsonOptions);
        _httpMessageHandlerMock = new Mock<HttpMessageHandler>();
        _httpClient = new HttpClient(_httpMessageHandlerMock.Object);
        _loggerMock = new Mock<ILogger<MovieDbService>>();
        _movieDbService = new MovieDbService(_movieDeserializer, jsonOptions, _httpClient, _loggerMock.Object);
    }

    [Fact]
    public async Task GetMoviesAsync_ReturnsMovies_WhenSuccessful()
    {
        // Arrange
        string content = @"{""results"":[{""adult"":false,""backdrop_path"":""/8YFL5QQVPy3AgrEQxNYVSgiPEbe.jpg"",""genre_ids"":[28,12,878],""id"":640146,""original_language"":""en"",""original_title"":""Ant-Man and the Wasp: Quantumania"",""overview"":""Super-Hero partners Scott Lang and Hope van Dyne, along with with Hope's parents Janet van Dyne and Hank Pym, and Scott's daughter Cassie Lang, find themselves exploring the Quantum Realm, interacting with strange new creatures and embarking on an adventure that will push them beyond the limits of what they thought possible."",""popularity"":9272.643,""poster_path"":""/ngl2FKBlU4fhbdsrtdom9LVLBXw.jpg"",""release_date"":""2023-02-15"",""title"":""Ant-Man and the Wasp: Quantumania"",""video"":false,""vote_average"":6.5,""vote_count"":1856},{""adult"":false,""backdrop_path"":""/iJQIbOPm81fPEGKt5BPuZmfnA54.jpg"",""genre_ids"":[16,12,10751,14,35],""id"":502356,""original_language"":""en"",""original_title"":""The Super Mario Bros. Movie"",""overview"":""While working underground to fix a water main, Brooklyn plumbers—and brothers—Mario and Luigi are transported down a mysterious pipe and wander into a magical new world. But when the brothers are separated, Mario embarks on an epic quest to find Luigi."",""popularity"":7212.464,""poster_path"":""/qNBAXBIQlnOThrVvA6mA2B5ggV6.jpg"",""release_date"":""2023-04-05"",""title"":""The Super Mario Bros. Movie"",""video"":false,""vote_average"":7.5,""vote_count"":1435}]}";

        _httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                nameof(_httpClient.SendAsync),
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(content)
            });

        // Act
        List<Movie> result = await _movieDbService.GetMoviesAsync();

        // Assert
        Assert.NotNull(result);
        Assert.NotEmpty(result);
        Assert.Equal(2, result.Count);
        Assert.Equal("Ant-Man and the Wasp: Quantumania", result[0].Title);
        Assert.Equal("The Super Mario Bros. Movie", result[1].Title);
    }

    [Fact]
    public async Task GetMoviesAsync_ThrowsException_WhenUnsuccessful()
    {
        // Arrange
        string content = @"{""success"": false}";

        _httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                nameof(_httpClient.SendAsync),
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound,
                Content = new StringContent(content)
            });

        // Act
        async Task Act() => await _movieDbService.GetMoviesAsync();

        // Assert
        await Assert.ThrowsAsync<InvalidOperationException>(Act);
    }

    [Fact]
    public async Task GetMovieAsync_ReturnsMovie_WhenSuccessful()
    {
        // Arrange
        int id = 123;
        string content = @"{""adult"":false,""backdrop_path"":""/TXSxV23MWYkezZ3219gtgcSX6n.jpg"",""belongs_to_collection"":null,""budget"":4000000,""genres"":[{""id"":12,""name"":""Adventure""},{""id"":16,""name"":""Animation""},{""id"":14,""name"":""Fantasy""}],""homepage"":"""",""id"":123,""imdb_id"":""tt0077869"",""origin_country"":[""GB"",""US""],""original_language"":""en"",""original_title"":""The Lord of the Rings"",""overview"":""The Fellowship of the Ring embark on a journey to destroy the One Ring and end Sauron's reign over Middle-earth."",""popularity"":30.767,""poster_path"":""/liW0mjvTyLs7UCumaHhx3PpU4VT.jpg"",""production_companies"":[{""id"":286,""logo_path"":null,""name"":""Fantasy Films"",""origin_country"":""""},{""id"":4921,""logo_path"":null,""name"":""Bakshi Productions"",""origin_country"":""""},{""id"":141322,""logo_path"":null,""name"":""Saul Zaentz Film Productions"",""origin_country"":""""},{""id"":60,""logo_path"":""/4YldLvCWQL9VIAHQ2Fu3Ffkh9Si.png"",""name"":""United Artists"",""origin_country"":""US""}],""production_countries"":[{""iso_3166_1"":""GB"",""name"":""United Kingdom""},{""iso_3166_1"":""US"",""name"":""United States of America""}],""release_date"":""1978-11-15"",""revenue"":30500000,""runtime"":132,""spoken_languages"":[{""english_name"":""English"",""iso_639_1"":""en"",""name"":""English""}],""status"":""Released"",""tagline"":""Fantasy...beyond your imagination"",""title"":""The Lord of the Rings"",""video"":false,""vote_average"":6.584,""vote_count"":921}";

        _httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                nameof(_httpClient.SendAsync),
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(content)
            });

        // Act
        Movie result = await _movieDbService.GetMovieAsync(id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("The Lord of the Rings", result.Title);
    }

    [Fact]
    public async Task GetMovieAsync_ThrowsException_InvalidId()
    {
        // Arrange
        int id = 0;
        string content = @"{""success"": false, ""status_code"": 6, ""status_message"": ""Invalid id: The pre-requisite id is invalid or not found.""}";

        _httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                nameof(_httpClient.SendAsync),
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound,
                Content = new StringContent(content)
            });

        // Act
        async Task Act() => await _movieDbService.GetMovieAsync(id);

        // Assert
        await Assert.ThrowsAsync<InvalidOperationException>(Act);
    }
}
