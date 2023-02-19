namespace SnakeGame.Models.Gameplay;

/// <summary>
/// Provides a way to correct or refine the movement of the snake if there are any special requirements.
/// Used to convert world positions to fit the implementor's position or movemenet system.
/// </summary>
public interface ISnakeMovementSystem
{
    /// <summary>
    /// Corrects the specified segment's direction, position and length.
    /// </summary>
    /// <param name="segment">Line segment of a snake's body between two breakpoints.</param>
    Vector CorrectSegment(Vector segment);

    /// <summary>
    /// Corrects when the snake's head turned to look into the specified direction. Returns the sections of the head movement.
    /// </summary>
    /// <param name="headPosition">Position of the snake's head.</param>
    /// <param name="lookDirection">The direction the head should look in.</param>
    SnakeHeadTurningCorrection CorrectHeadTurning(Vector headPosition, Vector lookDirection);
}
