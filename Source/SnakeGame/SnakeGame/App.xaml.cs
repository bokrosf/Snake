using Microsoft.Maui.Controls;
using SnakeGame.Views.Pages;

namespace SnakeGame;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		MainPage = new StartupPage();
	}
}
