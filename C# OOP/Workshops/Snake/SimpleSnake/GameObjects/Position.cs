using System;
using System.Net.Http.Headers;

namespace SimpleSnake.GameObjects;

public readonly struct Position : IEquatable<Position>
{
    public Position(int x, int y)
    {
        this.X = x; 
        this.Y = y;
    }
    public int X { get; }
    public int Y { get; }

    public static Position operator +(Position a, Position b)
        => new(a.X + b.X, a.Y + b.Y);

    public static Position operator *(int k, Position a)
        => new(k * a.X, k * a.Y);

    public static bool operator ==(Position a, Position b)
        => a.Equals(b);

    public static bool operator !=(Position a, Position b)
        => !a.Equals(b);

    public bool Equals(Position other) => X == other.X && Y == other.Y;

    public override bool Equals(object obj) => obj is Position other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(X, Y);
}