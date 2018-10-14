using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;
using TestNinja.Mocking.Repositories;

namespace TestNinja.UnitTest.Mocking
{
	[TestFixture]
	public class EmployeeControllerTests
	{
		private EmployeeController _employeeController;
		private Mock<IEmployeeStorageRepository> _mockIEmployeeStorageRepository;

		[SetUp]
		public void SetUp()
		{
			_mockIEmployeeStorageRepository = new Mock<IEmployeeStorageRepository>();

			_employeeController = new EmployeeController(_mockIEmployeeStorageRepository.Object);
		}

		[Test]
		public void DeleteEmployee_WhenCalled_DeleteTheEmployeeFromDb()
		{
			_employeeController.DeleteEmployee(1);

			_mockIEmployeeStorageRepository.Verify(s => s.DeleteEmployee(1));
		}

	}
}
