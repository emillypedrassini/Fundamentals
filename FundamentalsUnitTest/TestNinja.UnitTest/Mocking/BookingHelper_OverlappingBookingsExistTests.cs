using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TestNinja.Mocking;

namespace TestNinja.UnitTest.Mocking
{
	[TestFixture]
	public class BookingHelper_OverlappingBookingsExistTests
	{
		private Mock<IBookingRepository> _mockBookingRepository;
		private Booking _existingBooking;

		[SetUp]
		public void SetUp()
		{
			_mockBookingRepository = new Mock<IBookingRepository>();

			_existingBooking = new Booking
			{
				Id = 2,
				ArrivalDate = ArriveOn(2018, 1, 15),
				DepartureDate = DepartOn(2018, 1, 20),
				Reference = "a"
			};

			_mockBookingRepository.Setup(r => r.GetActiveBooking(1)).Returns(new List<Booking>
			{
				_existingBooking
			}.AsQueryable());
		}

		[Test]
		public void BookingStartsAndFinishesBeforeAnExistingBooking_ReturnEmptyString()
		{
			var result = BookingHelper.OverlappingBookingsExist(new Booking
			{
				Id = 1,
				ArrivalDate = Before(_existingBooking.ArrivalDate, days: 2),
				DepartureDate = Before(_existingBooking.ArrivalDate),
				Reference = "a"
			}, _mockBookingRepository.Object);

			Assert.That(result, Is.Empty);
		}

		[Test]
		public void BookingStartsBeforeAndFinishesInTheMiddleOfAnExistingBooking_ReturnExistingBookingsReference()
		{
			var result = BookingHelper.OverlappingBookingsExist(new Booking
			{
				Id = 1,
				ArrivalDate = Before(_existingBooking.ArrivalDate),
				DepartureDate = After(_existingBooking.ArrivalDate)
			}, _mockBookingRepository.Object);

			Assert.That(result, Is.EqualTo(_existingBooking.Reference));
		}

		[Test]
		public void BookingStartsBeforeAndFinishesAfterAnExistingBooking_ReturnExistingBookingsReference()
		{
			var result = BookingHelper.OverlappingBookingsExist(new Booking
			{
				Id = 1,
				ArrivalDate = Before(_existingBooking.ArrivalDate),
				DepartureDate = After(_existingBooking.DepartureDate)
			}, _mockBookingRepository.Object);

			Assert.That(result, Is.EqualTo(_existingBooking.Reference));
		}

		[Test]
		public void BookingStartsAndFinishesInTheMiddleOfAnExistingBooking_ReturnExistingBookingsReference()
		{
			var result = BookingHelper.OverlappingBookingsExist(new Booking
			{
				Id = 1,
				ArrivalDate = After(_existingBooking.ArrivalDate),
				DepartureDate = Before(_existingBooking.DepartureDate)
			}, _mockBookingRepository.Object);

			Assert.That(result, Is.EqualTo(_existingBooking.Reference));
		}

		[Test]
		public void BookingStartsInTheMiddleOfAnExistingBookingButFinishesAfter_ReturnExistingBookingsReference()
		{
			var result = BookingHelper.OverlappingBookingsExist(new Booking
			{
				Id = 1,
				ArrivalDate = After(_existingBooking.ArrivalDate),
				DepartureDate = After(_existingBooking.DepartureDate)
			}, _mockBookingRepository.Object);

			Assert.That(result, Is.EqualTo(_existingBooking.Reference));
		}

		[Test]
		public void BookingStartsAndFinishesAfterAnExistingBooking_ReturnEmptyString()
		{
			var result = BookingHelper.OverlappingBookingsExist(new Booking
			{
				Id = 1,
				ArrivalDate = After(_existingBooking.DepartureDate),
				DepartureDate = After(_existingBooking.DepartureDate, days: 2)
			}, _mockBookingRepository.Object);

			Assert.That(result, Is.Empty);
		}

		[Test]
		public void BookingsOverlapButBookingIsCancelled_ReturnEmptyString()
		{
			var result = BookingHelper.OverlappingBookingsExist(new Booking
			{
				Id = 1,
				ArrivalDate = After(_existingBooking.ArrivalDate),
				DepartureDate = After(_existingBooking.DepartureDate),
				Status = "Cancelled"
			}, _mockBookingRepository.Object);

			Assert.That(result, Is.Empty);
		}

		private DateTime Before(DateTime dateTime, int days = 1)
		{
			return dateTime.AddDays(-days);
		}

		private DateTime After(DateTime dateTime, int days = 1)
		{
			return dateTime.AddDays(days);
		}

		private DateTime ArriveOn(int year, int month, int day)
		{
			return new DateTime(year, month, day, 14, 0, 0);
		}

		private DateTime DepartOn(int year, int month, int day)
		{
			return new DateTime(year, month, day, 10, 0, 0);
		}

	}

	/*
	 * verifica se a reserva esta cancelada
	 *		se estiver cancelada retorna uma string vazia
	 *		
	 * obter todas as reservas existentes que nao foram canceladas excluindo a reserva que é passada
	 * verifica se a reserva passada se sobrepoe a qualquer uma das reservas existentes
	 * se não houve sobreposição - retorna uma string vazia
	 * se houve sobreposicao - retorna a referencia da primeira reserva que sobrepoe a reserva passada
	 * 
	 * CASOS DE TESTE de uma reserva existente
	 * nova resevra começa e termina antes de uma reserva existente - retorna string vazia - não ha sobreposicao
	 * 
	 */
}
