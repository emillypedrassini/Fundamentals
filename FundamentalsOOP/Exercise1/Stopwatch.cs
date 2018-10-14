using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Exercise1
{
	public class Stopwatch
	{
		public decimal TimeSpan { get; set; }

		public void Start()
		{
			this.Reset();

		}

		public void Stop()
		{

		}

		public void Reset()
		{
			this.TimeSpan = 0;
		}

	}
}
