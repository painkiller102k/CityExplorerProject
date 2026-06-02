using CityExplorer.Resources.Strings;

namespace CityExplorer.Models;

public class Attraction
{
    public int Id { get; set; }

    public string NameKey { get; set; } = string.Empty;
    public string DescriptionKey { get; set; } = string.Empty;

    public string Category { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;

    public string Name => LocalizationResourceManager.Instance[NameKey];

    public string Description => LocalizationResourceManager.Instance[DescriptionKey];
}