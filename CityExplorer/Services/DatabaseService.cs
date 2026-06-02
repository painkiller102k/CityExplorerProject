using SQLite;
using CityExplorer.Models;
using System.IO;

namespace CityExplorer.Services;

public class DatabaseService
{
    private SQLiteAsyncConnection? _database;

    private async Task Init()
    {
        if (_database != null)
            return;

        _database = new SQLiteAsyncConnection(
            DatabaseConstants.DatabasePath,
            DatabaseConstants.Flags);

        await _database.CreateTableAsync<Attraction>();
        await _database.CreateTableAsync<FavoriteAttraction>();

        // 🔥 добавляем данные один раз
        await SeedAttractions();
    }

    private async Task SeedAttractions()
    {
        var count = await _database!.Table<Attraction>().CountAsync();
        if (count > 0) return;

        var items = new List<Attraction>
        {
            new()
            {
                Id = 1,
                NameKey = "Attraction1_Name",
                DescriptionKey = "Attraction1_Desc",
                Category = "🌳",
                ImageUrl = "https://media.voog.com/0000/0041/5045/photos/image001_block.jpg"
            },
            new()
            {
                Id = 2,
                NameKey = "Attraction2_Name",
                DescriptionKey = "Attraction2_Desc",
                Category = "🌳",
                ImageUrl = "https://viikvald.ee/storage/cache/be/79/59/raepark-dji-0077.jpg"
            },
            new()
            {
                Id = 3,
                NameKey = "Attraction3_Name",
                DescriptionKey = "Attraction3_Desc",
                Category = "🍽️",
                ImageUrl = "https://www.noaresto.ee/wp-content/uploads/2024/01/NOA-restoran-13-1.jpg"
            },
            new()
            {
                Id = 4,
                NameKey = "Attraction4_Name",
                DescriptionKey = "Attraction4_Desc",
                Category = "🍽️",
                ImageUrl = "https://toidunautleja.ee/wp-content/uploads/2024/10/IMG_5343.jpg"
            },
            new()
            {
                Id = 5,
                NameKey = "Attraction5_Name",
                DescriptionKey = "Attraction5_Desc",
                Category = "🏰",
                ImageUrl = "https://muuseumioo.muuseum.ee/wp-content/uploads/2025/03/valisvaade-laiem-scaled.jpg"
            },
            new()
            {
                Id = 6,
                NameKey = "Attraction6_Name",
                DescriptionKey = "Attraction6_Desc",
                Category = "🏰",
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQbQazDATa2gRk0lNHUbTWSuI5JsQX62oCrug&s"
            }
        };

        await _database!.InsertAllAsync(items);
    }

    // ===== ATTRACTIONS =====

    public async Task<List<Attraction>> GetAttractionsAsync()
    {
        await Init();
        return await _database!.Table<Attraction>().ToListAsync();
    }

    // ===== FAVORITES =====

    public async Task<List<FavoriteAttraction>> GetAllFavoritesAsync()
    {
        await Init();
        return await _database!.Table<FavoriteAttraction>().ToListAsync();
    }

    public async Task<int> AddFavoriteAsync(FavoriteAttraction item)
    {
        await Init();
        return await _database!.InsertAsync(item);
    }

    public async Task<int> RemoveFavoriteAsync(FavoriteAttraction item)
    {
        await Init();
        return await _database!.DeleteAsync(item);
    }

    public async Task<FavoriteAttraction?> GetFavoriteByAttractionIdAsync(int attractionId)
    {
        await Init();
        return await _database!
            .Table<FavoriteAttraction>()
            .Where(i => i.AttractionId == attractionId)
            .FirstOrDefaultAsync();
    }
}