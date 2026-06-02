using System.ComponentModel;
using CityExplorer.Resources.Strings;

namespace CityExplorer.Models;

public class Attraction : INotifyPropertyChanged
{
    public int Id { get; set; }

    public string NameKey { get; set; } = "";
    public string DescriptionKey { get; set; } = "";

    public string ImageUrl { get; set; } = "";
    public string Category { get; set; } = "";

    public string Name =>
        LocalizationResourceManager.Instance[NameKey];

    public string Description =>
        LocalizationResourceManager.Instance[DescriptionKey];

    public event PropertyChangedEventHandler? PropertyChanged;

    public void NotifyLanguageChanged()
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Description)));
    }
}