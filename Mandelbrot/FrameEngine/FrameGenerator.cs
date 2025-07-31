using Mathematics;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Mandelbrot.FrameEngine;

public static class FrameGenerator
{
	private static int _bias, _point;
	private static float _gradient;
	private static Vector2 _xy0;
	private static double _x0, _y0, _xN, _yN;
	private static bool _dotInclude;

	static FrameGenerator()
	{
		_bias = default;
		_point = default;
		_gradient = default;
		_xy0 = default;
		_x0 = default;
		_y0 = default;
		_xN = default;
		_yN = default;
		_dotInclude = true;
	}

	public static PixelFormat PixelFormat => PixelFormat.Format32bppArgb;

	public static event Action<string>? OnMessage;

	public static Bitmap GetFrame(Vector2Int size, Vector2 center, int quality, double scale, Color color)
	{
		OnMessage?.Invoke("Начало генерации");
		int count = default;
		byte[]? rgba = default;
		nint frameBinary = default;
		Bitmap? frame = default;
		BitmapData? meta = default;
		List<Vector2Int>? shader = [];

		frame = new Bitmap(size.X, size.Y, PixelFormat);

		OnMessage?.Invoke("Фиксация памяти");
		meta = frame.LockBits(new Rectangle(0, 0, frame.Width, frame.Height), ImageLockMode.ReadWrite, PixelFormat);
		frameBinary = meta.Scan0;
		count = Math.Abs(meta.Stride) * frame.Height;
		rgba = new byte[count];

		Marshal.Copy(frameBinary, rgba, 0, count);

		for (int y = 0; y < frame.Height; y++)
			for (int x = 0; x < frame.Width; x++)
				shader.Add(new Vector2Int(x, y));

		OnMessage?.Invoke("Заполнение пикселей");
		shader.ForEach(f =>
		{
			_point = (f.Y * size.X + f.X) * 4;
			_xy0 = new Vector2((f.X - size.X / 2.0D) / scale + center.X, -(f.Y - size.Y / 2.0D) / scale + center.Y);
			_x0 = _xy0.X;
			_y0 = _xy0.Y;

			for (_bias = 0; _bias < quality; _bias++)
			{
				_xN = _xy0.X * _xy0.X - _xy0.Y * _xy0.Y + _x0;
				_yN = 2 * _xy0.X * _xy0.Y + _y0;

				if (_xN * _xN + _yN * _yN > 4)
				{
					_dotInclude = false;
					break;
				}

				_xy0 = new Vector2(_xN, _yN);
			}

			if (_dotInclude)
			{
				rgba[_point] = color.B;
				rgba[_point + 1] = color.G;
				rgba[_point + 2] = color.R;
				rgba[_point + 3] = 255;
			}
			else
			{
				_gradient = (float)_bias / quality;

				rgba[_point] = (byte)(_gradient * color.B);
				rgba[_point + 1] = (byte)(_gradient * color.G);
				rgba[_point + 2] = (byte)(_gradient * color.R);
				rgba[_point + 3] = 255;
			}
		});

		Marshal.Copy(rgba, 0, frameBinary, count);

		frame.UnlockBits(meta);

		OnMessage?.Invoke($"Заполненно {frame.Width * frame.Height} пикселей");
		OnMessage?.Invoke("Кадр сгенерирован");
		
		return frame;
	}
}