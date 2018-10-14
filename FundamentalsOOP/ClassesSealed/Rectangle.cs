using System;

namespace ClassesSealed
{
	public class Rectangle : Shape
	{
		public sealed override void Draw()
		{
			Console.WriteLine("Draw a Rectangle");

		}
	}
}
