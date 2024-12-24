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

	public static Vector2Int operator +(Vector2Int v1, Vector2Int v2) => new Vector2Int(v1.X + v2.X, v1.Y + v2.Y);
	public static Vector2Int operator -(Vector2Int v1, Vector2Int v2) => new Vector2Int(v1.X - v2.X, v1.Y - v2.Y);
}
