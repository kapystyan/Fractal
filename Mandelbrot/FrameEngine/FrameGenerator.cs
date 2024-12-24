using Mathematics;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Mandelbrot;

public class FrameGenerator
{
	private const PixelFormat BASE_PIXEL_FORMAT = PixelFormat.Format32bppArgb;
	private int _quality;
	private decimal _scale;
	private Vector2Int _frameSize;
	private Vector2 _worldCenter;
	private Color _color;

	public FrameGenerator(int quality, decimal scale, Vector2Int frameSize, Vector2 worldCenter, Color color)
	{
		_quality = quality;
		_scale = scale;
		_frameSize = frameSize;
		_worldCenter = worldCenter;
		_color = color;
	}

	public Bitmap GetFrame()
	{
		Terminal.Print("Начало генерации");

		Bitmap frame = new Bitmap(_frameSize.X, _frameSize.Y, BASE_PIXEL_FORMAT);
		Terminal.Print("Фиксация памяти");
		var meta = frame.LockBits(new Rectangle(0, 0, frame.Width, frame.Height), ImageLockMode.ReadWrite, BASE_PIXEL_FORMAT);
		IntPtr ptr = meta.Scan0;
		int count = Math.Abs(meta.Stride) * frame.Height;
		byte[] rgba = new byte[count];

		Terminal.Print($"Копирование стека в область -> {ptr.ToInt64()}");
		Marshal.Copy(ptr, rgba, 0, count);

		List<Vector2Int> shader = new List<Vector2Int>();

		for (int y = 0; y < frame.Height; y++)
			for (int x = 0; x < frame.Width; x++)
				shader.Add(new Vector2Int(x, y));

		Parallel.ForEach(shader, f =>
		{
			SetPixel(f.X, f.Y, rgba);
		});

		Terminal.Print($"Копирование стека в область -> {ptr.ToInt64()}");
		Marshal.Copy(rgba, 0, ptr, count);

		Terminal.Print("Чистка памяти");
		frame.UnlockBits(meta);

		Terminal.Print($"Сгенерировано {_frameSize.X * _frameSize.Y} пикселей");
		Terminal.Print("Конец генерации");

		return frame;
	}

	private void SetPixel(int x, int y, byte[] rgba)
	{
		int point = (y * _frameSize.X + x) * 4;
		Vector2 xy0 = new Vector2((x - _frameSize.X / 2.0M) / _scale + _worldCenter.X, -(y - _frameSize.Y / 2.0M) / _scale + _worldCenter.Y);

		decimal x0 = xy0.X, y0 = xy0.Y;
		decimal xN, yN;
		bool isDotInclude = true;

		int i;
		for (i = 0; i < _quality; i++)
		{
			xN = xy0.X * xy0.X - xy0.Y * xy0.Y + x0;
			yN = 2 * xy0.X * xy0.Y + y0;

			if (xN * xN + yN * yN > 4)
			{
				isDotInclude = false;
				break;
			}

			xy0 = new Vector2(xN, yN);
		}

		if (isDotInclude)
		{
			rgba[point] = _color.B; // blue
			rgba[point + 1] = _color.G; // green
			rgba[point + 2] = _color.R; // red
			rgba[point + 3] = 255; // alpha
		}
		else
		{
			float displacementCoefficient = (float)i / _quality;

			rgba[point] = (byte)(displacementCoefficient * _color.B); // blue
			rgba[point + 1] = (byte)(displacementCoefficient * _color.G); // green
			rgba[point + 2] = (byte)(displacementCoefficient * _color.R); // red
			rgba[point + 3] = 255; // alpha
		}
	}
}