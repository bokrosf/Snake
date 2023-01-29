using System.Threading.Tasks;

namespace SnakeGame.ViewModels;

internal class ConfirmationMessageDispalyedEventArgs : IConfirmationMessage
{
    public string Title { get; }
    public string Message { get; }
    public string ConfirmationText { get; }
    public Task Awaiter { get; }
    
    public ConfirmationMessageDispalyedEventArgs(string title, string message, string confirmationText)
    {
        Title = title;
        Message = message;
        ConfirmationText = confirmationText;
        Awaiter = new Task(() => { });
    }

    public void Confirm() => Awaiter.Start();

    public async Task ConfirmAsync()
    {
        Confirm();
        await Awaiter;
    }
}
