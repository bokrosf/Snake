using System.Collections.Generic;

namespace SnakeGame.Models.Gameplay;

/// <summary>
/// Represents the result of a snake head turning correction.
/// </summary>
/// <param name="HeadSegments">
/// Snake body segments that represents the head turning. The first element is the attachment position where all the other segments joined to.
/// The last element is the new head position. Always contains at least one element that is the head position.
/// </param>
/// <param name="HeadDirection">Direction where the snake's head looking in.</param>
public record SnakeHeadTurningCorrection(IReadOnlyList<Vector> HeadSegments, Vector HeadDirection);
