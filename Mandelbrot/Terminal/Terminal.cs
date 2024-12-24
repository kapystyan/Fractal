namespace Mandelbrot
{
	public static class Terminal
	{
		private static List<string> _lines;

		static Terminal()
		{
			_lines = new List<string>();
		}

		public static event Action<List<string>>? OnAddLine;

		public static void Print(string message)
		{
			Show($"Сообщение: {message}");
		}
		public static void Warning(string message)
		{
			Show($"Предупреждение: {message}");
		}
		public static void Error(string message)
		{
			Show($"Ошибка: {message}");
		}
		public static void Show(string message)
		{
			_lines.Add(message);
			OnAddLine?.Invoke(_lines);
		}
	}
}