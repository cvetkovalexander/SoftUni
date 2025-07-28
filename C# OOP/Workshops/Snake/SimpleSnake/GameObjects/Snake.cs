using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace SimpleSnake.GameObjects;

public class Snake
{
    private Position _movementDirection;
    private readonly Queue<Position> _body = new();
    private readonly HashSet<Position> _bodySet = new();

    public Snake(Position initialPosition, Position movementDirection)
    {
        this.SetNewHead(initialPosition);
        this.MovementDirection = movementDirection;
    }

    public Position Head { get; private set; }
    public int Length => this._body.Count;
    public Position MovementDirection
    {
        get => this._movementDirection;
        set
        {
            if (Math.Abs(value.X) + Math.Abs(value.Y) != 1)
                throw new InvalidOperationException("Invalid movement direction.");

            this._movementDirection = value;
        }
    }

    public bool Expand() => this.SetNewHead(this.Head + this.MovementDirection);

    public Position Shorten()
    {
        if (this._body.Count == 1)
            throw new InvalidOperationException("Your snake's body cannot be shortened. You lost.");

        Position formerTailPosition = this._body.Dequeue();
        this._bodySet.Remove(formerTailPosition);

        return formerTailPosition;
    }

    public bool IsLayingOn(Position position)
        => this._bodySet.Contains(position);                     

    private bool SetNewHead(Position nextHeadPosition)
    {
        if (!this._bodySet.Add(nextHeadPosition)) return false;
 
        this.Head = nextHeadPosition;
        this._body.Enqueue(nextHeadPosition);
        return true;
    }
}