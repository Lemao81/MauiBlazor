using MauiBlazor.Entities;

namespace MauiBlazor.Interfaces
{
    internal interface IRouteTrackingPageService
    {
        Task SaveLocationAsync(Location location);
        Task<ICollection<RouteLocation>> GetLocationsAsync();
        Task DeleteLocationsAsync();
    }
}
