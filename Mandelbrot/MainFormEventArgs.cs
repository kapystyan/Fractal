using Mathematics;

namespace Mandelbrot;

public class MainFormEventArgs : EventArgs
{
	private decimal _scale;
	private int _quality;
	private Vector2Int _frameSize;
	private Vector2 _worldCenter;
	private PictureBox _viewport;
	private Color _color;

	public MainFormEventArgs(decimal scale, int quality, Vector2Int frameSize, Vector2 worldCenter, PictureBox viewport, Color color)
	{
		_scale = scale;
		_quality = quality;
		_frameSize = frameSize;
		_worldCenter = worldCenter;
		_viewport = viewport;
		_color = color;
	}

	public decimal Scale => _scale;
	public int Quality => _quality;
	public Vector2Int FrameSize => _frameSize;
	public Vector2 WorldCenter => _worldCenter;
	public PictureBox Viewport => _viewport;
	public Color Color => _color;
}