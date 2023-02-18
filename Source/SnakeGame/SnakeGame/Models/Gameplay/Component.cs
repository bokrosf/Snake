using System;

namespace SnakeGame.Models.Gameplay;

/// <summary>
/// Base class for extending functionality of a <see cref="Gameplay.GameObject"/> in runtime by attaching to it.
/// </summary>
abstract class Component
{
    private GameObject? gameObject;

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
    /// Initializes a new instance of the <see cref="Component"/> class and attaches it to the specified <see cref="Gameplay.GameObject"/>.
    /// </summary>
    /// <param name="gameObject"><see cref="Gameplay.GameObject"/> to attach to.</param>
    protected Component(GameObject gameObject)
    {
        Attach(gameObject);
    }

    /// <summary>
    /// Adds functionality to the specified <see cref="Gameplay.GameObject"/>.
    /// </summary>
    /// <param name="gameObject"><see cref="Gameplay.GameObject"/> attached to.</param>
    /// <exception cref="InvalidOperationException">Already attached to another <see cref="Gameplay.GameObject"/>.</exception>
    public void Attach(GameObject gameObject)
    {
        if (this.gameObject is not null)
        {
            throw new InvalidOperationException("Already attached to a game object. Must detach from current game object before attaching to another.");
        }

        this.gameObject = gameObject;
    }

    /// <summary>
    /// Removing functionality from the <see cref="Gameplay.GameObject"/> this instance is attached to.
    /// </summary>
    public void Detach()
    {
        gameObject = null;
    }
}
