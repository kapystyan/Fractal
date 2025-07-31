using Mandelbrot.FrameEngine;
using Mandelbrot.Presenters;

namespace Mandelbrot;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();

        FrameGenerator.OnMessage += Terminal.Show;

        MainForm mainForm = new MainForm();
        new FramePresenter(mainForm);

        Application.Run(mainForm);
    }
}