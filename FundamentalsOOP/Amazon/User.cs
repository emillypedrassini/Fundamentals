using System;

namespace Amazon
{
	public class User
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public void Promote()
		{
			var calculator = new RateCalculator();
			var rating = calculator.Calculate(this);

			Console.WriteLine("Promote logic changed.");
		}

		private void Add()
		{
			Console.WriteLine("Add use");
		}

		protected void Delete(int id)
		{
			Console.WriteLine("User deleted");
		}

	}
}
