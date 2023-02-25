using SnakeGame.GameEngine;
using SnakeGame.GameEngine.Gameplay;
using System;
using System.Collections.Generic;

namespace SnakeGame.Models.Gameplay;

/// <summary>
/// Represents a snake that can be controlled by the player.
/// </summary>
public class Snake : Behaviour
{
    private Vector headDirection;
    private readonly LinkedList<Vector> segmentPositions;
    private SnakeMovementSystem? movementSystem;

    /// <summary>
    /// Creates a new instance of the <see cref="Snake"/> class which has no length. Call the <see cref="Initialize"/> method to properly initialize.
    /// </summary>
    public Snake()
    {
        segmentPositions = new LinkedList<Vector>();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="head">Head position.</param>
    /// <param name="tail">Tail position.</param>
    public void Initialize(Vector head, Vector tail)
    {
        if (head == Vector.Zero && tail == Vector.Zero)
        {
            throw new ArgumentException("Head and tail can not be the zero vector at the same time. The segment's length must be greater than zero.");
        }
        
        movementSystem = RequiredGameObject.GetRequiredComponent<SnakeMovementSystem>();
        SnakeSegmentCorrection segmentCorrection = movementSystem.CorrectSegment(head, tail);
        headDirection = segmentCorrection.Start.PointsTo(segmentCorrection.End).Normalize();
        segmentPositions.AddFirst(new LinkedListNode<Vector>(segmentCorrection.Start));
        segmentPositions.AddLast(new LinkedListNode<Vector>(segmentCorrection.End));
    }

    public override void Update()
    {
        // Because of DeltaTime a new assembly must be created for the game engine.
        // This assembly also could contain the Component class' Attach and Detach methods.
        // GameEngine planning for an objcect that encapsulates the game logic like a level or scene that call's the update and delta time in the right order.
        // DeltaTime update must be called before the game logic update.


        // Movement value: speed * DeltaTime

        
        // Going straight in the head's direction.
        // Incrementing the head's position.
        // Decrementing the tail's position in the section's start direction.
        // Segment positions: head <- p1 <- p2 <- .. <-- pn <- tail
    }

    /// <summary>
    /// Makes the snake to look in the specified direction.
    /// </summary>
    /// <param name="direction">Direction where the snake's head is facing.</param>
    public void LookInDirection(Vector direction)
    {
        SnakeHeadTurningCorrection correction = movementSystem!.CorrectHeadTurning(segmentPositions.First!.Value, direction);
        
        if (correction.HeadDirection == -1 * headDirection)
        {
            return;
        }
        
        headDirection = correction.HeadDirection;
        segmentPositions.RemoveFirst();

        foreach (var position in correction.HeadSegments)
        {
            segmentPositions.AddFirst(position);
        }
    }
}
