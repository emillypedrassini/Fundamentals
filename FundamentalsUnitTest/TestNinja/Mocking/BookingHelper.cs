﻿using System.Linq;

namespace TestNinja.Mocking
{
	public static class BookingHelper
	{
		public static string OverlappingBookingsExist(Booking booking, IBookingRepository bookingRepository)
		{
			if (booking.Status == "Cancelled")
				return string.Empty;

			var bookings = bookingRepository.GetActiveBooking(booking.Id);

			var overlappingBooking =
				bookings.FirstOrDefault(
					b =>
					booking.ArrivalDate < b.DepartureDate &&
					b.ArrivalDate < booking.DepartureDate);
			//booking.ArrivalDate >= b.ArrivalDate
			//&& booking.ArrivalDate < b.DepartureDate
			//|| booking.DepartureDate > b.ArrivalDate
			//&& booking.DepartureDate <= b.DepartureDate);

			return overlappingBooking == null ? string.Empty : overlappingBooking.Reference;
		}
	}

}