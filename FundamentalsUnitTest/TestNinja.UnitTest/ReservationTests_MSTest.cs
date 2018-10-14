using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTest
{
	[TestClass]
	public class ReservationTests_MSTest
	{
		[TestMethod]
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
			Assert.IsTrue(result);
		}

		[TestMethod]
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

		[TestMethod]
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

		[TestMethod]
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
