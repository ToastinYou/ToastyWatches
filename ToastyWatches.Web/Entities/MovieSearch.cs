namespace ToastyWatches.Web.Entities;

public class MovieSearch
{
    /// <summary>
    /// Use in conjunction with <see cref="Region"/>.
    /// </summary>
    public string? Certification { get; set; }
    /// <summary>
    /// Use in conjunction with <see cref="Region"/>.
    /// </summary>
    public string? CertificationGTE { get; set; }
    /// <summary>
    /// Use in conjunction with <see cref="Region"/>.
    /// </summary>
    public string? CertificationLTE { get; set; }
    /// <summary>
    /// Use in conjunction with the <see cref="Certification"/>, <see cref="CertificationGTE"/>, and <see cref="CertificationLTE"/> filters.
    /// </summary>
    public string? CertificationCountry { get; set; }
    /// <summary>
    /// Defaults to <i>false</i>.
    /// </summary>
    public bool IncludeAdult { get; set; }
    /// <summary>
    /// Defaults to <i>false</i>.
    /// </summary>
    public bool IncludeVideo { get; set; }
    /// <summary>
    /// Defaults to <i>en-US</i>.
    /// </summary>
    public string Language { get; set; } = "en-US";
    /// <summary>
    /// Defaults to <i>1</i>.
    /// </summary>
    public int Page { get; set; } = 1;
    public int? PrimaryReleaseYear { get; set; }
    public DateOnly? PrimaryReleaseDateGTE { get; set; }
    public DateOnly? PrimaryReleaseDateLTE { get; set; }
    public string? Region { get; set; }
    public DateOnly? ReleaseDateGTE { get; set; }
    public DateOnly? ReleaseDateLTE { get; set; }
    /// <summary>
    /// Defaults to <i>popularity.desc</i>.
    /// </summary>
    public string? SortBy { get; set; } = "popularity.desc";
    public float? VoteAverageGTE { get; set; }
    public float? VoteAverageLTE { get; set; }
    public float? VoteCountGTE { get; set; }
    public float? VoteCountLTE { get; set; }
    /// <summary>
    /// Use in conjunction with <see cref="WithWatchMonetizationTypes"/> or <see cref="WithWatchProviders"/>.
    /// </summary>
    public string? WatchRegion { get; set; }
    /// <summary>
    /// Can be a comma (AND) or pipe (OR) separated query.
    /// </summary>
    public string? WithCast { get; set; }
    /// <summary>
    /// Can be a comma (AND) or pipe (OR) separated query.
    /// </summary>
    public string? WithCompanies { get; set; }
    /// <summary>
    /// Can be a comma (AND) or pipe (OR) separated query.
    /// </summary>
    public string? WithCrew { get; set; }
    /// <summary>
    /// Can be a comma (AND) or pipe (OR) separated query.
    /// </summary>
    public string? WithGenres { get; set; }
    /// <summary>
    /// Can be a comma (AND) or pipe (OR) separated query.
    /// </summary>
    public string? WithKeywords { get; set; }
    public string? WithOriginCountry { get; set; }
    public string? WithOriginalLanguage { get; set; }
    /// <summary>
    /// Can be a comma (AND) or pipe (OR) separated query.
    /// </summary>
    public string? WithPeople { get; set; }
    /// <summary>
    /// Possible values are: [1, 2, 3, 4, 5, 6].
    /// Can be a comma (AND) or pipe (OR) separated query.
    /// Can be used in conjunction with <see cref="Region"/>.
    /// </summary>
    public int? WithReleaseType { get; set; }
    public int? WithRuntimeGTE { get; set; }
    public int? WithRuntimeLTE { get; set; }
    /// <summary>
    /// Possible values are: [flatrate, free, ads, rent, buy].
    /// Use in conjunction with <see cref="WatchRegion"/>.
    /// Can be a comma (AND) or pipe (OR) separated query.
    /// </summary>
    public string? WithWatchMonetizationTypes { get; set; }
    /// <summary>
    /// Use in conjunction with <see cref="WatchRegion"/>.
    /// Can be a comma (AND) or pipe (OR) separated query.
    /// </summary>
    public string? WithWatchProviders { get; set; }
    public string? WithoutCompanies { get; set; }
    public string? WithoutGenres { get; set; }
    public string? WithoutKeywords { get; set; }
    public string? WithoutWatchProviders { get; set; }
    public int? Year { get; set; }

}
