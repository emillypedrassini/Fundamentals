using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casting
{

	class Program
	{
		static void Main(string[] args)
		{
			Upcasting();
			Downcasting();

			Console.ReadKey();
			
		}

		private static void Downcasting()
		{
			Text text = new Text();
			Shape shape = text;
			Text anotherText = (Text)shape;

			//Car car = (Car)shape;   // throws InvalidCastException

			Object obj = new Object();
			//Car car = (Car)obj;
			Car car = obj as Car;

			if (car != null)
			{
				//...
			}

			if (obj is Car)
			{
				Car car2 = (Car)obj;
				//...
			}
		}

		private static void Upcasting()
		{
			UseText();
			UseStremReader();
			UseList();
		}

		private static void UseText()
		{
			Text text = new Text();
			Shape shape = text;

			text.Width = 200;
			shape.Width = 100;
			Console.WriteLine(text.Width);  //100
		}

		private static void UseStremReader()
		{
			//StreamReader streamReader = new StreamReader(new FileStream());
			StreamReader streamReader = new StreamReader(new MemoryStream());
		}

		private static void UseList()
		{
			ArrayList list = new ArrayList();
			list.Add(1);
			list.Add("Maria");
			list.Add(new Text());

			List<string> anotherList = new List<string>();
			anotherList.Add("Maria");
			anotherList.Add("Gabi");
			anotherList.Add("Gabriel");

			Shape shape = new Shape
			{
				Height = 50,
				Width = 100
			};

			List<Shape> shapes = new List<Shape>();
			shapes.Add(shape);
		}

	}
}
