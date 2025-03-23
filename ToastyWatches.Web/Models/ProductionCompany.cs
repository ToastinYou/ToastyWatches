namespace ToastyWatches.Web.Models;

public class ProductionCompany
{
    public int Id { get; set; }
    /// <summary>
    /// The path to the logo of the production company.
    /// </summary>
    public string LogoPath { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// The origin country of the production company.
    /// </summary>
    public string OriginCountry { get; set; } = string.Empty;
}
