using SQLite;

namespace CityExplorer.Models;

public class FavoriteAttraction
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public int AttractionId { get; set; }

    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public string Category { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
}