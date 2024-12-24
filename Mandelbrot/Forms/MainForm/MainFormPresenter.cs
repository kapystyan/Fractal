namespace Mandelbrot;

public class MainFormPresenter
{
	private readonly IMainForm _view;

	public MainFormPresenter(IMainForm view)
	{
		_view = view;

		_view.OnGenerate += View_OnGenerate;
		_view.OnImageSave += View_OnImageSave;
	}

	private void View_OnImageSave(Image frame)
	{
		FrameSaver saver = new FrameSaver();
		saver.Save(frame);
	}
	private void View_OnGenerate(object? sender, MainFormEventArgs e)
	{
		FrameGenerator framer = new FrameGenerator(e.Quality, e.Scale, e.FrameSize, e.WorldCenter, e.Color);
		e.Viewport.Image = framer.GetFrame();
	}
}