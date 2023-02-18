using Microsoft.Maui.Controls;
using SharpHook.Native;
using SnakeGame.Models.Settings;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace SnakeGame.ViewModels;

public class SettingsViewModel : ViewModel
{
	private readonly SettingsEditor editor;
	private bool discardAvailable;
	private string settingInfoText;
	private string playerName;
	private KeyCode moveUpKey;
	private KeyCode moveDownKey;
	private KeyCode moveLeftKey;
	private KeyCode moveRightKey;

	public bool DiscardAvailable
	{
		get => discardAvailable;
		private set => SetProperty(ref discardAvailable, value);
	}

	public string SettingInfoText
	{
		get => settingInfoText;
		set => SetProperty(ref settingInfoText, value);
	}

	public string PlayerName
	{
		get => playerName;
		set => SetProperty(ref playerName, value);
	}

	public KeyCode MoveUpKey 
	{
		get => moveUpKey;
		set => SetProperty(ref moveUpKey, value);
	}

	public KeyCode MoveDownKey 
	{
		get => moveDownKey;
		set => SetProperty(ref moveDownKey, value);
	}

	public KeyCode MoveLeftKey
	{
		get => moveLeftKey;
		set => SetProperty(ref moveLeftKey, value);
	}
	
	public KeyCode MoveRightKey 
	{
		get => moveRightKey;
		set => SetProperty(ref moveRightKey, value);
	}

	public Command SaveCommand { get; }
	public Command DiscardCommand { get; }
	public Command ResetToDefaultsCommand { get; }

	public SettingsViewModel(SettingsEditor editor)
	{
		this.editor = editor;
		settingInfoText = string.Empty;
		SaveCommand = new Command(async () => await SaveAsync());
		DiscardCommand = new Command(Discard);
		ResetToDefaultsCommand = new Command(ResetToDefaults);
		RefreshSettings(editor.Settings);
	}

	private async Task InitializeAsync()
	{
		await editor.LoadAsync();
		RefreshSettings(editor.Settings);
	}

	private async Task SaveAsync()
	{
		await editor.SaveAsync(new Settings(
			PlayerName, 
			MoveUpKey, 
			MoveDownKey, 
			MoveLeftKey, 
			MoveRightKey));
	}

	private void Discard()
	{
		if (!DiscardAvailable)
		{
			return;
		}

		RefreshSettings(editor.Settings);
	}

	private void ResetToDefaults() => RefreshSettings(Settings.Default);

	[MemberNotNull(nameof(playerName), nameof(PlayerName))]
	private void RefreshSettings(Settings settings)
	{
		playerName = PlayerName = settings.PlayerName;
		MoveUpKey = settings.MoveUpKeyCode;
		MoveDownKey = settings.MoveDownKeyCode;
		MoveLeftKey = settings.MoveLeftKeyCode;
		MoveRightKey = settings.MoveRightKeyCode;
	}
}
