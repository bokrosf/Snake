using Microsoft.Maui.Controls;
using System;

namespace SnakeGame.ViewModels;

internal interface IBackNavigable
{
    event EventHandler? BackNavigationRequested;

    Command NavigateBackCommand { get; }
}
