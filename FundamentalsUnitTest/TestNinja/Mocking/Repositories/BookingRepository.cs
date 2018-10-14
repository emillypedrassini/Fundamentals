using System.Linq;

namespace TestNinja.Mocking.Repositories
{
	public class BookingRepository : IBookingRepository
	{
		public IQueryable<Booking> GetActiveBooking(int? excludedBookingId = null)
		{
			var unitOfWork = new UnitOfWorkRepository();

			var bookings =
				unitOfWork.Query<Booking>()
					.Where(
						b => b.Status != "Cancelled"); ;

			if (excludedBookingId.HasValue)
				bookings = bookings.Where(b => b.Id != excludedBookingId.Value);

			return bookings;

		}
	}
}
