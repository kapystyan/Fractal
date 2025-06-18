using Mathematics;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Mandelbrot;

public class FrameGenerator(int quality, double scale, Vector2Int frameSize, Vector2 worldCenter, Color color)
{
	private const PixelFormat BASE_PIXEL_FORMAT = PixelFormat.Format32bppArgb;

	public Bitmap GetFrame()
	{
		Terminal.Print("Начало генерации");

		Bitmap frame = new Bitmap(frameSize.X, frameSize.Y, BASE_PIXEL_FORMAT);
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

		Terminal.Print($"Сгенерировано {frameSize.X * frameSize.Y} пикселей");
		Terminal.Print("Конец генерации");

		return frame;
	}

	private void SetPixel(int x, int y, byte[] rgba)
	{
		int point = (y * frameSize.X + x) * 4;
		Vector2 xy0 = new Vector2((x - frameSize.X / 2.0D) / scale + worldCenter.X, -(y - frameSize.Y / 2.0D) / scale + worldCenter.Y);

		double x0 = xy0.X, y0 = xy0.Y;
		double xN, yN;
		bool isDotInclude = true;

		int i;
		for (i = 0; i < quality; i++)
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
			rgba[point] = color.B; // blue
			rgba[point + 1] = color.G; // green
			rgba[point + 2] = color.R; // red
			rgba[point + 3] = 255; // alpha
		}
		else
		{
			float displacementCoefficient = (float)i / quality;

			rgba[point] = (byte)(displacementCoefficient * color.B); // blue
			rgba[point + 1] = (byte)(displacementCoefficient * color.G); // green
			rgba[point + 2] = (byte)(displacementCoefficient * color.R); // red
			rgba[point + 3] = 255; // alpha
		}
	}
}