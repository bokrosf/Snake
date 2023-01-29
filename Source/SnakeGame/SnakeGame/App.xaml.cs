using Microsoft.Maui.Controls;
using SnakeGame.Routers;
using SnakeGame.Views.Pages;
using System;

namespace SnakeGame;

public partial class App : Application
{
	private readonly IServiceProvider serviceProvider;
	
	public App(IServiceProvider serviceProvider)
	{
		InitializeComponent();
		MainPage = new StartupPage();
		this.serviceProvider = serviceProvider;
    }

    protected override void OnStart()
    {
        base.OnStart();
		MainMenuRouter router = new MainMenuRouter(serviceProvider, new MainMenuPage(), new ViewModels.MainMenuViewModel());
    }
}
