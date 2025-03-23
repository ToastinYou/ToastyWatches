using System.Text.Json.Serialization;

namespace ToastyWatches.Web.Entities;

public class ErrorResponse
{
    public bool Success { get; set; }
    public int? StatusCode { get; set; }
    public string? StatusMessage { get; set; } = string.Empty;
}
