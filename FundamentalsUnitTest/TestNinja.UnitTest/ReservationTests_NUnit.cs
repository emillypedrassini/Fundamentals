using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTest
{
	[TestFixture]
	class ReservationTests_NUnit
	{

		[Test]
		public void CanBeCancelledBy_UserIsAdmin_ReturnTrue()
		{
			// Arrange
			Reservation reservation = new Reservation();

			User user = new User
			{
				IsAdmin = true
			};

			// Act
			var result = reservation.CanBeCancelledBy(user);

			//Assert
			//Assert.IsTrue(result);
			Assert.That(result, Is.True);
			//Assert.That(result == true);
		}

		[Test]
		public void CanBeCancelledBy_SameUserCancellingTheReservation_ReturnTrue()
		{
			//Arrange
			User user = new User();
			Reservation reservation = new Reservation();

			// Act
			reservation.MadeBy = user;
			var result = reservation.CanBeCancelledBy(user);

			// Assert
			Assert.IsTrue(result);
		}

		[Test]
		public void CanBeCancelledBy_UserIsAdmin_ReturnFalse()
		{
			// Arrange
			Reservation reservation = new Reservation();

			User user = new User
			{
				IsAdmin = false
			};

			//Act
			var result = reservation.CanBeCancelledBy(user);

			//Assert
			Assert.IsFalse(result);
		}

		[Test]
		public void CanBeCancelledBy_AnotherUserCancellingReservation_ReturnFalse()
		{
			//Arrange
			User user = new User();
			Reservation reservation = new Reservation { MadeBy = user };

			//Act
			var result = reservation.CanBeCancelledBy(new User());

			//Assert
			Assert.IsFalse(result);
		}
	}
}
