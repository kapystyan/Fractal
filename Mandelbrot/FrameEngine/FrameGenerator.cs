using Mathematics;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Mandelbrot;

public class FrameGenerator
{
	private const PixelFormat BASE_PIXEL_FORMAT = PixelFormat.Format32bppArgb;

	public Bitmap GetFrame(int quality, float scale, Vector2Int frameSize, Vector2 worldCenter, Color color)
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

		for (int y = 0; y < frame.Height; y++)
		{
			for (int x = 0; x < frame.Width; x++)
			{
				int p = (y * frame.Width + x) * 4;
				Vector2 xy0 = new Vector2((x - frameSize.X / 2.0F) / scale + worldCenter.X, -(y - frameSize.Y / 2.0F) / scale + worldCenter.Y);
				float x0 = xy0.X, y0 = xy0.Y;
				float xN, yN;
				bool isDotInclude = true;

				for (int i = 0; i < quality; i++)
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
					rgba[p] = color.B; // blue
					rgba[p + 1] = color.G; // green
					rgba[p + 2] = color.R; // red
					rgba[p + 3] = color.A; // alpha
				}
				else
				{
					rgba[p] = 0; // blue
					rgba[p + 1] = 0; // green
					rgba[p + 2] = 0; // red
					rgba[p + 3] = 255; // alpha
				}
			}
		}

		Terminal.Print($"Копирование стека в область -> {ptr.ToInt64()}");
		Marshal.Copy(rgba, 0, ptr, count);

		Terminal.Print("Чистка памяти");
		frame.UnlockBits(meta);

		Terminal.Print($"Сгенерировано {frameSize.X * frameSize.Y} пикселей");
		Terminal.Print("Конец генерации");

		return frame;
	}
}