namespace DataManagementCapability
{
    internal abstract class DataElement
    {
		public int    Id   { get; }

		public string Name { get; }

		public DataElement(int id, string name)
		{
			Id = id;
			Name = name;
		}
	}
}
