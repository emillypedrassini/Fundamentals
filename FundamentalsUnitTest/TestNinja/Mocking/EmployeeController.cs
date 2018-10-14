﻿using System.Data.Entity;
using TestNinja.Mocking.Repositories;

namespace TestNinja.Mocking
{
	public class EmployeeController
	{
		private EmployeeContext _db;
		private readonly IEmployeeStorageRepository _employeeStorageRepository;


		public EmployeeController(IEmployeeStorageRepository employeeStorageRepository)
		{
			_employeeStorageRepository = employeeStorageRepository;
		}

		public ActionResult DeleteEmployee(int id)
		{
			_employeeStorageRepository.DeleteEmployee(id);
			return RedirectToAction("Employees");
		}

		private ActionResult RedirectToAction(string employees)
		{
			return new RedirectResult();
		}
	}

	public class ActionResult { }

	public class RedirectResult : ActionResult { }

	public class EmployeeContext
	{
		public DbSet<Employee> Employees { get; set; }

		public void SaveChanges()
		{
		}
	}

	public class Employee
	{
	}

}