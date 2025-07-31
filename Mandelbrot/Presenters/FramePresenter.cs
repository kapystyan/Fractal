using Mandelbrot.Forms.MainForm;
using Mandelbrot.FrameEngine;

namespace Mandelbrot.Presenters;

public class FramePresenter
{
	private readonly IMainForm _uI;

	public FramePresenter(IMainForm view)
	{
		_uI = view;

		_uI.OnGenerate += View_OnGenerate;
		_uI.OnImageSave += UI_OnImageSave;
	}

	private void UI_OnImageSave(Image frame)
	{
		FrameSaver.Save(frame);
	}
	private void View_OnGenerate(object? sender, MainFormEventArgs e)
	{
		_uI.ShowFrame(FrameGenerator.GetFrame(e.FrameSize, e.WorldCenter, e.Quality, e.Scale, e.Color));
	}
}