using System.Data.Common;
using System.Text.Json;

namespace SaveLoad;

public class SaveLoadSystem : ISaveLoadSystem
{
	private readonly string _path;
	private readonly JsonSerializerOptions _options;

	public SaveLoadSystem(string filePath)
	{
		_path = Path.GetFullPath(filePath);
		_options = new JsonSerializerOptions()
		{
			WriteIndented = true
		};
	}

	public event Action<string>? OnCastMessage;

	public void Save(SaveLoadData data)
	{
		ArgumentNullException.ThrowIfNull(data);

		if (!File.Exists(_path))
		{
			File.Create(_path).Close();
			OnCastMessage?.Invoke($"Файл по пути \'{_path}\' не найден. Создан новый файл");
		}

		string json = JsonSerializer.Serialize(data, _options);
		OnCastMessage?.Invoke(json);

		File.WriteAllText(_path, json);
	}
	public SaveLoadData? Load()
	{
		string json = File.ReadAllText(_path);
		SaveLoadData? data = JsonSerializer.Deserialize<SaveLoadData>(json);
		if (data is null)
			OnCastMessage?.Invoke($"Файл по пути \'{_path}\' не существует");
		return data;
	}
}