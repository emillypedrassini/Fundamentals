namespace TestNinja.Mocking.Repositories
{
	public interface IEmployeeStorageRepository
	{
		void DeleteEmployee(int id);
	}

	public class EmployeeStorageRepository : IEmployeeStorageRepository
	{
		private EmployeeContext _db;

		public EmployeeStorageRepository()
		{
			_db = new EmployeeContext();
		}

		public void DeleteEmployee(int id)
		{
			var employee = _db.Employees.Find(id);

			if (employee == null)
				return;

			_db.Employees.Remove(employee);
			_db.SaveChanges();
		}
	}
}
