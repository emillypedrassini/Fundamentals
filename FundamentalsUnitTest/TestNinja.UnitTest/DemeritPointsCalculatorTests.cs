﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTest
{
	[TestFixture]
	class DemeritPointsCalculatorTests
	{
		private DemeritPointsCalculator _demeritPointsCalculator;

		[SetUp]
		public void SetUp()
		{
			_demeritPointsCalculator = new DemeritPointsCalculator();
		}


		[Test]
		[TestCase(-1)]
		[TestCase(301)]
		public void CalculateDemeritPoints_SpeedIsNegativeOrOver300_ThrowArgumentOutOfRangeException(int speed)
		{
			Assert.That(() => _demeritPointsCalculator.CalculateDemeritPoints(speed),
				Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
		}

		[Test]
		[TestCase(0, 0)]
		[TestCase(64, 0)]
		[TestCase(65, 0)]
		[TestCase(66, 0)]
		[TestCase(69, 0)]
		[TestCase(70, 1)]
		[TestCase(75, 2)]
		[TestCase(300, 47)]
		public void CalculateDemeritPoints_WhenCalled_ReturnDemeritPoints(int speed, int expectedResult)
		{
			var result = _demeritPointsCalculator.CalculateDemeritPoints(speed);

			Assert.That(result, Is.EqualTo(expectedResult));
		}

		//[Test]
		//[TestCase(0, 0)]
		//[TestCase(64, 0)]
		//[TestCase(65, 0)]
		//public void CalculateDemeritPoints_SpeedIsLessThanOrEqualToLimit_ReturnZero(int speed, int expectedResult)
		//{
		//	var result = _demeritPointsCalculator.CalculateDemeritPoints(speed);

		//	Assert.That(result, Is.EqualTo(expectedResult));
		//}

		//[Test]
		//[TestCase(66, 0)]
		//[TestCase(69, 0)]
		//public void CalculateDemeritPoints_SpeedIsLessThan5OverToLimit_ReturnZero(int speed, int expectedResult)
		//{
		//	var result = _demeritPointsCalculator.CalculateDemeritPoints(speed);

		//	Assert.That(result, Is.EqualTo(expectedResult));
		//}

		//[Test]
		//[TestCase(70, 1)]
		//[TestCase(75, 2)]
		//public void CalculateDemeritPoints_SpeedIsOverToLimit_ReturnDemeritPoints(int speed, int expectedResult)
		//{
		//	var result = _demeritPointsCalculator.CalculateDemeritPoints(speed);

		//	Assert.That(result, Is.EqualTo(expectedResult));
		//}


	}
}
