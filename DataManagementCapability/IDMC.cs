using System.Collections.Generic;

namespace DataManagementCapability
{
	internal interface IDMC<T>
	{
		IEnumerable<T> Read(string dataElementType);

		void Register(params string[] dataElementTypes);

		void Remove(params string[] dataElementTypes);

		void Update(string dataElementType, params T[] dataElements);
	}
}