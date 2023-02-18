using System;

namespace SnakeGame.Models.Gameplay.Engine;

/// <summary>
/// The exception that is thrown when a <see cref="Component"/> is not found on a <see cref="GameObject"/>.
/// </summary>
public class ComponentNotFoundException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ComponentNotFoundException"/> class.
    /// </summary>
    public ComponentNotFoundException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ComponentNotFoundException"/> class with the specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public ComponentNotFoundException(string? message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ComponentNotFoundException"/> class with the specified error message and component type.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="componentType">Type of the missing component.</param>
    public ComponentNotFoundException(string? message, Type componentType)
        : base($"{message} {GetComponentTypeMessagePart(componentType)}")
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ComponentNotFoundException"/> class with the specified component type.
    /// </summary>
    /// <param name="componentType">Type of the missing component.</param>
    public ComponentNotFoundException(Type componentType)
        : base(GetComponentTypeMessagePart(componentType))
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ComponentNotFoundException"/> class with the specified error message
    /// and the exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The exception that is the cause of the current exception</param>
    public ComponentNotFoundException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ComponentNotFoundException"/> class with the exception 
    /// that is the cause of this exception, and the component type.
    /// </summary>
    /// <param name="innerException">The exception that is the cause of the current exception.</param>
    /// <param name="componentType">Type of the missing component.</param>
    public ComponentNotFoundException(Exception? innerException, Type componentType)
        : base(GetComponentTypeMessagePart(componentType), innerException)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ComponentNotFoundException"/> class with the specified error message, 
    /// the exception that is the cause of this exception, and the component type.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The exception that is the cause of the current exception.</param>
    /// <param name="componentType">Type of the missing component.</param>
    public ComponentNotFoundException(string? message, Exception? innerException, Type componentType)
        : base($"{message} {GetComponentTypeMessagePart(componentType)}", innerException)
    {
    }

    private static string GetComponentTypeMessagePart(Type componentType) => $"ComponentType: {componentType}";
}
