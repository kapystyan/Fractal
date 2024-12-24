namespace Mandelbrot;

public interface IMainForm
{
	event EventHandler<MainFormEventArgs> OnGenerate;
}
