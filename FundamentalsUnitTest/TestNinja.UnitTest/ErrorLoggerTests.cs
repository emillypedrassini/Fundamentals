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
	class ErrorLoggerTests
	{

		[Test]
		public void Log_WhenCalled_SetTheLastErrorProperty()
		{
			//Arrange
			ErrorLogger errorLogger = new ErrorLogger();

			//Act
			errorLogger.Log("a");

			//Assert
			Assert.That(errorLogger.LastError, Is.EqualTo("a"));
		}

		[Test]
		[TestCase(null)]
		[TestCase("")]
		[TestCase(" ")]
		public void Log_WhenCalled_ArgumentNullException(string error)
		{
			//metodo de teste que gera exception

			ErrorLogger errorLogger = new ErrorLogger();

			//errorLogger.Log(error);

			//delegate
			Assert.That(() => errorLogger.Log(error), Throws.ArgumentNullException);
			//Assert.That(() => errorLogger.Log(error), Throws.Exception.TypeOf<DivideByZeroException>());
		}

		[Test]
		public void Log_ValidError_RaiseErrorLoggedError()
		{
			//metodo de teste de evento ErrorLogged - para garantir que o metodo Log gere o evento correto

			ErrorLogger errorLogger = new ErrorLogger();

			var id = Guid.Empty;
			errorLogger.ErrorLogged += (send, args) => { id = args; };

			errorLogger.Log("a");

			Assert.That(id, Is.Not.EqualTo(Guid.Empty));
		}
	}
}
