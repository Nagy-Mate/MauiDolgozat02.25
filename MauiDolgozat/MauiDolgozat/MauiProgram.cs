using CommunityToolkit.Maui;
using MauiDolgozat.Services;
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
            builder.Services.AddTransient<AddPage>();
            builder.Services.AddTransient<DeletePage>();
            builder.Services.AddTransient<UpdatePage>();
            builder.Services.AddTransient<ReportPage>();

            //View Models
            builder.Services.AddTransient<MainPageViewModel>();
            builder.Services.AddTransient<AddViewModel>();
            builder.Services.AddTransient<DeleteViewModel>();
            builder.Services.AddTransient<UpdateViewModel>();
            builder.Services.AddTransient<ReportViewModel>();

            //Services
            builder.Services.AddSingleton<FileService>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
