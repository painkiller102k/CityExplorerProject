using CityExplorer.Views;

namespace CityExplorer.Views;

public partial class MainTabbedPage : TabbedPage
{
    public MainTabbedPage(
        ExplorePage explore,
        FavoritesPage favorites,
        SettingsPage settings)
    {
        InitializeComponent();

        Children.Add(explore);
        Children.Add(favorites);
        Children.Add(settings);
    }
}