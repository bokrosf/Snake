using System;

namespace SnakeGame.ViewModels;

public class NavigationRequestedEventArgs : EventArgs
{
    public string LocationName { get; }

	public NavigationRequestedEventArgs(string locationName)
	{
        LocationName = locationName;
	}
}
