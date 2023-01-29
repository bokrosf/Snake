using System;

namespace SnakeGame.ViewModels;

internal class TextMessageDisplayedEventArgs : EventArgs
{
    public string Message { get; }

	public TextMessageDuration Duration { get; }

    public TextMessageDisplayedEventArgs(string message, TextMessageDuration duration = TextMessageDuration.Short)
    {
        Message = message;
        Duration = duration;
    }
}
