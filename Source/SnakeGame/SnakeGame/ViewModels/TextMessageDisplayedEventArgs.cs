using System;

namespace SnakeGame.ViewModels;

public class TextMessageDisplayedEventArgs : EventArgs
{
    public string Message { get; }

	public TextMessageDuration Duration { get; }

    public TextMessageDisplayedEventArgs(string message, TextMessageDuration duration = TextMessageDuration.Short)
    {
        Message = message;
        Duration = duration;
    }
}
