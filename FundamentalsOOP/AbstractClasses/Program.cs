using System;

namespace AbstractClasses
{
	class Program
	{
		static void Main(string[] args)
		{
			//var shape = new Shape(); // it's not possible

			var circle = new Circle();
			circle.Draw();
			circle.Select();

			var rectangle = new Rectangle();
			rectangle.Draw();
			rectangle.Copy();

			Console.ReadKey();
		}
	}
}
