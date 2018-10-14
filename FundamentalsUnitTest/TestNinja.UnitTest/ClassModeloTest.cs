using Moq;
using NUnit.Framework;
using TestNinja.Mocking.Interface;

namespace TestNinja.UnitTest
{
	[TestFixture]
	class ClassModeloTest
	{

		[Test]
		public void MethodName_Scenario_ExpectedBehaviour() {
			//Para realizar o mock de objetos:
			//estamos dizendo a biblioteco do Moq que queremos um objeto que implemente a interface IFileReader
			var fileReaderMock = new Mock<IFileReader>();

			//exemplo completo na classe VideoServiceTests()
		}
	}
}
