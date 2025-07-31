namespace Mandelbrot.FrameEngine;

public static class FrameSaver
{
	public static event Action<string>? OnMessage;

	public static void Save(Image image)
	{
		if (image is null)
			throw new NullReferenceException();

		SaveFileDialog dialog = new SaveFileDialog()
		{
			Title = "Сохранить кадр в...",
			Filter = "Файлы изображений (*.JPG)|*.JPG",
			CheckPathExists = true,
			FileName = "Maldebrot"
		};

		if (dialog.ShowDialog() == DialogResult.OK)
		{
			image.Save(dialog.FileName);
			OnMessage?.Invoke($"Кадр был сохранен в \'{dialog.FileName}\'");
		}
	}
}
