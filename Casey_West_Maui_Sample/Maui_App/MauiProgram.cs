using CommunityToolkit.Maui;
using Maui_App.Repositories.Inspections;
using Maui_App.Repositories.Locations;
using Maui_App.Services.Common;
using Maui_App.Services.Inspections;
using Maui_App.Services.Locations;
using Maui_App.ViewModels.Inspection;
using Maui_App.Views;
using Microsoft.Extensions.Logging;

namespace Maui_App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .RegisterRepositories()
                .RegisterServices()
                .RegisterViewModels()
                .RegisterViews();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        private static MauiAppBuilder RegisterViews(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<InspectionListPage>();
            builder.Services.AddTransient<InspectionEditPage>();

            return builder;
        }

        private static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<InspectionListViewModel>();
            builder.Services.AddTransient<InspectionEditViewModel>();

            return builder;
        }

        private static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<IInspectionService, InspectionService>();
            builder.Services.AddTransient<ILocationService, LocationService>();
            builder.Services.AddSingleton<INavigationService, NavigationService>();
            builder.Services.AddSingleton<IDialogService, DialogService>();

            return builder;
        }

        private static MauiAppBuilder RegisterRepositories(this MauiAppBuilder builder)
        {
            
            var baseUrl = DeviceInfo.Platform == DevicePlatform.Android
                ? "http://10.0.2.2:5261"
                : "https://localhost:7262";
            

            builder.Services.AddHttpClient("MauiAppApiClient",
                client =>
                {
                    client.BaseAddress = new Uri(baseUrl);
                    client.DefaultRequestHeaders.Add("Accept", "application/json");

                });

            builder.Services.AddTransient<IInspectionRepository, InspectionRepository>();
            builder.Services.AddTransient<ILocationRepository, LocationRepository>();

            return builder;
        }
    }
}
