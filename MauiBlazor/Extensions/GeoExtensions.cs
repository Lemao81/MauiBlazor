namespace MauiBlazor.Extensions
{
    internal static class GeoExtensions
    {
        public static string ToCoordinatesString(this Location location) => $"{location.Latitude.ToTwoDigitString()} / {location.Longitude.ToTwoDigitString()}";
    }
}
