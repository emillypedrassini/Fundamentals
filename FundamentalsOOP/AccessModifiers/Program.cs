using Amazon;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessModifiers
{
	class Program
	{
		static void Main(string[] args)
		{
			var person = new Person();

			var customer = new Customer();

			var user = new User();
			RateCalculator rateCalculator = new RateCalculator();

		}
	}


}
