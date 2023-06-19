using MauiBlazor.Entities;

namespace MauiBlazor.Models
{
    internal class RouteTrackingViewModel
    {
        public RouteTrackingViewModel(ICollection<RouteLocation> locations)
        {
            if (!locations.Any()) return;

            var ordered = locations.OrderBy(l => l.CreationDate).ToList();
            var startTime = ordered.First().CreationDate;
            for (var i = 0; i < ordered.Count; i++)
            {
                var routeLocation = ordered[i];
                var absoluteTime = routeLocation.CreationDate - startTime;
                var relativeTime = i == 0 ? TimeSpan.Zero : routeLocation.CreationDate - ordered[i - 1].CreationDate;
                RouteLocations.Add(new RouteLocationViewModel(routeLocation, absoluteTime, relativeTime));
            }
        }

        public List<RouteLocationViewModel> RouteLocations { get; set; } = new List<RouteLocationViewModel>();
    }
}
