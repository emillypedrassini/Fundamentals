using System;

namespace Methods
{
	public class Calculator
	{
		public int Add(params int[] numbers)
		{
			var sum = 0;
			foreach (var number in numbers)
			{
				sum += number;
			}

			return sum;
		}

		public void Sum(int number)
		{
			number += 2;
		}

		public void ModifierRef(ref int number)
		{
			number += 2;
		}

		public void ModifierOut(out int a)
		{
			a = 1;
		}

		public void TryParse(string value)
		{
			int number;
			var result = int.TryParse(value, out number);

			if (result)
				Console.WriteLine(number);
			else
				Console.WriteLine("Conversion failed");
		}

		public void Parse(string value)
		{
			try
			{
				var result = int.Parse(value);
				Console.WriteLine(result);
			}
			catch (Exception)
			{
				Console.WriteLine("Conversion failed");
			}

		}
	}
}
