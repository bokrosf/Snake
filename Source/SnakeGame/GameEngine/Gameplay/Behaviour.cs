namespace SnakeGame.GameEngine.Gameplay;

/// <summary>
/// Base class for defining behaviours that can update their state in every frame.
/// It can be used to implement game logic or components.
/// </summary>
public abstract class Behaviour : Component, IUpdatable, IEnableable
{
    public bool Enabled { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Behaviour"/> class that is enabled.
    /// </summary>
    protected Behaviour()
    {
        Enabled = true;
    }

    public virtual void Update()
    {
    }
}
