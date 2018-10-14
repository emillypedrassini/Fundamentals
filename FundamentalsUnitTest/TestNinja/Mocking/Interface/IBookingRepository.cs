﻿using System.Linq;

namespace TestNinja.Mocking
{
	public interface IBookingRepository
	{
		IQueryable<Booking> GetActiveBooking(int? excludedBookingId = null);
	}
}