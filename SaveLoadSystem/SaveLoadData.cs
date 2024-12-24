namespace SaveLoad
{
	[Serializable]
	public class SaveLoadData
	{
		private string _id;
		private object[] _data;

		public SaveLoadData(string id, object[] data)
		{
			_id = id;
			_data = data;
		}

		public string ID => _id;
		public object[] Data => _data;
	}
}
