using Moq;
using NUnit.Framework;
using TestNinja.Mocking.Services;

namespace TestNinja.UnitTest.Mocking
{
	[TestFixture]
	public class OrderServiceTests
	{
		private OrderService _orderService;
		private Mock<IStorage> _mockStorage;

		[SetUp]
		public void SetUp()
		{
			_mockStorage = new Mock<IStorage>();

			_orderService = new OrderService(_mockStorage.Object);
		}


		[Test]
		public void PlaceOrder_WhenCalled_StoreTheOder()
		{
			//teste de interação entre dois objetos: utilizar o método Verify

			//Arrange
			//Mock<IStorage> mockStorage = new Mock<IStorage>();
			//OrderService orderService = new OrderService(mockStorage.Object);
			var order = new Order();

			//Act
			_orderService.PlaceOrder(order);

			//Assert
			_mockStorage.Verify(s => s.Store(order));

		}
	}
}
