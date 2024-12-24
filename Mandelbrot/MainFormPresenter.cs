namespace Mandelbrot;

public class MainFormPresenter
{
	private readonly IMainForm _view;
	private readonly FrameGenerator _framer;

	public MainFormPresenter(IMainForm view, FrameGenerator framer)
	{
		_view = view;
		_framer = framer;

		_view.OnGenerate += View_OnGenerate;
	}

	private void View_OnGenerate(object? sender, MainFormEventArgs e)
	{
		e.Viewport.Image = _framer.GetFrame(e.Quality, e.Scale, e.FrameSize, e.WorldCenter, e.Color);
	}
}