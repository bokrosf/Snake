using CommunityToolkit.Maui;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.Storage;
using SnakeGame.Persistence;

namespace SnakeGame;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		MauiAppBuilder builder = MauiApp
			.CreateBuilder()
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
			.RegisterServices();

        return builder.Build();
	}

	private static MauiAppBuilder RegisterServices(this MauiAppBuilder appBuilder)
	{
		appBuilder
			.Services
			.RegisterPersistences()
			.RegisterModels()
			.RegisterViewModels()
			.RegisterViews()
			.RegisterRouters();

		return appBuilder;
	}

	private static IServiceCollection RegisterPersistences(this IServiceCollection services)
	{
		return services
			.AddSingleton<IPreferences>(Preferences.Default)
			.AddTransient<IPersistence, Persistence.Persistence>();
	}

    private static IServiceCollection RegisterModels(this IServiceCollection services)
    {
        return services;
    }

    private static IServiceCollection RegisterViewModels(this IServiceCollection services)
    {
        return services;
    }

    private static IServiceCollection RegisterViews(this IServiceCollection services)
    {
        return services;
    }

    private static IServiceCollection RegisterRouters(this IServiceCollection services)
    {
        return services;
    }
}
