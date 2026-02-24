using CommunityToolkit.Maui;
using MauiDolgozat.ViewModels;
using MauiDolgozat.Views;
using Microsoft.Extensions.Logging;

namespace MauiDolgozat
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
                });
            //Views
            builder.Services.AddTransient<MainPage>();
            //View Models
            builder.Services.AddTransient<MainPageViewModel>();

            //Services
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
