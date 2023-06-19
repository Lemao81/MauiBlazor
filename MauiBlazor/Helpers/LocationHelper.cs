namespace MauiBlazor.Helpers
{
    internal static class LocationHelper
    {
        public static async Task<Location?> GetLocationAsync()
        {
            try
            {
                var locationRequest = new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromSeconds(10));
                var location = await Geolocation.Default.GetLocationAsync(locationRequest);
                if (location is null)
                {
                    NotificationHelper.ShowMessage("Location couldn't be retrieved");
                }

                return location;
            }
            catch (FeatureNotSupportedException)
            {
                NotificationHelper.ShowMessage("This feature is not supported by your device");

                return null;
            }
            catch (FeatureNotEnabledException)
            {
                NotificationHelper.ShowMessage("This feature requires WiFi + Location turned on");

                return null;
            }
        }
    }
}
