using System.Linq;

namespace TestNinja.Mocking
{
	public interface IUnitOfWorkRepository
	{
		IQueryable<T> Query<T>();
	}
}