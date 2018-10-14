using System;

namespace Classes
{
	public class Person
	{
		public string Name;

		public void Introduce(string to)
		{
			Console.WriteLine("Hi {0}, I am {1}", to, this.Name);
		}

		public Person Parse(string str)
		{
			var person = new Person();
			person.Name = str;

			return person;
		}

		public static Person ParseStatic(string str)
		{
			var person = new Person();
			person.Name = str;

			return person;
		}
	}
}
