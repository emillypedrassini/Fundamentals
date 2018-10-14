using NUnit.Framework;
using System;
using System.Linq;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTest
{
	[TestFixture]
	public class MathTests
	{
		private Fundamentals.Math _math;

		/// <summary>
		///		Atributo SetUp:
		///		O atibuto SetUp SEMPRE executa o método decorrado por ele ANTES de executar cada método de teste 
		/// </summary>
		[SetUp]
		public void SetUp()
		{
			//SEMPRE sera criada uma nova isntancia para o objeto _math ANTES de executar cada método de teste
			_math = new Fundamentals.Math();
		}

		[Test]
		public void Add_WhenCalled_ReturnTheSumOfArguments()
		{
			//Arrange
			//Fundamentals.Math math = new Fundamentals.Math();

			//Act
			var result = _math.Add(1, 2);

			//Assert
			Assert.That(result, Is.EqualTo(3));
		}

		[Test]
		[Ignore("Porque foi criado o teste Parametrizado Max_WhenCalled_ReturnTheGreaterArgument que faz está validação no atributo TestCase")]
		public void Max_FirstArgumentIsGreater_ReturnTheFirstArgument()
		{
			//Fundamentals.Math math = new Fundamentals.Math();

			var result = _math.Max(2, 1);

			Assert.That(result, Is.EqualTo(2));
		}

		[Test]
		[Ignore("Porque foi criado o teste Parametrizado Max_WhenCalled_ReturnTheGreaterArgument que faz está validação no atributo TestCase")]
		public void Max_SecondArgumentIsGreater_ReturnSecondArgument()
		{
			//Fundamentals.Math math = new Fundamentals.Math();

			var result = _math.Max(1, 2);

			Assert.That(result, Is.EqualTo(2));
		}

		[Test]
		[Ignore("Porque foi criado o teste Parametrizado Max_WhenCalled_ReturnTheGreaterArgument que faz está validação no atributo TestCase")]
		public void Max_ArgumentsAreEqual_ReturnTheSameArgument()
		{
			//Fundamentals.Math math = new Fundamentals.Math();

			var result = _math.Max(1, 1);

			Assert.That(result, Is.EqualTo(1));
		}

		//TESTE PARAMETRIZADO -> tranformando os 3 metodos de Max em 1 só utilizando parametros
		[Test]
		[TestCase(2, 1, 2)]//atributo CASO DE TESTE -> possibilita fornecer diferentes argumentos para este metodo de teste
		[TestCase(1, 2, 2)]
		[TestCase(1, 1, 1)]
		public void Max_WhenCalled_ReturnTheGreaterArgument(int a, int b, int expectedResult)
		{
			var result = _math.Max(a, b);

			Assert.That(result, Is.EqualTo(expectedResult));
		}

		[Test]
		public void GetOddNumbers_LimitIsGreaterThanZero_ReturnOddNumbersUpToLimit()
		{
			var result = _math.GetOddNumbers(5);

			//Assert.That(result, Is.Not.Empty);

			//Assert.That(result.Count(), Is.EqualTo(3));

			//Assert.That(result, Does.Contain(1));
			//Assert.That(result, Does.Contain(3));
			//Assert.That(result, Does.Contain(5));

			Assert.That(result, Is.EquivalentTo(new[] { 1, 3, 5}));

			//Assert.That(result, Is.Ordered);
			//Assert.That(result, Is.Unique);

		}
	}
}