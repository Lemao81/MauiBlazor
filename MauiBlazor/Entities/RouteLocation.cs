using SQLite;

namespace MauiBlazor.Entities
{
    public class RouteLocation
    {
        public RouteLocation()
        {
            CreationDate = DateTime.Now;
        }

        public RouteLocation(Location location) : this()
        {
            Latitude = location.Latitude;
            Longitude = location.Longitude;
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime CreationDate { get; set; }

        public Location ToLocation() => new() { Latitude = Latitude, Longitude = Longitude };
    }
}