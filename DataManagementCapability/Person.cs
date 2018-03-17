namespace DataManagementCapability
{
    internal sealed class Person : DataElement
	{
		public string Soul { get; }

		public Person(int id, string name, string soul) : base(id, name)
		{
			Soul = soul;
		}
	}
}
