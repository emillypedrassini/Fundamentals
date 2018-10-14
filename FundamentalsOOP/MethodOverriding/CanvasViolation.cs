using System;
using System.Collections.Generic;

namespace MethodOverriding
{
	//public enum ShapeType
	//{
	//	Circle,
	//	Rectangle,
	//	Triangle
	//}

	public class CanvasViolation
	{
		public void DrawShapes(List<Shape> shapes)
		{
			foreach (var shape in shapes)
			{
				//switch (shape.Type)
				//{
				//	case ShapeType.Circle:
				//		Console.WriteLine("Draw a Circle");
				//		break;

				//	case ShapeType.Rectangle:
				//		Console.WriteLine("Draw a Rectangle");
				//		break;

				//	default:
				//		break;
				//}
			}
		}
	}
}
