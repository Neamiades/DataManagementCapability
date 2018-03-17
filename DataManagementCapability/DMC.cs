using System;
using System.Collections.Generic;

namespace DataManagementCapability
{
	internal sealed class DMC<T> : IDMC<T>
	{
		private readonly IDictionary<string, List<T>> _storage;

		public DMC()
		{
			_storage = new Dictionary<string, List<T>>();
		}

		/// <exception cref="ArgumentException">
		/// Thrown when given data element type is already registered at DMC
		/// </exception>
		public void Register(params string[] dataElementTypes)
		{
			foreach (string dataElementType in dataElementTypes)
			{
				if (!_storage.TryAdd(dataElementType, new List<T>()))
				{
					throw new ArgumentException($"{dataElementType} type is already registered");
				}
			}
		}

		public void Remove(params string[] dataElementTypes)
		{
			foreach (string dataElementType in dataElementTypes)
			{
				_storage.Remove(dataElementType);
			}
		}

		/// <exception cref="KeyNotFoundException">
		/// Thrown when given data element type is not registered at DMC
		/// </exception>
		public void Update(string dataElementType, params T[] dataElements)
		{
			if (_storage.TryGetValue(dataElementType, out List<T> dataElementList))
			{
				dataElementList.AddRange(dataElements);

				return;
			}

			throw new KeyNotFoundException($"The update operation can not be applied - {dataElementType} type is not registered");
		}

		/// <exception cref="KeyNotFoundException">
		/// Thrown when given data element type is not registered at DMC
		/// </exception>
		public IEnumerable<T> Read(string dataElementType)
		{
			if (!_storage.TryGetValue(dataElementType, out List<T> dataElementList))
			{
				throw new KeyNotFoundException($"The read operation can not be applied - {dataElementType} type is not registered");
			}

			return dataElementList;
		}
	}
}
