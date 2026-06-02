using System.Timers;

namespace CityExplorer.Views;

public partial class ExplorePage : ContentPage
{
    private readonly System.Timers.Timer _timer;
    private int _index = 0;

    public ExplorePage(ViewModels.ExploreViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;

        carousel.PositionChanged += Carousel_PositionChanged;

        _timer = new System.Timers.Timer(5000);
        _timer.Elapsed += AutoSlide;
        _timer.AutoReset = true;
        _timer.Start();

        indicator.BindingContext = carousel;
        indicator.SetBinding(IndicatorView.ItemsSourceProperty, "ItemsSource");
        indicator.SetBinding(IndicatorView.PositionProperty, "Position");
    }

    private void Carousel_PositionChanged(object sender, PositionChangedEventArgs e)
    {
        _index = e.CurrentPosition;
    }

    private void AutoSlide(object? sender, ElapsedEventArgs e)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            if (carousel.ItemsSource is not System.Collections.IList items || items.Count == 0)
                return;

            _index++;
            if (_index >= items.Count)
                _index = 0;

            carousel.Position = _index;
        });
    }
}