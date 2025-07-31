using Mandelbrot.Forms.MainForm;

namespace Mandelbrot;

public interface IMainForm
{
	event EventHandler<MainFormEventArgs> OnGenerate;
	event Action<Image> OnImageSave;

	void ShowFrame(Image image);
}
