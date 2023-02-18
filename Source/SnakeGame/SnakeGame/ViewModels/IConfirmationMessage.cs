namespace SnakeGame.ViewModels;

public interface IConfirmationMessage
{
    public string Title { get; }
    public string Message { get; }
    public string ConfirmationText { get; }
}
