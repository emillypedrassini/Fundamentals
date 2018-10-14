using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;
using TestNinja.Mocking.Interface;

namespace TestNinja.UnitTest.Mocking
{
	[TestFixture]
	public class ProductTests
	{
		[Test]
		public void GetPrice_GoldCustomer_Apply30PercentDiscony()
		{
			Product product = new Product { ListPrice = 100 };

			var result = product.GetPrice(new Customer { IsGold = true });

			Assert.That(result, Is.EqualTo(70));
		}

		[Test]
		public void GetPrice_GoldCustomer_Apply30PercentDiscony2()
		{
			Mock<ICustomer> mockCustomer = new Mock<ICustomer>();
			mockCustomer.Setup(c => c.IsGold).Returns(true);

			Product product = new Product { ListPrice = 100 };

			var result = product.GetPrice(mockCustomer.Object);

			Assert.That(result, Is.EqualTo(70));
		}
	}
}
