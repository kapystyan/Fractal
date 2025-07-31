using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Mathematics;

public readonly struct Vector2Int
{
	private readonly int _x = default;
	private readonly int _y = default;

	public Vector2Int(int x, int y)
	{
		_x = x;
		_y = y;
	}

	public readonly int X => _x;
	public readonly int Y => _y;

	public override string ToString() => $"({X}; {Y})";
	public override bool Equals([NotNullWhen(true)] object? obj) => obj is Vector2Int vector && this == vector;
	public override int GetHashCode() => RuntimeHelpers.GetHashCode(this);

	public static Vector2Int operator +(Vector2Int left, Vector2Int right) => new Vector2Int(left.X + right.X, left.Y + right.Y);
	public static Vector2Int operator -(Vector2Int left, Vector2Int right) => new Vector2Int(left.X - right.X, left.Y - right.Y);
	public static bool operator ==(Vector2Int left, Vector2Int right) => left.X == right.X && left.Y == right.Y;
	public static bool operator !=(Vector2Int left, Vector2Int right) => !(left == right);
}