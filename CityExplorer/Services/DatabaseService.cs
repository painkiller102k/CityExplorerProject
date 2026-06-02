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

        _database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        await _database.CreateTableAsync<FavoriteAttraction>();
    }

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

public static class Constants
{
    public const string DatabaseFilename = "CityExplorerSQLite.db3";

    public const SQLite.SQLiteOpenFlags Flags =
        SQLite.SQLiteOpenFlags.ReadWrite |
        SQLite.SQLiteOpenFlags.Create |
        SQLite.SQLiteOpenFlags.SharedCache;

    public static string DatabasePath =>
        Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
}