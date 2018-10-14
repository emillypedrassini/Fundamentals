using System;

namespace MultipleInheritance
{
	class Program
	{
		static void Main(string[] args)
		{
			var text = new TextBox();

			text.Drag();
			text.Drop();
			text.Draw();
			text.Focus();

			Console.ReadKey();
		}
	}
}
