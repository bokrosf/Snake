using Microsoft.Maui.Controls;

namespace SnakeGame.ViewModels;

internal class MainMenuViewModel : ViewModel
{
    public const string PlayNavigation = "Play";
    public const string SettingsNavigation = "Settings";
    
    public Command PlayCommand { get; }
    public Command SettingsCommand { get; }
    public Command QuitCommand { get; }

    public MainMenuViewModel()
    {
        PlayCommand = new Command(() => OnNavigationRequested(PlayNavigation));
        SettingsCommand = new Command(() => OnNavigationRequested(SettingsNavigation));
        QuitCommand = new Command(Quit);
    }

    private async void Quit()
    {
        await OnConfirmationMessageDisplayedAsync("Exiting", "Some test message", "Ok");
        
        if (await OnDecisionMessageDisplayedAsync("Quit", "Are you sure to quit?", "Yes", "No"))
        {
            Application.Current!.Quit();
        }
    }
}
