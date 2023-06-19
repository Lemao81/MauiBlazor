using MauiBlazor.Entities;
using MauiBlazor.Extensions;

namespace MauiBlazor.Models
{
    internal class RouteLocationViewModel
    {
        public RouteLocationViewModel(RouteLocation location, TimeSpan absoluteDuration, TimeSpan relativeDuration)
        {
            Coordinates = $"{location.Latitude.ToTwoDigitString()} / {location.Longitude.ToTwoDigitString()}";
            CreationDate = location.CreationDate.ToString("g");
            AbsoluteDuration = string.Format("{0:hh':'mm':'ss}", absoluteDuration);
            RelativeDuration = string.Format("{0:hh':'mm':'ss}", relativeDuration);
            RouteLocation = location;
        }

        public string Coordinates { get; set; }
        public string CreationDate { get; set; }
        public string AbsoluteDuration { get; set; }
        public string RelativeDuration { get; set; }
        public RouteLocation RouteLocation { get; set; }
    }
}
