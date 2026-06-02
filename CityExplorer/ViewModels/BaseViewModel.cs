using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CityExplorer.ViewModels;

public class BaseViewModel : INotifyPropertyChanged
{
    bool isBusy = false;
    public bool IsBusy
    {
        get => isBusy;
        set
        {
            if (isBusy == value)
                return;
            isBusy = value;
            OnPropertyChanged();
        }
    }

    string title = string.Empty;
    public string Title
    {
        get => title;
        set
        {
            if (title == value)
                return;
            title = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public void OnPropertyChanged([CallerMemberName] string? name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
