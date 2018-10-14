using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTest
{
	[TestFixture]
	class CustomerControllerTests
	{
		[Test]
		public void GetCustomer_IdIsZero_ReturnNotFound()
		{
			CustomerController customerController = new CustomerController();

			var result = customerController.GetCustomer(0);

			//NotFound
			Assert.That(result, Is.TypeOf<NotFound>());

			//NotFound or one of its derivatives
			//Assert.That(result, Is.InstanceOf<NotFound>);
		}

		[Test]
		public void GetCustomer_IdIsNotZero_ReturnOk()
		{
			CustomerController customerController = new CustomerController();

			var result = customerController.GetCustomer(1);

			//Ok
			Assert.That(result, Is.TypeOf<Ok>());

			//Ok or onr of its derivatives
			//Assert.That(result, Is.InstanceOf<Ok>());
		}
	}
}
