using SQLite;

namespace CityExplorer.Models;

public class FavoriteAttraction
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public int AttractionId { get; set; }

    public string Name { get; set; } = "";
    public string Description { get; set; } = "";

    public string Category { get; set; } = "";
    public string ImageUrl { get; set; } = "";
}