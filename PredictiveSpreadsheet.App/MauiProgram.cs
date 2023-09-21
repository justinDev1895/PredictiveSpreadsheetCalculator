using PredictiveSpreadsheet.Lib.Services;
using PredictiveSpreadsheet.Lib.ViewModels;


namespace PredictiveSpreadsheet.App
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
                })
                .Services
                .AddSingleton<IRowService, InMemoryRowService>()
                .AddTransient<NewMonthModel>()
                .AddSingleton<MonthsModel>()
                .AddTransient<UpdateMonthModel>()
                .AddTransient<Views.NewMonth>()
                .AddSingleton<Views.Months>()
                .AddTransient<Views.UpdateMonth>()
               

                
                
                ;

            return builder.Build();
        }
    }
}