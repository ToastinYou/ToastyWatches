using System.Net.Http.Headers;
using System.Text.Json;
using ToastyWatches.Web.Entities;
using ToastyWatches.Web.Helpers;
using ToastyWatches.Web.Models;

namespace ToastyWatches.Web.Services;

public class MovieDbService(MovieDeserializer movieDeserializer, JsonSerializerOptions serializerOptions, HttpClient httpClient, ILogger<MovieDbService> logger)
{
    private readonly MediaTypeWithQualityHeaderValue acceptHeader = new("application/json");
    private readonly AuthenticationHeaderValue authorizationHeader = new("Bearer", Environment.GetEnvironmentVariable("MOVIE_DB_API_KEY") ?? throw new InvalidOperationException("MOVIE_DB_API_KEY environment variable is not set."));

    private async Task<string> GetResponseAsync(string url)
    {
        HttpRequestMessage request = new(HttpMethod.Get, new Uri(url));
        request.Headers.Accept.Add(acceptHeader);
        request.Headers.Authorization = authorizationHeader;

        using HttpResponseMessage response = await httpClient.SendAsync(request);

        if (!response.IsSuccessStatusCode)
        {
            var s = await response.Content.ReadAsStringAsync();
            ErrorResponse? errorResponse = JsonSerializer.Deserialize<ErrorResponse>(await response.Content.ReadAsStringAsync());
            throw new InvalidOperationException(errorResponse?.StatusMessage);
        }

        return await response.Content.ReadAsStringAsync();
    }

    public async Task<List<Movie>> GetMoviesAsync()
    {
        try
        {
            string content = await GetResponseAsync("https://api.themoviedb.org/3/discover/movie?language=en-US&page=1&sort_by=popularity.desc");
            return movieDeserializer.DeserializeMovies(content);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while fetching movies: {Message}", ex.Message);
            throw;
        }
    }

    public async Task<Movie> GetMovieAsync(int id)
    {
        try
        {
            string content = await GetResponseAsync($"https://api.themoviedb.org/3/movie/{id}?language=en-US");
            return movieDeserializer.DeserializeMovie(content) ?? throw new InvalidOperationException("Movie not found.");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while fetching movie (ID {ID}): {Message}", id, ex.Message);
            throw;
        }
    }

    public async Task<List<Movie>> SearchMoviesAsync(MovieSearch filters)
    {
        try
        {
            string queryParams = JsonSerializer.Serialize(filters, serializerOptions);
            string queryString = string.Join("&", JsonDocument.Parse(queryParams).RootElement.EnumerateObject()
                .Where(e => e.Value.ValueKind != JsonValueKind.Null)
                .Select(e => $"{e.Name}={e.Value}"));
            string content = await GetResponseAsync($"https://api.themoviedb.org/3/search/movie?language=en-US&{queryString}");
            return movieDeserializer.DeserializeMovies(content);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while searching movies for '{Query}': {Message}", JsonSerializer.Serialize(filters), ex.Message);
            throw;
        }
    }
}
