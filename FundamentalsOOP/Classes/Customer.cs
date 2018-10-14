using System.Collections.Generic;

namespace Classes
{
	public class Customer
	{
		// Field
		public int Id;
		public string Name;
		public List<Order> Orders;

		//constructors
		public Customer()
		{
			Orders = new List<Order>();
		}

		public Customer(int id)
			: this()
		{
			this.Id = id;
		}

		public Customer(int id, string name)
			:this(id)
		{
			this.Name = name;
		}

		// Method
		public void Promote()
		{
		}

	}
}
