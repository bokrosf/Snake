using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace SnakeGame.ViewModels;

internal class ViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    public event EventHandler<NavigationRequestedEventArgs>? NavigationRequested;
    public event EventHandler<TextMessageDisplayedEventArgs>? TextMessageDisplayed;
    public event EventHandler<ConfirmationMessageDispalyedEventArgs>? ConfirmationMessageDisplayed;
    public event EventHandler<DecisionMessageDisplayedEventArgs>? DecisionMessageDisplayed;

    public bool Modal { get; init; }

    protected void SetProperty<T>(ref T backingField, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(backingField, value))
        {
            return;
        }

        backingField = value;
        OnPropertyChanged(propertyName);
    }

    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected void OnNavigationRequested(string locationName)
    {
        NavigationRequested?.Invoke(this, new NavigationRequestedEventArgs(locationName));
    }

    protected void OnTextMessageDisplayed(string message, TextMessageDuration duration = TextMessageDuration.Short)
    {
        TextMessageDisplayed?.Invoke(this, new TextMessageDisplayedEventArgs(message, duration));
    }

    protected Task OnConfirmationMessageDisplayedAsync(string title, string message, string confirmationText)
    {
        ConfirmationMessageDispalyedEventArgs eventArgs = new ConfirmationMessageDispalyedEventArgs(title, message, confirmationText);
        ConfirmationMessageDisplayed?.Invoke(this, eventArgs);

        return eventArgs.Awaiter;
    }

    protected Task<bool> OnDecisionMessageDisplayedAsync(string title, string message, string confirmationText, string declineText)
    {
        DecisionMessageDisplayedEventArgs eventArgs = new DecisionMessageDisplayedEventArgs(title, message, confirmationText, declineText);
        DecisionMessageDisplayed?.Invoke(this, eventArgs);

        return eventArgs.DecisionAwaiter;
    }
}
