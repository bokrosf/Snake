using SharpHook.Native;
using SnakeGame.Persistence;
using System.Threading.Tasks;

namespace SnakeGame.Models.Settings;

/// <summary>
/// Edits the settings of the user.
/// </summary>
internal class SettingsEditor
{
    private readonly IPersistence persistence;

    /// <summary>
    /// Game and movement settings.
    /// </summary>
    public Settings Settings { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SettingsEditor"/> class with the specified persistence and the default settings.
    /// </summary>
    /// <param name="persistence">Stored data access.</param>
    public SettingsEditor(IPersistence persistence)
    {
        this.persistence = persistence;
        Settings = Settings.Default;
    }

    /// <summary>
    /// Loads the previously saved settings.
    /// </summary>
    public async Task LoadAsync()
    {
        if (await persistence.LoadSettingsAsync() is not Persistence.Settings persisted)
        {
            return;
        }

        Settings = new Settings(
            persisted.PlayerName,
            KeyCodeToEnum(persisted.MoveUpKeyCode),
            KeyCodeToEnum(persisted.MoveDownKeyCode),
            KeyCodeToEnum(persisted.MoveLeftKeyCode),
            KeyCodeToEnum(persisted.MoveRightKeyCode));
    }

    /// <summary>
    /// Stores the specified settings.
    /// </summary>
    /// <param name="settings">Settings to store.</param>
    public async Task SaveAsync(Settings settings)
    {
        await persistence.SaveSettingsAsync(new Persistence.Settings(
            settings.PlayerName,
            EnumToKeyCode(settings.MoveUpKeyCode),
            EnumToKeyCode(settings.MoveDownKeyCode),
            EnumToKeyCode(settings.MoveLeftKeyCode),
            EnumToKeyCode(settings.MoveRightKeyCode)));

        Settings = settings;
    }

    private KeyCode KeyCodeToEnum(int keyCode) => (KeyCode)keyCode;

    private int EnumToKeyCode(KeyCode keyCode) => (int)keyCode;
}
