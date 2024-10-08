﻿using Microsoft.Extensions.Logging;
using NTBanking.Data; 

namespace NTBanking
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
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            
            builder.Services.AddSingleton<DatabaseHelper>(s => ActivatorUtilities.CreateInstance<DatabaseHelper>(s, Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "NTBanking.db3")));

            return builder.Build();
        }
    }
}
