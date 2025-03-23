namespace ToastyWatches.Web.Models;

public class ProductionCountry
{
    /// <summary>
    /// The ISO 3166-1 code of the country.
    /// </summary>
    public string Iso31661 { get; set; } = string.Empty;
    /// <summary>
    /// The name of the country.
    /// </summary>
    public string Name { get; set; } = string.Empty;
}
