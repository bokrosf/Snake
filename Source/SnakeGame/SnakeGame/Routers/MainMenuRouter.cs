using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;
using SnakeGame.ViewModels;
using SnakeGame.Views.Pages;
using System;
using System.Threading.Tasks;

namespace SnakeGame.Routers;

internal class MainMenuRouter : Router
{
	public MainMenuRouter(IServiceProvider services, MainMenuPage page, MainMenuViewModel viewModel)
        : base(services)
	{
        WireViewModel(page, viewModel);
        SubscribeToEvents(viewModel);
        Application.Current!.MainPage = new NavigationPage(page);
    }

    protected override async void ViewModel_NavigationRequested(object? sender, NavigationRequestedEventArgs e)
    {
        await (e.LocationName switch
        {
            MainMenuViewModel.PlayNavigation => NavigateToViewModelAsync<GameViewModel, GamePage>(),
            MainMenuViewModel.SettingsNavigation => NavigateToViewModelAsync<SettingsViewModel, SettingsPage>(),
            _ => Task.CompletedTask
        });
    }
}
