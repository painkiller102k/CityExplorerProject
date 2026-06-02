using System.Collections.ObjectModel;
using System.Windows.Input;
using CityExplorer.Models;
using CityExplorer.Services;
using CityExplorer.Resources.Strings;

namespace CityExplorer.ViewModels;

public class ExploreViewModel : BaseViewModel
{
    private readonly DatabaseService _databaseService; // db

    public ObservableCollection<Attraction> AllAttractions { get; set; } = new(); // kõik 
    public ObservableCollection<Attraction> FilteredAttractions { get; set; } = new(); // filter

    private string _selectedCategory = "All";

    public ICommand FilterCommand { get; } // filter
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

        LoadData();
        Filter();

        LocalizationResourceManager.Instance.PropertyChanged += (_, __) =>
        {
            Filter();
        };
    }

    private void LoadData()
    {
        AllAttractions.Add(new Attraction
        {
            Id = 1,
            NameKey = "Attraction1_Name",
            DescriptionKey = "Attraction1_Desc",
            Category = "🌳",
            ImageUrl = "https://media.voog.com/0000/0041/5045/photos/image001_block.jpg"
        });

        AllAttractions.Add(new Attraction
        {
            Id = 2,
            NameKey = "Attraction2_Name",
            DescriptionKey = "Attraction2_Desc",
            Category = "🌳",
            ImageUrl = "https://viikvald.ee/storage/cache/be/79/59/raepark-dji-0077.jpg"
        });

        AllAttractions.Add(new Attraction
        {
            Id = 3,
            NameKey = "Attraction3_Name",
            DescriptionKey = "Attraction3_Desc",
            Category = "🍽️",
            ImageUrl = "https://www.noaresto.ee/wp-content/uploads/2024/01/NOA-restoran-13-1.jpg"
        });

        AllAttractions.Add(new Attraction
        {
            Id = 4,
            NameKey = "Attraction4_Name",
            DescriptionKey = "Attraction4_Desc",
            Category = "🍽️",
            ImageUrl = "https://toidunautleja.ee/wp-content/uploads/2024/10/IMG_5343.jpg"
        });

        AllAttractions.Add(new Attraction
        {
            Id = 5,
            NameKey = "Attraction5_Name",
            DescriptionKey = "Attraction5_Desc",
            Category = "🏰",
            ImageUrl = "https://muuseumioo.muuseum.ee/wp-content/uploads/2025/03/valisvaade-laiem-scaled.jpg"
        });

        AllAttractions.Add(new Attraction
        {
            Id = 6,
            NameKey = "Attraction6_Name",
            DescriptionKey = "Attraction6_Desc",
            Category = "🏰",
            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQbQazDATa2gRk0lNHUbTWSuI5JsQX62oCrug&s"
        });
    }

    private void Filter()
    {
        var filtered = new ObservableCollection<Attraction>(); // new spisok

        foreach (var item in AllAttractions)
        {
            if (SelectedCategory == "All" || item.Category == SelectedCategory)
                filtered.Add(item);
        }

        FilteredAttractions = filtered;
        OnPropertyChanged(nameof(FilteredAttractions));
    }

    private async Task AddToFavorites(Attraction a)
    {
        if (a == null) return;

        var exists = await _databaseService.GetFavoriteByAttractionIdAsync(a.Id);

        if (exists != null)
        {
            await App.Current!.Windows[0].Page!.DisplayAlertAsync(
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

        await App.Current!.Windows[0].Page!.DisplayAlertAsync(
            LocalizationResourceManager.Instance["Success"],
            LocalizationResourceManager.Instance["AddedToFavorites"],
            LocalizationResourceManager.Instance["OK"]);
    }
}