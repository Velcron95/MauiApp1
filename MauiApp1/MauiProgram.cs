﻿using MauiApp1.Data;
using MauiApp1.ViewModels;
using Microsoft.Extensions.Logging;

namespace MauiApp1
{
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransient<ItemDetailPage>();
            builder.Services.AddSingleton<DatabaseService>();
            builder.Services.AddSingleton<MainViewModel>();
            
            builder.Services.AddSingleton<AddTaskViewModel>();

            builder.Logging.AddDebug();
            
#endif      

            return builder.Build();
        }
    }
}
