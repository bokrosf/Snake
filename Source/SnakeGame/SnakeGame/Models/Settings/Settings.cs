using SharpHook.Native;

namespace SnakeGame.Models.Settings;

/// <summary>
/// Game and movement settings.
/// </summary>
/// <param name="PlayerName">Name of the player.</param>
/// <param name="MoveUpKeyCode">Keycode of the key used for moving up.</param>
/// <param name="MoveDownKeyCode">Keycode of the key used for moving down.</param>
/// <param name="MoveLeftKeyCode">Keycode of the key used for moving left.</param>
/// <param name="MoveRightKeyCode">Keycode of the key used for moving right.</param>
public record Settings(
    string PlayerName,
    KeyCode MoveUpKeyCode,
    KeyCode MoveDownKeyCode,
    KeyCode MoveLeftKeyCode,
    KeyCode MoveRightKeyCode)
{
    /// <summary>
    /// Default settings.
    /// </summary>
    public static Settings Default { get; }

    static Settings()
    {
        Default = new Settings(
            "Player",
            KeyCode.VcUp,
            KeyCode.VcDown,
            KeyCode.VcLeft,
            KeyCode.VcRight);
    }
}