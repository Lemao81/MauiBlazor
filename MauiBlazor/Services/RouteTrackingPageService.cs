using MauiBlazor.Entities;
using MauiBlazor.Interfaces;

namespace MauiBlazor.Services
{
    internal class RouteTrackingPageService : IRouteTrackingPageService
    {
        private readonly IRouteLocationRepository _routeLocationRepository;

        public RouteTrackingPageService(IRouteLocationRepository routeLocationRepository)
        {
            _routeLocationRepository = routeLocationRepository;
        }

        public async Task SaveLocationAsync(Location location) => await _routeLocationRepository.AddAsync(new RouteLocation(location));

        public async Task<ICollection<RouteLocation>> GetLocationsAsync() => await _routeLocationRepository.GetAllAsync();

        public async Task DeleteLocationsAsync() => await _routeLocationRepository.DeleteAllAsync();
    }
}
