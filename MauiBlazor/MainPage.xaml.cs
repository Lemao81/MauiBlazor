using Microsoft.AspNetCore.Components.WebView;
using System.Diagnostics;

namespace MauiBlazor;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

        NavigationPage.SetHasNavigationBar(this, false);
    }

    private void OnUrlLoading(object sender, UrlLoadingEventArgs e)
    {
		Debug.WriteLine($"URL HAS BEEN LOADED: {e.Url}");
    }
}
