using Mathematics;

namespace Mandelbrot;

public partial class MainForm : Form, IMainForm
{
	private double _scale = 500.0D;
	private int _quality = 100;
	private Vector2 _worldCenter;
	private Vector2 _localCenter;
	private Color _color = Color.DeepSkyBlue;

	public MainForm()
	{
		InitializeComponent();

		Terminal.OnAddLine += (obj) =>
		{
			Terminal_TextBox.Lines = obj.ToArray();
			Terminal_TextBox.SelectionStart = Terminal_TextBox.TextLength;
			Terminal_TextBox.ScrollToCaret();
		};

		Quality_TrackBar.ValueChanged += (sender, e) =>
		{
			_quality = Quality_TrackBar.Value * 10;
			QualityValue_Label.Text = _quality.ToString();
		};

		Viewport_PictureBox.MouseClick += (sender, e) =>
		{
			_scale *= 1.5D;
			_worldCenter = new Vector2(_localCenter.X, _localCenter.Y);
			Draw();
		};
		Viewport_PictureBox.MouseMove += (sender, e) =>
		{
			_localCenter = new Vector2(
				(e.Location.X - Viewport_PictureBox.Width / 2.0D) / _scale + _worldCenter.X,
				-(e.Location.Y - Viewport_PictureBox.Height / 2.0D) / _scale + _worldCenter.Y
			);
			MousePosition_L.Text = $"X: {_localCenter.X}; Y: {_localCenter.Y}";
		};

		ChooseColor_BT.Click += (sender, e) =>
		{
			if (FractalZoneColor.ShowDialog() == DialogResult.OK)
			{
				_color = FractalZoneColor.Color;
				Terminal.Print($"Следующая генерация кадра изменена");
			}
		};
		ResetZoom_BT.Click += (sender, e) =>
		{
			if (_worldCenter != Vector2.Zero)
			{
				_worldCenter = Vector2.Zero;
				_scale = 500.0D;
				Draw();
			}
			else
				Terminal.Warning($"Положение уже сброшено или кадр не сгенерирован");
		};
		SaveImage_BT.Click += (sender, e) => OnImageSave?.Invoke(Viewport_PictureBox.Image);
		Generate_BT.Click += (sender, e) => Draw();
		MinimiseForm_BT.Click += (sender, e) => { WindowState = FormWindowState.Minimized; };
		CloseForm_BT.Click += (sender, e) => Close();
	}

	private void Draw()
	{
		if (_quality > 400)
			Terminal.Warning($"При значении параметра качества {_quality}, генерация кадра может занять некоторое время");
		Vector2Int frameSize = new Vector2Int(Viewport_PictureBox.Width, Viewport_PictureBox.Height);
		OnGenerate?.Invoke(this, new MainFormEventArgs(_scale, _quality, frameSize, _worldCenter, Viewport_PictureBox, _color));
	}

	public event EventHandler<MainFormEventArgs>? OnGenerate;
	public event Action<Image>? OnImageSave;
}