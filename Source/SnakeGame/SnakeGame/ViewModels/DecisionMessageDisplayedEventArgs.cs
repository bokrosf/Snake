using System.Threading.Tasks;

namespace SnakeGame.ViewModels;

internal class DecisionMessageDisplayedEventArgs : IConfirmationMessage
{
    private bool decision;
    
    public string Title { get; }
    public string Message { get; }
    public string ConfirmationText { get; }
    public string DeclineText { get; }
    public Task<bool> DecisionAwaiter { get; }

    public DecisionMessageDisplayedEventArgs(string title, string message, string confirmationText, string declineText)
	{
        Title = title;
        Message = message;    
        ConfirmationText = confirmationText;
        DeclineText = declineText;
        DecisionAwaiter = new Task<bool>(() => decision);
	}

    public void Decide(bool confirmed)
    {
        decision = confirmed;
        DecisionAwaiter.Start();
    }

    public async Task DecideAsync(bool confirmed)
    {
        Decide(confirmed);
        await DecisionAwaiter;
    }
}
