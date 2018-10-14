using System;

namespace ClassesSealed
{
	public sealed class Circle : Shape
	{
		public override void Draw()
		{
			Console.WriteLine("Draw a Circle");
		}
	}
}
