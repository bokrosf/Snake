using Microsoft.Maui.Controls;
using System;

namespace SnakeGame.ViewModels;

public interface IBackNavigable
{
    event EventHandler? BackNavigationRequested;

    Command NavigateBackCommand { get; }
}
