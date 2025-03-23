using System.Text.Json.Serialization;

namespace ToastyWatches.Web.Models;

public class Movie
{
    /// <summary>
    /// Indicates if the movie is for adults.
    /// </summary>
    public bool? Adult { get; set; }
    /// <summary>
    /// The backdrop path of the movie.
    /// </summary>
    public string BackdropPath { get; set; } = string.Empty;
    /// <summary>
    /// The collection the movie belongs to.
    /// </summary>
    public string BelongsToCollection { get; set; } = string.Empty;
    public int Budget { get; set; }
    //public List<Genre> Genres { get; set; } = [];
    public string Homepage { get; set; } = string.Empty;
    public int Id { get; set; }
    public string ImdbId { get; set; } = string.Empty;
    public string OriginalLanguage { get; set; } = string.Empty;
    public string OriginalTitle { get; set; } = string.Empty;
    public string Overview { get; set; } = string.Empty;
    public double Popularity { get; set; }
    /// <summary>
    /// The path to the movie's poster.
    /// </summary>
    public string PosterPath { get; set; } = string.Empty;
    //public List<ProductionCompany> ProductionCompanies { get; set; } = [];
    //public List<ProductionCountry> ProductionCountries { get; set; } = [];
    public string ReleaseDate { get; set; } = string.Empty;
    /// <summary>
    /// The revenue of the movie in dollars.
    /// </summary>
    public int Revenue { get; set; }
    /// <summary>
    /// The runtime of the movie in minutes.
    /// </summary>
    public int Runtime { get; set; }
    //public List<SpokenLanguage> SpokenLanguages { get; set; } = [];
    public string Status { get; set; } = string.Empty;
    public string Tagline { get; set; } = string.Empty;
    public string? Title { get; set; }
    /// <summary>
    /// Indicates if the movie has a video.
    /// </summary>
    public bool Video { get; set; }
    /// <summary>
    /// The average vote of the movie.
    /// </summary>
    public double VoteAverage { get; set; }
    /// <summary>
    /// The number of votes the movie has received.
    /// </summary>
    public int VoteCount { get; set; }
}
