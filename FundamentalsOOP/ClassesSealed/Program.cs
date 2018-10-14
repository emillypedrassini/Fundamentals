using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesSealed
{
	class Program
	{
		static void Main(string[] args)
		{
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
