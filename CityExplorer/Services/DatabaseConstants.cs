using SQLite;
using System.IO;

namespace CityExplorer.Services;

public static class DatabaseConstants
{
    public const string DatabaseFilename = "CityExplorerSQLite.db3";

    public const SQLiteOpenFlags Flags =
        SQLiteOpenFlags.ReadWrite |
        SQLiteOpenFlags.Create |
        SQLiteOpenFlags.SharedCache;

    public static string DatabasePath =>
        Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
}