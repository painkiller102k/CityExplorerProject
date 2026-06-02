using System.Collections.ObjectModel;
using System.Windows.Input;
using CityExplorer.Models;
using CityExplorer.Services;
using CityExplorer.Resources.Strings;

namespace CityExplorer.ViewModels;

public class ExploreViewModel : BaseViewModel
{
    private readonly DatabaseService _databaseService;

    public ObservableCollection<Attraction> AllAttractions { get; set; } = new();
    public ObservableCollection<Attraction> FilteredAttractions { get; set; } = new();

    private string _selectedCategory = "All";

    public ICommand FilterCommand { get; }
    public ICommand AddToFavoritesCommand { get; }

    public string SelectedCategory
    {
        get => _selectedCategory;
        set
        {
            if (_selectedCategory != value)
            {
                _selectedCategory = value;
                OnPropertyChanged();
                Filter();
            }
        }
    }

    public ExploreViewModel(DatabaseService databaseService)
    {
        _databaseService = databaseService;

        FilterCommand = new Command<string>(c => SelectedCategory = c);
        AddToFavoritesCommand = new Command<Attraction>(async a => await AddToFavorites(a));

        LoadDataFromDb();

        LocalizationResourceManager.Instance.PropertyChanged += (_, __) =>
        {
            RefreshTranslations();
        };
    }

    private async void LoadDataFromDb()
    {
        var items = await _databaseService.GetAttractionsAsync();

        AllAttractions.Clear();

        foreach (var item in items)
            AllAttractions.Add(item);

        Filter();
    }

    private void Filter()
    {
        var filtered = new ObservableCollection<Attraction>();

        foreach (var item in AllAttractions)
        {
            if (SelectedCategory == "All" || item.Category == SelectedCategory)
                filtered.Add(item);
        }

        FilteredAttractions = filtered;
        OnPropertyChanged(nameof(FilteredAttractions));
    }

    private void RefreshTranslations()
    {
        // 🔥 ВАЖНО: заставляем UI пересчитать Name/Description
        OnPropertyChanged(nameof(FilteredAttractions));

        foreach (var item in FilteredAttractions)
        {
            OnPropertyChanged(nameof(item.Name));
            OnPropertyChanged(nameof(item.Description));
        }
    }

    private async Task AddToFavorites(Attraction a)
    {
        if (a == null) return;

        var exists = await _databaseService.GetFavoriteByAttractionIdAsync(a.Id);

        if (exists != null)
        {
            await App.Current!.Windows[0].Page!.DisplayAlert(
                LocalizationResourceManager.Instance["FavoritesTitle"],
                LocalizationResourceManager.Instance["AlreadyAdded"],
                LocalizationResourceManager.Instance["OK"]);
            return;
        }

        await _databaseService.AddFavoriteAsync(new FavoriteAttraction
        {
            AttractionId = a.Id,
            Name = a.Name,
            Description = a.Description,
            Category = a.Category,
            ImageUrl = a.ImageUrl
        });

        await App.Current!.Windows[0].Page!.DisplayAlert(
            LocalizationResourceManager.Instance["FavoritesTitle"],
            LocalizationResourceManager.Instance["AddedToFavorites"],
            LocalizationResourceManager.Instance["OK"]);
    }
}