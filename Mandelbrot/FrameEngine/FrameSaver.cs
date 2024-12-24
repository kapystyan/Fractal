namespace Mandelbrot;

public class FrameSaver
{
	public void Save(Image image)
	{
		if (image is not null)
		{
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
				Terminal.Print($"Кадр был сохранен в \'{dialog.FileName}\'");
			}
		}
		else
			Terminal.Warning($"Кадр был пуст");
	}
}
