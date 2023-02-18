using System;

namespace SnakeGame.Models.Gameplay.Engine;

/// <summary>
/// Base class for extending functionality of a <see cref="Gameplay.GameObject"/> in runtime by attaching to it.
/// </summary>
public abstract class Component
{
    /// <summary>
    /// Gets or privately sets the <see cref="Gameplay.GameObject"/> this component is attached to.
    /// </summary>
    public GameObject? GameObject { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Component"/> class without attaching to any <see cref="Gameplay.GameObject"/>.
    /// </summary>
    protected Component()
    {
    }

    /// <summary>
    /// Adds functionality to the specified <see cref="Gameplay.GameObject"/>.
    /// </summary>
    /// <param name="gameObject"><see cref="Gameplay.GameObject"/> attached to.</param>
    /// <exception cref="InvalidOperationException">Already attached to another <see cref="Gameplay.GameObject"/>.</exception>
    public void Attach(GameObject gameObject)
    {
        if (GameObject is not null)
        {
            throw new InvalidOperationException("Already attached to a game object. Must detach from current game object before attaching to another.");
        }

        GameObject = gameObject;
    }

    /// <summary>
    /// Removing functionality from the <see cref="Gameplay.GameObject"/> this instance is attached to.
    /// </summary>
    public void Detach()
    {
        GameObject = null;
    }
}