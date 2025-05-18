using System.Diagnostics.CodeAnalysis;

namespace Mathematics;

public readonly struct Vector2Int
{
	private readonly int _x, _y;

	public Vector2Int(int x, int y)
	{
		_x = x;
		_y = y;
	}

	public int X => _x;
	public int Y => _y;

	public override string ToString() => $"({X}; {Y})";
	public override bool Equals([NotNullWhen(true)] object? obj) => base.Equals(obj);
	public override int GetHashCode() => base.GetHashCode();

	public static Vector2Int operator +(Vector2Int left, Vector2Int right) => new Vector2Int(left.X + right.X, left.Y + right.Y);
	public static Vector2Int operator -(Vector2Int left, Vector2Int right) => new Vector2Int(left.X - right.X, left.Y - right.Y);
	public static bool operator ==(Vector2Int left, Vector2Int right) => left.X == right.X && left.Y == right.Y;
	public static bool operator !=(Vector2Int left, Vector2Int right) => !(left == right);
}