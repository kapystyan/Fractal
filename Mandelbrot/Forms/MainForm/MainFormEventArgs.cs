using Mathematics;

namespace Mandelbrot.Forms.MainForm;

public class MainFormEventArgs : EventArgs
{
	public MainFormEventArgs(double scale, int quality, Vector2Int frameSize, Vector2 worldCenter, Color color)
	{
		Scale = scale;
		Quality = quality;
		FrameSize = frameSize;
		WorldCenter = worldCenter;
		Color = color;
	}

	public double Scale { get; }
	public int Quality { get; }
	public Vector2Int FrameSize { get; }
	public Vector2 WorldCenter { get; }
	public Color Color { get; }
}