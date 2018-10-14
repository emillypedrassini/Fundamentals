using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxing
{
	class Program
	{
		static void Main(string[] args)
		{
			var genericList = new ArrayList();
			genericList.Add(1);
			genericList.Add("Maria");
			genericList.Add(DateTime.Today);

			//var number = list[1]; //error

			var anotherList = new List<int>();
			anotherList.Add(1);

			List<string> names = new List<string>();
			names.Add("Maria");
			names.Add("Gabriel");
			names.Add("Joaquina");

			Console.ReadLine();

		}
	}
}
