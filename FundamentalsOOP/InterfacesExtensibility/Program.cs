using System;

namespace InterfacesExtensibility
{
	class Program
	{
		static void Main(string[] args)
		{
			DbMigration dbMigrationConsole = new DbMigration(new ConsoleLogger());
			dbMigrationConsole.Migrate();

			DbMigration dbMigrationFile = new DbMigration(new FileLogger("C:\\log.txt"));
			dbMigrationFile.Migrate();


			Console.ReadKey();
		}
	}
}
