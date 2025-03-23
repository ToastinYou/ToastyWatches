using System.Text.Json;
using ToastyWatches.Web.Models;

namespace ToastyWatches.Web.Helpers;

public class MovieDeserializer(JsonSerializerOptions options)
{
    public List<Movie> DeserializeMovies(string json)
    {
        using JsonDocument document = JsonDocument.Parse(json);
        document.RootElement.TryGetProperty("results", out JsonElement results);
        return JsonSerializer.Deserialize<List<Movie>>(results, options) ?? [];
    }

    public Movie? DeserializeMovie(string json)
    {
        using JsonDocument document = JsonDocument.Parse(json);
        return document.Deserialize<Movie>(options);
    }
}
