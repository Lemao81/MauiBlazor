using MauiBlazor.Entities;
using MauiBlazor.Interfaces;

namespace MauiBlazor.Data
{
    internal class RouteLocationRepository : IRouteLocationRepository
    {
        private readonly AppDatabase _db;

        public RouteLocationRepository(AppDatabase db)
        {
            _db = db;
        }

        public async Task<RouteLocation> AddAsync(RouteLocation location)
        {
            await _db.Connection.InsertAsync(location);

            return location;
        }

        public async Task<ICollection<RouteLocation>> GetAllAsync() => await _db.Connection.Table<RouteLocation>().ToListAsync();

        public async Task DeleteAllAsync() => await _db.Connection.DeleteAllAsync<RouteLocation>();
    }
}
