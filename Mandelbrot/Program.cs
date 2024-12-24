namespace Mandelbrot;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();

        MainForm mainForm = new MainForm();
        MainFormPresenter mainFormPresenter = new MainFormPresenter(mainForm);

        Application.Run(mainForm);
    }
}