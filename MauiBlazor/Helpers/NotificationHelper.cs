using CommunityToolkit.Maui.Alerts;

namespace MauiBlazor.Helpers
{
    internal static class NotificationHelper
    {
        public static void ShowMessage(string message, string title = "") => Application.Current?.MainPage?.DisplayAlert(title, message, "OK");

        public static void ShowErrorMessage(Exception exception) =>
            Application.Current?.MainPage?.DisplayAlert("Error", $"Something went wrong: {exception.Message}", "OK");

        public static async Task ShowSnackMessageAsync(string message, long durationMs = 2000)
        {
            var snackBar = Snackbar.Make(message, actionButtonText: "", duration: TimeSpan.FromMilliseconds(durationMs));
            await snackBar.Show();
        }
    }
}
