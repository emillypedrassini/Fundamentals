using System;

namespace MultipleInheritance
{
	public class UiControl
	{
		public string Id { get; set; }
		public Size Size { get; set; }
		public Position TopLeft { get; set; }

		public virtual void Draw()
		{
			Console.WriteLine("Draw.");
		}

		public void Focus()
		{
			Console.WriteLine("Received focus.");
		}
	}
}
