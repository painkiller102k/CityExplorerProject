using CityExplorer.Views;

namespace CityExplorer;

public partial class App : Application
{
    public App(MainTabbedPage mainPage)
    {
        InitializeComponent();
        MainPage = mainPage;
    }
}