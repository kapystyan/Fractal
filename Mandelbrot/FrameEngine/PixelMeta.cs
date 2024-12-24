using Mathematics;

namespace Mandelbrot.FrameEngine;

public struct PixelMeta
{
	private Vector2 _dot;
	private int _offset;

	public PixelMeta(Vector2 dot, int offset)
	{
		_dot = dot;
		_offset = offset;
	}

	public Vector2 Dot => _dot;
	public int Offset => _offset;
}
