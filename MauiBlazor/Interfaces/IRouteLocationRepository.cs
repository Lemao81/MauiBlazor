using MauiBlazor.Entities;

namespace MauiBlazor.Interfaces
{
    internal interface IRouteLocationRepository
    {
        Task<RouteLocation> AddAsync(RouteLocation location);
        Task<ICollection<RouteLocation>> GetAllAsync();
        Task DeleteAllAsync();
    }
}
