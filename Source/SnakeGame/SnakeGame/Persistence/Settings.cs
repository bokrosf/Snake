namespace SnakeGame.Persistence;

/// <summary>
/// Game and movement settings.
/// </summary>
/// <param name="PlayerName">Name of the player.</param>
/// <param name="MoveUpKeyCode">Keycode of the key used for moving up.</param>
/// <param name="MoveDownKeyCode">Keycode of the key used for moving down.</param>
/// <param name="MoveLeftKeyCode">Keycode of the key used for moving left.</param>
/// <param name="MoveRightKeyCode">Keycode of the key used for moving right.</param>
internal record Settings(
    string PlayerName,
    int MoveUpKeyCode,
    int MoveDownKeyCode,
    int MoveLeftKeyCode,
    int MoveRightKeyCode);
