using System;

namespace InterfacesExtensibility
{
	public class DbMigration
	{
		//use OCP - SOLID

		private readonly ILogger _logger;

		public DbMigration(ILogger logger)
		{
			this._logger = logger;
		}

		public void Migrate()
		{
			//Console.WriteLine("Migrationg started at {0}", DateTime.Now);
			_logger.LogInfo("Migrationg started at {0}" + DateTime.Now);

			//Details of migrating the database

			//Console.WriteLine("Migrationg finished at {0}", DateTime.Now);
			_logger.LogInfo("Migrationg finished at {0}" + DateTime.Now);
		}
	}
}
