using Mathematics;

namespace Mandelbrot;

public partial class MainForm : Form, IMainForm
{
	private float _scale = 200.0F;
	private int _quality = 50;
	private Vector2 _worldCenter;
	private Vector2 _localCenter;
	private Color _color = Color.DarkGray;

	public MainForm()
	{
		InitializeComponent();

		Terminal.OnAddLine += (obj) =>
		{
			Terminal_TextBox.Lines = obj.ToArray();
			Terminal_TextBox.SelectionLength = Terminal_TextBox.Text.ToArray().First();
			Terminal_TextBox.ScrollToCaret();
		};

		Scale_TrackBar.ValueChanged += (sender, e) =>
		{
			_scale = Scale_TrackBar.Value * 100.0F;
			BaseScale_Label.Text = _scale.ToString();
		};
		Quality_TrackBar.ValueChanged += (sender, e) =>
		{
			_quality = Quality_TrackBar.Value;
			QualityValue_Label.Text = _quality.ToString();
		};

		Viewport_PictureBox.MouseClick += (sender, e) =>
		{
			_scale *= 1.5F;
			_worldCenter = new Vector2(_localCenter.X, _localCenter.Y);
			Draw();
		};
		Viewport_PictureBox.MouseMove += (sender, e) =>
		{
			_localCenter = new Vector2(
				(e.Location.X - (float)Viewport_PictureBox.Width / 2.0F) / _scale + _worldCenter.X,
				-(e.Location.Y - (float)Viewport_PictureBox.Height / 2.0F) / _scale + _worldCenter.Y
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
		Generate_BT.Click += (sender, e) => Draw();
		MinimiseForm_BT.Click += (sender, e) => { WindowState = FormWindowState.Minimized; };
		CloseForm_BT.Click += (sender, e) => Close();
	}

	private void Draw()
	{
		if (_quality > 100)
			Terminal.Warning($"При значении параметра качества {_quality}, генерация кадра может занять некоторое время");
		Vector2Int frameSize = new Vector2Int(Viewport_PictureBox.Width, Viewport_PictureBox.Height);
		OnGenerate?.Invoke(this, new MainFormEventArgs(_scale, _quality, frameSize, _worldCenter, Viewport_PictureBox, _color));
	}

	public event EventHandler<MainFormEventArgs>? OnGenerate;
}