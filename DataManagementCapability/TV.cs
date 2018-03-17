namespace DataManagementCapability
{
    internal sealed class TV : DataElement
	{
		public string Firm { get; }

		public TV(int id, string name, string firm) : base(id, name)
		{
			Firm = firm;
		}
	}
}
