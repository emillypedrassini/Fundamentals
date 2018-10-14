using System;

namespace AccessModifiers
{
	public class Customer
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public void Promote()
		{
			var rating = CalculateRating(excludeOrders: true);

			if (rating == 0)
				Console.WriteLine("Promote to Level 1");
			else
				Console.WriteLine("Promote to Level 2");
		}

		private int CalculateRating(bool excludeOrders)
		{
			if (excludeOrders)
				return 0;
			else
				return 1;
		}

		protected void Delete(int id)
		{
			Console.WriteLine("Customer deleted");
		}

	}
}
