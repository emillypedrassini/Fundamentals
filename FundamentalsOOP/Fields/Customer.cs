using System.Collections.Generic;

namespace Fields
{
	public class Customer
	{
		public int Id;
		public string Name;
		public readonly List<Order> Orders = new List<Order>();

		//public Customer()
		//{
		//	Orders = new List<Order>();
		//}

		public Customer(int id)
		{
			this.Id = id;
		}

		public Customer(int id, string name)
			: this(id)
		{
			this.Name = name;
		}

		public void Promote()
		{
			// Orders = new List<Order>(); 
			// é necessário tornar a propriedade readonly apara ser inicializada em somente um lugar -> não é uma boa prática inicializar em mais de um lugar no código, pode gerar erro em tempo de compilação

			// ...
		}

	}
}
