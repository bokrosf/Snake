namespace SnakeGame.Models.Gameplay.Engine;

/// <summary>
/// Defines members to update state in the current frame before rendering.
/// </summary>
public interface IUpdatable
{
    /// <summary>
    /// Updates state in the current frame before rendering.
    /// </summary>
    void Update();
}