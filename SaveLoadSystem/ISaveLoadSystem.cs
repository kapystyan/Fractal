namespace SaveLoad
{
	public interface ISaveLoadSystem
	{
		SaveLoadData? Load();
		void Save(SaveLoadData data);
		event Action<string> OnCastMessage;
	}
}