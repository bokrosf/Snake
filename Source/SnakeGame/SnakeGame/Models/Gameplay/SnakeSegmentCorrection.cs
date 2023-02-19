namespace SnakeGame.Models.Gameplay;

/// <summary>
/// Represents the result of a snake segment correction.
/// </summary>
/// <param name="Start">Start of the segement.</param>
/// <param name="End">End of the segment.</param>
public record SnakeSegmentCorrection(Vector Start, Vector End);
