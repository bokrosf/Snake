namespace SnakeGame.Models.Gameplay;

/// <summary>
/// Base class for defining behaviours that can update their state in every frame.
/// It can be used to implement game logic or components.
/// </summary>
public abstract class Behaviour : Component, IEnableable
{
    public bool Enabled { get; set; }

    /// <summary>
    /// Initializes the behaviour after it has been created. Components can be retrieved here.
    /// </summary>
    public virtual void Initialize()
    {
    }

    /// <summary>
    /// Called in every frame before rendering if the behaviour is enabled.
    /// </summary>
    public virtual void Update()
    {
    }
}
