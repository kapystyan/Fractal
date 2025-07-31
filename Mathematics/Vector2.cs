using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Mathematics;

public readonly struct Vector2
{
	private readonly double _x = default;
	private readonly double _y = default;

	public Vector2(double x, double y)
	{
		_x = x;
		_y = y;
	}

	public readonly double X => _x;
	public readonly double Y => _y;

	public static Vector2 Zero => new Vector2();
	public static Vector2 One => new Vector2(1.0D, 1.0D);

	public override string ToString() => $"({X}; {Y})";
	public override bool Equals([NotNullWhen(true)] object? obj) => obj is Vector2 vector && this == vector;
	public override int GetHashCode() => RuntimeHelpers.GetHashCode(this);

	public static Vector2 operator +(Vector2 left, Vector2 right) => new Vector2(left.X + right.X, left.Y + right.Y);
	public static Vector2 operator -(Vector2 left, Vector2 right) => new Vector2(left.X - right.X, left.Y - right.Y);
	public static bool operator ==(Vector2 left, Vector2 right) => left.X == right.X && left.Y == right.Y;
	public static bool operator !=(Vector2 left, Vector2 right) => !(left == right);
}