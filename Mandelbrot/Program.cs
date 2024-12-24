namespace Mandelbrot;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();

        MainForm mainForm = new MainForm();
        FrameGenerator framer = new FrameGenerator();
        MainFormPresenter mainFormPresenter = new MainFormPresenter(mainForm, framer);

        Application.Run(mainForm);
    }
}