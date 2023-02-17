using System;

namespace SnakeGame.Models;

/// <summary>
/// Represents a 2 dimensional float vector.
/// </summary>
internal struct Vector : IEquatable<Vector>
{
    /// <summary>
    /// Upward unit vector (0, 1).
    /// </summary>
    public static Vector Up { get; }

    /// <summary>
    /// Downward unit vector (0, -1).
    /// </summary>
    public static Vector Down { get; }

    /// <summary>
    /// Leftward unit vector (-1, 0).
    /// </summary>
    public static Vector Left { get; }

    /// <summary>
    /// Rightward unit vector (1, 0).
    /// </summary>
    public static Vector Right { get; }

    /// <summary>
    /// Gets the horizontal component.
    /// </summary>
    public float X { get; }
    
    /// <summary>
    /// Gets the vertical component.
    /// </summary>
    public float Y { get; }

    static Vector()
    {
        Up = new Vector(0, 1);
        Down = new Vector(0, -1);
        Left = new Vector(-1, 0);
        Right = new Vector(1, 0);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Vector"/> class with the coordinates of origo (0, 0).
    /// </summary>
    public Vector()
        : this(0, 0)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Vector"/> class with the specified coordinates.
    /// </summary>
    /// <param name="x">Horizontal component.</param>
    /// <param name="y">Vertical component.</param>
    public Vector(float x, float y)
    {
        X = x;
        Y = y;
    }

    /// <summary>
    /// Indicates whether this instance and the specified vector are equal.
    /// </summary>
    /// <param name="other">The vector to compare with the current instance.</param>
    public bool Equals(Vector other)
    {
        return X == other.X && Y == other.Y;
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        if (obj is null || GetType() != obj.GetType())
        {
            return false;
        }

        return Equals((Vector)obj);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            return (int)(X * X + Y);
        }
    }

    /// <summary>
    /// Compares two vectors to determine equality.
    /// </summary>
    /// <param name="left">Left operand.</param>
    /// <param name="right">Right operand.</param>
    public static bool operator ==(Vector left, Vector right) => left.Equals(right);

    /// <summary>
    /// Compares two values to determine inequality.
    /// </summary>
    /// <param name="left">Left operand.</param>
    /// <param name="right">Right operand.</param>
    public static bool operator !=(Vector left, Vector right) => !left.Equals(right);

    /// <summary>
    /// Adds two vectors.
    /// </summary>
    /// <param name="left">Left operand.</param>
    /// <param name="right">Right operand.</param>
    public static Vector operator +(Vector left, Vector right)
    {
        return new Vector(left.X + right.X, left.Y + right.Y);
    }

    /// <summary>
    /// Scales the specified vector. 
    /// </summary>
    /// <param name="scalar">Scaling value.</param>
    /// <param name="vector">Vector that is scaled.</param>
    public static Vector operator *(float scalar, Vector vector)
    {
        return new Vector(scalar * vector.X, scalar * vector.Y);
    }

    /// <summary>
    /// Scales the specified vector. 
    /// </summary>
    /// <param name="vector">Vector that is scaled.</param>
    /// <param name="scalar">Scaling value.</param>
    public static Vector operator *(Vector vector, float scalar) => scalar * vector;
}