using System;

namespace Constructors
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("=> Create instance of class Car()");
			var car = new Car();

			Console.WriteLine();

			Console.WriteLine("=> Create instance of class Dog()");
			var dog = new Dog("Tedy");

			Console.ReadLine();
		}
	}

	public class Vehicle
	{
		private readonly string _registrationNumber;

		public Vehicle()
		{
			Console.WriteLine("Vehicle is being initialized.");
		}

		public Vehicle(string registrationNumber)
		{
			this._registrationNumber = registrationNumber;
			Console.WriteLine("Vehicle is being initialized. {0}", registrationNumber);

		}
	}

	public class Car : Vehicle
	{
		public Car()
		{
			Console.WriteLine("Car is being initialized.");

		}
	}

	public class Animal
	{
		private readonly string _name;

		//public Animal()
		//{
		//	Console.WriteLine("Animal is being initialized.");
		//}

		public Animal(string name)
		{
			_name = name;
			Console.WriteLine("Animal {0} is being initialized.", name);
		}
	}

	public class Dog : Animal
	{
		//public Dog()
		//{
		//	Console.WriteLine("Dog is being initialized.");
		//}

		public Dog(string name)
			: base(name)
		{
			Console.WriteLine("Dog is being initialized.");
		}
	}
}
