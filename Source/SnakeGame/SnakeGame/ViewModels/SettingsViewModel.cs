using Microsoft.Maui.Controls;
using System;

namespace SnakeGame.ViewModels;

internal class SettingsViewModel : ViewModel, IBackNavigable
{
    public event EventHandler? BackNavigationRequested;

    public Command NavigateBackCommand { get; }

    public SettingsViewModel()
    {
        NavigateBackCommand = new Command(OnBackNavigationRequested);
    }

    private void OnBackNavigationRequested()
    {
        BackNavigationRequested?.Invoke(this, EventArgs.Empty);
    }
}
