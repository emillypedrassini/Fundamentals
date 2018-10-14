namespace Composition
{
	public class DbMigrator
	{
		private readonly Logger _logger;

		public DbMigrator(Logger logger)
		{
			this._logger = logger;
		}

		public void Migration()
		{
			_logger.Log("We are migration .....");
		}
	}

}
