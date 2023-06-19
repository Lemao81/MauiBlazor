namespace MauiBlazor.Helpers
{
    internal static class NavigationHelper
    {
        public static async Task PushAsync<T>() where T : Page => await Application.Current.MainPage.Navigation.PushAsync(Activator.CreateInstance(typeof(T)) as Page);
    }
}
