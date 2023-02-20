namespace SnakeGame.GameEngine.Gameplay;

/// <summary>
/// Defines members that components can implement to enable or disable their behaviours.
/// </summary>
public interface IEnableable
{
    /// <summary>
    /// Gets or sets whether the item is enabled.
    /// </summary>
    bool Enabled { get; set; }
}