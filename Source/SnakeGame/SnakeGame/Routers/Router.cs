using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;
using SnakeGame.ViewModels;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SnakeGame.Routers;

internal class Router
{
    private readonly IServiceProvider serviceProvider;
    
    protected Page MainPage => Application.Current!.MainPage!;
    protected NavigationPage MainNavigationPage => (NavigationPage)Application.Current!.MainPage!;

    public Router(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    protected void WireViewModel(Page page, ViewModel viewModel)
    {
        page.BindingContext = viewModel;
    }

    protected async Task NavigateToViewModelAsync<TViewModel, TPage>(bool modal = false) 
        where TViewModel : ViewModel
        where TPage : Page
    {
        //string pageTypeName = typeof(T).Name.Replace(nameof(ViewModel), string.Empty);
        ////var pageHandle = Activator.CreateInstance(typeof(T).Assembly.FullName!, pageTypeName);
        //var name = typeof(T).Assembly;
        //Type pageType = Type.GetType($"{typeof(T).Assembly.FullName}.Views.Pages.{pageTypeName}")!;
        //Page page = (Page)serviceProvider.GetService(pageType)!;
        //T viewModel = serviceProvider.GetService<T>()!;

        //Page page = (Page)pageHandle!.Unwrap()!;
        //T viewModel = Activator.CreateInstance<T>();
        Page page = serviceProvider.GetService<TPage>()!;
        ViewModel viewModel = serviceProvider.GetService<TViewModel>()!;
        WireViewModel(page, viewModel);
        SubscribeToEvents(viewModel);
        
        if (modal)
        {
            await MainPage.Navigation.PushModalAsync(page);
        }
        else
        {
            await MainPage.Navigation.PushAsync(page);
        }
    }

    protected void SubscribeToEvents(ViewModel viewModel)
    {
        viewModel.NavigationRequested += ViewModel_NavigationRequested;
        viewModel.TextMessageDisplayed += ViewModel_TextMessageDisplayed;
        viewModel.ConfirmationMessageDisplayed += ViewModel_ConfirmationMessageDisplayed;
        viewModel.DecisionMessageDisplayed += ViewModel_DecisionMessageDisplayed;

        if (viewModel is IBackNavigable backNavigable)
        {
            backNavigable.BackNavigationRequested += ViewModel_BackNavigationRequested;
        }
    }

    protected void UnsubscribeFromEvents(ViewModel viewModel)
    {
        viewModel.NavigationRequested -= ViewModel_NavigationRequested;
        viewModel.TextMessageDisplayed -= ViewModel_TextMessageDisplayed;
        viewModel.ConfirmationMessageDisplayed -= ViewModel_ConfirmationMessageDisplayed;
        viewModel.DecisionMessageDisplayed -= ViewModel_DecisionMessageDisplayed;

        if (viewModel is IBackNavigable backNavigable)
        {
            backNavigable.BackNavigationRequested -= ViewModel_BackNavigationRequested;
        }
    }

    protected virtual void ViewModel_NavigationRequested(object? sender, NavigationRequestedEventArgs e)
    {
    }

    protected virtual async void ViewModel_BackNavigationRequested(object? sender, EventArgs e)
    {
        if (sender is not ViewModel viewModel)
        {
            return;
        }
        
        if (!MainPage.Navigation.NavigationStack.Any() && !MainPage.Navigation.ModalStack.Any())
        {
            return;
        }

        if (viewModel.Modal)
        {
            await MainPage.Navigation.PopModalAsync();
        }
        else
        {
            await MainPage.Navigation.PopAsync();
        }

        UnsubscribeFromEvents(viewModel);
    }

    private async void ViewModel_TextMessageDisplayed(object? sender, TextMessageDisplayedEventArgs e)
    {
        if (MainPage is not Page page)
        {
            return;            
        }

        ToastDuration duration = e.Duration switch
        {
            TextMessageDuration.Short => ToastDuration.Short,
            TextMessageDuration.Long => ToastDuration.Long,
            _ => ToastDuration.Short
        };

        try
        {
            await Toast.Make(e.Message, duration).Show();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"{nameof(Router)} - Displaying text message failed. {ex}");
        }
    }

    private async void ViewModel_ConfirmationMessageDisplayed(object? sender, ConfirmationMessageDispalyedEventArgs e)
    {
        if (MainPage is not Page page)
        {
            return;
        }

        try
        {
            await page.DisplayAlert(e.Title, e.Message, e.ConfirmationText);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"{nameof(Router)} - Displaying confirmation message failed. {ex}");
        }
        finally
        {
            e.Confirm();
        }
    }

    private async void ViewModel_DecisionMessageDisplayed(object? sender, DecisionMessageDisplayedEventArgs e)
    {
        if (MainPage is not Page page)
        {
            return;
        }

        try
        {
            bool confirmed = await page.DisplayAlert(e.Title, e.Message, e.ConfirmationText, e.DeclineText);
            await e.DecideAsync(confirmed);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"{nameof(Router)} - Displaying decision message failed. {ex}");
            throw;
        }        
    }
}
