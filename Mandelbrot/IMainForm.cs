namespace Mandelbrot;

public interface IMainForm
{
	event EventHandler<MainFormEventArgs> OnGenerate;
	event Action<Image> OnImageSave;
}
