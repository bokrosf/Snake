using System;
using System.Collections.Generic;

namespace SnakeGame.Models.Gameplay;

/// <summary>
/// Square tile based snake movement system, where each segment of a snake's body must be inside either horizontal or vertical tile segments.
/// </summary>
public class TiledSnakeMovementSystem : SnakeMovementSystem
{
    /// <summary>
    /// Gets the size of a tile that is the length of the square's side.
    /// </summary>
    public float TileSize { get; }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="TiledSnakeMovementSystem"/> class with the specified square tile size.
    /// </summary>
    /// <param name="tileSize">Size of a square tile.</param>
    public TiledSnakeMovementSystem(float tileSize)
    {
        TileSize = tileSize;
    }

    public override SnakeSegmentCorrection CorrectSegment(Vector start, Vector end)
    {
        Vector axisDirection = ConvertToAxisDirection(end);
        start = ConvertToTileCenter(start);
        end = start + (end.Magnitude * axisDirection);

        return new SnakeSegmentCorrection(start, end);
    }

    public override SnakeHeadTurningCorrection CorrectHeadTurning(Vector headPosition, Vector lookDirection)
    {
        IReadOnlyList<Vector> headSegments = new List<Vector> { ConvertToTileCenter(headPosition) }.AsReadOnly();

        return new SnakeHeadTurningCorrection(headSegments, ConvertToAxisDirection(lookDirection));
    }

    private Vector ConvertToTileCenter(Vector position)
    {
        float horizontalStart = (int)(position.X / TileSize) * TileSize;
        float verticalStart = (int)(position.Y / TileSize) * TileSize;

        Vector lowerLeftTile = new Vector(
            (int)(position.X / TileSize) * TileSize, 
            (int)(position.Y / TileSize) * TileSize);

        Vector centerOfTileOffset = new Vector(TileSize * 0.5f, TileSize * 0.5f);
        
        return lowerLeftTile + centerOfTileOffset; 
    }

    private Vector ConvertToAxisDirection(Vector vector)
    {
        Vector longerAxisProjection = MathF.Abs(vector.X) > MathF.Abs(vector.Y) ? new Vector(vector.X, 0) : new Vector(vector.Y, 0);
        
        return longerAxisProjection.Normalize();
    }
}
