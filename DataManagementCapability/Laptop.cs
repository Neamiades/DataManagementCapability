namespace DataManagementCapability
{
    internal sealed class Laptop : DataElement
	{
		public string Firm { get; }

		public Laptop(int id, string name, string firm) : base(id, name)
		{
			Firm = firm;
		}
	}
}
