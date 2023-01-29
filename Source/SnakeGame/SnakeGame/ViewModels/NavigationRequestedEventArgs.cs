using System;

namespace SnakeGame.ViewModels;

internal class NavigationRequestedEventArgs : EventArgs
{
    public string LocationName { get; }

	public NavigationRequestedEventArgs(string locationName)
	{
        LocationName = locationName;
	}
}
