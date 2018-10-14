using System;

namespace MultipleInheritance
{
	public class TextBox : UiControl, IDraggeble, IDroppable
	{
		public void Drag()
		{
			Console.WriteLine("Drag");
		}

		public void Drop()
		{
			Console.WriteLine("Drop");
		}
	}
}
