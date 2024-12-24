using System.Diagnostics.CodeAnalysis;

namespace Mathematics;

public readonly struct Vector2
{
	private readonly double _x, _y;

	public Vector2()
	{
		_x = 0.0D;
		_y = 0.0D;
	}
	public Vector2(double x, double y)
	{
		_x = x;
		_y = y;
	}

	public double X => _x;
	public double Y => _y;

	public static Vector2 Zero => new Vector2(0, 0);

	public static Vector2 operator +(Vector2 v1, Vector2 v2) => new Vector2(v1.X + v2.X, v1.Y + v2.Y);
	public static Vector2 operator -(Vector2 v1, Vector2 v2) => new Vector2(v1.X - v2.X, v1.Y - v2.Y);
	public static bool operator ==(Vector2 v1, Vector2 v2) => v1.X == v2.X && v1.Y == v2.Y;
	public static bool operator !=(Vector2 v1, Vector2 v2) => !(v1.X == v2.X && v1.Y == v2.Y);

	public override string ToString() => $"({X}; {Y})";
	public override bool Equals([NotNullWhen(true)] object? obj) => base.Equals(obj);
	public override int GetHashCode() => base.GetHashCode();
}