using MauiBlazor.Entities;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using Map = Microsoft.Maui.Controls.Maps.Map;

namespace MauiBlazor.Views;

public partial class MapPage : ContentPage
{
    public MapPage(RouteLocation routeLocation)
    {
        Initialize();

        var location = new Location(routeLocation.Latitude, routeLocation.Longitude);
        var map = CreateMap(location);
        var pin = new Pin
        {
            Location = location,
            Type = PinType.Place,
            Label = "1"
        };
        map.Pins.Add(pin);

        Content = map;
    }

    public MapPage(List<RouteLocation> routeLocations)
    {
        Initialize();

        var location = new Location(routeLocations[0].Latitude, routeLocations[0].Longitude);
        var map = CreateMap(location);
        AddPins(map, routeLocations.Select(l => new Location(l.Latitude, l.Longitude)).ToList());
    }

    public MapPage(List<Location> locations)
    {
        Initialize();

        var map = CreateMap(locations[0]);
        AddPins(map, locations);
    }

    private void Initialize()
    {
        InitializeComponent();

        NavigationPage.SetHasNavigationBar(this, false);
    }

    private Map CreateMap(Location location)
    {
        var map = new Map(new MapSpan(location, 0.1, 0.1));
        Content = map;

        return map;
    }

    private void AddPins(Map map, List<Location> locations)
    {
        for (var i = 0; i < locations.Count; i++)
        {
            map.Pins.Add(new Pin
            {
                Location = locations[i],
                Type = PinType.Place,
                Label = (i + 1).ToString()
            });
        }
    }
}