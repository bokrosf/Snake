namespace SnakeGame.ViewModels;

internal interface IConfirmationMessage
{
    public string Title { get; }
    public string Message { get; }
    public string ConfirmationText { get; }
}
