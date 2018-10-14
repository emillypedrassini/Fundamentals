using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1
{
	class Program
	{
		static void Main(string[] args)
		{
			Stopwatch stopwatch = new Stopwatch();

			stopwatch.Start();

			stopwatch.Stop();

			Console.WriteLine(stopwatch.TimeSpan);
			Console.WriteLine();

			Console.ReadLine();

		}
	}
}
