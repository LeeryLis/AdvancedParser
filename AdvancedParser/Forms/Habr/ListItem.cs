namespace AdvancedParser.Forms.Habr
{
	public class ListItem
	{
		public string Key { get; }
		public string Value { get; }

		public ListItem(string key, string value)
		{
			Key = key;
			Value = value;
		}

		public override string ToString()
		{
			return Key;
		}
	}
}
