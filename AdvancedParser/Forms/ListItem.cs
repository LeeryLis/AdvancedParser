namespace AdvancedParser.Forms
{
	public class ListItem<T1, T2>
	{
		public T1 Key { get; }
		public T2 Value { get; }

		public ListItem(T1 key, T2 value)
		{
			Key = key;
			Value = value;
		}

		public override string ToString()
		{
			return Key.ToString();
		}
	}
}
