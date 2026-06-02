using CityExplorer.ViewModels;

namespace CityExplorer.Views;

public partial class FavoritesPage : ContentPage
{
    private FavoritesViewModel _viewModel;

    public FavoritesPage(FavoritesViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        _viewModel = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.LoadFavorites();
    }
}
