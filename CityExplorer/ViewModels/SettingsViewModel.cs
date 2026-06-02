using CityExplorer.Resources.Strings;
using System.Collections.ObjectModel;
using System.Globalization;

namespace CityExplorer.ViewModels;

public class SettingsViewModel : BaseViewModel
{
    private string _selectedLanguage = "";

    public ObservableCollection<string> Languages { get; set; } = new()
    {
        "English",
        "Eesti"
    };

    public string SelectedLanguage
    {
        get => _selectedLanguage;
        set
        {
            if (_selectedLanguage != value)
            {
                _selectedLanguage = value;
                OnPropertyChanged();
                ChangeLanguage(value);
            }
        }
    }

    public SettingsViewModel()
    {
        Title = "Settings";

        SelectedLanguage = "English";
    }

    private void ChangeLanguage(string language)
    {
        string cultureCode = "en";
        if (language == "Eesti") cultureCode = "et";

        var culture = new CultureInfo(cultureCode);

        CultureInfo.CurrentUICulture = culture;
        CultureInfo.DefaultThreadCurrentUICulture = culture;
        CultureInfo.CurrentCulture = culture;
        CultureInfo.DefaultThreadCurrentCulture = culture;

        LocalizationResourceManager.Instance.SetCulture(culture);

    }
}