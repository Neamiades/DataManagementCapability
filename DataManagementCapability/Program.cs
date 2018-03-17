using System;
using System.Collections.Generic;

namespace DataManagementCapability
{
	internal static class Program
	{
		static void Main()
		{
			var dmc = new DMC<DataElement>();

			try
			{
				dmc.Register("TVs", "Laptops");
				dmc.Register("TVs", "Persons");
			}
			catch (ArgumentException ex)
			{
				Console.Error.WriteLine(ex.Message);
			}

			try
			{
				dmc.Update("TVs", new TV(1, "Pulsar", "Samsung"), new TV(2, "Vevo", "Sony"));
				dmc.Update("Persons", new Person(1, "Serhii", "Good"), new Person(2, "Anton", "Bad"));
			}
			catch (KeyNotFoundException ex)
			{
				Console.Error.WriteLine(ex.Message);
			}

			try
			{
				var televisors = dmc.Read("TVs");

				foreach (var tv in televisors)
				{
					Console.WriteLine($"{tv.Id} - {tv.Name}");
				}

				var persons = dmc.Read("Persons");

				foreach (var person in persons)
				{
					Console.WriteLine($"{person.Id} - {person.Name}");
				}
			}
			catch (KeyNotFoundException ex)
			{
				Console.Error.WriteLine(ex.Message);
			}
		}
	}
}
