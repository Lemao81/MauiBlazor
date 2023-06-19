using Microsoft.Extensions.Logging;
using MauiBlazor.Data;
using MauiBlazor.Interfaces;
using MauiBlazor.Services;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using CommunityToolkit.Maui;

namespace MauiBlazor;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            })
            .UseMauiCommunityToolkit()
            .UseMauiMaps();

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton(sp =>
        {
            var db = new AppDatabase();
            Task.Run(() => db.InitAsync()).Wait();

            return db;
        });

        builder.Services.AddScoped<IRouteTrackingPageService, RouteTrackingPageService>();
        builder.Services.AddScoped<IRouteLocationRepository, RouteLocationRepository>();

        builder.Services.AddBlazorise(options =>
        {
            options.Immediate = true;
        });
        builder.Services.AddBootstrapProviders();
        builder.Services.AddFontAwesomeIcons();

        return builder.Build();
    }
}
