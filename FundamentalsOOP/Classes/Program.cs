using System;
using System.Collections.Generic;

namespace Classes
{
	class Program
	{
		static void Main(string[] args)
		{
			IntroductionToClasses();

			Console.WriteLine();

			IntroductionToConstructors();

			Console.ReadKey();

		}

		private static void IntroductionToConstructors()
		{
			Console.WriteLine("--------Constructors----------");

			Customer customer = new Customer();
			customer.Id = 1;
			customer.Name = "Gabriel";

			var order = new Order();
			customer.Orders.Add(order);

			Console.WriteLine(customer.Id);
			Console.WriteLine(customer.Name);
		}

		private static void IntroductionToClasses()
		{
			Console.WriteLine("--------Introduction to Classes----------");
			var person = new Person();
			person.Name = "Emilly";
			person.Introduce("Maria");

			var personStatic = Person.ParseStatic("Emilly");
			person.Introduce("José");
		}
	}

}
