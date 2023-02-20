using SnakeGame.GameEngine;
using SnakeGame.GameEngine.Gameplay;

namespace SnakeGame.Models.Gameplay;

/// <summary>
/// Provides a way to correct or refine the movement of the snake if there are any special requirements.
/// Used to convert world positions to fit the implementor's position or movemenet system.
/// </summary>
public abstract class SnakeMovementSystem : Component
{
    /// <summary>
    /// Corrects the specified segment's direction and position.
    /// </summary>
    /// <param name="start">Start of the segment.</param>
    /// <param name="end">End of the segment.</param>
    public abstract SnakeSegmentCorrection CorrectSegment(Vector start, Vector end);

    /// <summary>
    /// Corrects when the snake's head turned to look into the specified direction. Returns the sections of the head movement.
    /// </summary>
    /// <param name="headPosition">Position of the snake's head.</param>
    /// <param name="lookDirection">The direction the head should look in.</param>
    public abstract SnakeHeadTurningCorrection CorrectHeadTurning(Vector headPosition, Vector lookDirection);
}
