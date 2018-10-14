using System;

namespace Inheritance
{
	class Program
	{
		static void Main(string[] args)
		{
			var text = new Text();
			text.Width = 100;
			text.Height = 50;

			text.Copy();
			text.AddHyperlink("www.google.com");

			Console.ReadLine();
		}
	}
}
