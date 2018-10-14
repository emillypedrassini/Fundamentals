using System.Collections.Generic;
using System.Linq;
using TestNinja.Mocking;

namespace TestNinja
{
	public class UnitOfWorkRepository : IUnitOfWorkRepository
	{
		public IQueryable<T> Query<T>()
		{
			return new List<T>().AsQueryable();
		}
	}
}
