using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
	class Program
	{
		static void Main(string[] args)
		{
			UsePoints();
			Console.WriteLine();

			UseParams();
			Console.WriteLine();
			
			UseRef();
			Console.WriteLine();

			UseOut();
			Console.WriteLine();

			UseParse();
			Console.WriteLine();

			Console.ReadLine();

		}

		private static void UsePoints()
		{
			Console.WriteLine("----------Overloading a method");
			try
			{
				var point = new Point(10, 20);
				point.Move(new Point(40, 60));
				Console.WriteLine("Point is at ({0}, {1})", point.X, point.Y);

				point.Move(100, 200);
				Console.WriteLine("Point is at ({0}, {1})", point.X, point.Y);
			}
			catch (Exception ex)
			{
				Console.WriteLine("An unexpected error occured: {0} ", ex);
			}
		}

		private static void UseParams()
		{
			Console.WriteLine("----------We can use the PARAMS Modifier ");
			var calculator = new Calculator();

			Console.WriteLine(calculator.Add(1, 2));
			Console.WriteLine(calculator.Add(1, 2, 3));
			Console.WriteLine(calculator.Add(1, 2, 3, 4));
			Console.WriteLine(calculator.Add(new int[] { 1, 2, 3, 4, 5 }));
		}

		private static void UseRef()
		{
			Console.WriteLine("----------We can use the REF Modifier ");

			var calculator = new Calculator();
			var number = 1;

			Console.WriteLine("Use the REF Modifier");
			calculator.ModifierRef(ref number);
			Console.WriteLine(number);

			number = 1;
			Console.WriteLine("Not use the REF Modifier");
			calculator.Sum(number);
			Console.WriteLine(number);

		}

		private static void UseOut()
		{
			Console.WriteLine("----------We can use the OUT Modifier ");

			var calculator = new Calculator();

			calculator.TryParse("abc");
			calculator.TryParse("2018");

			int number;
			calculator.ModifierOut(out number);
			Console.WriteLine(number);

		}

		private static void UseParse()
		{
			Console.WriteLine("----------We can't use the OUT Modifier ");
			var calculator = new Calculator();

			calculator.Parse("abc");
			calculator.Parse("2018");
		}

	}
}
