using MauiBlazor.Entities;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using Map = Microsoft.Maui.Controls.Maps.Map;

namespace MauiBlazor.Views;

public partial class MapPage : ContentPage
{
    public MapPage(Location location)
    {
        Initialize();

        var map = CreateMap(location);
        AddPins(map, location);
        map.MapClicked += (_, args) =>
        {
            if (map.MapElements.Count == 0)
            {
                map.MapElements.Add(new Polygon
                {
                    StrokeColor = Color.FromArgb("#FF9900"),
                    StrokeWidth = 8,
                    FillColor = Color.FromArgb("#88FF9900")
                });
            }

            var polygon = map.MapElements.First() as Polygon;
            polygon?.Geopath.Add(args.Location);
        };

        Content = map;
    }

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
        AddPins(map, routeLocations.Select(l => new Location(l.Latitude, l.Longitude)).ToArray());
    }

    public MapPage(List<Location> locations)
    {
        Initialize();

        var map = CreateMap(locations[0]);
        AddPins(map, locations.ToArray());
    }

    private void Initialize()
    {
        InitializeComponent();

        NavigationPage.SetHasNavigationBar(this, false);
    }

    private Map CreateMap(Location location)
    {
        var map = new Map(MapSpan.FromCenterAndRadius(location, Distance.FromKilometers(2)));
        Content = map;

        return map;
    }

    private static void AddPins(Map map, params Location[] locations)
    {
        for (var i = 0; i < locations.Length; i++)
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
