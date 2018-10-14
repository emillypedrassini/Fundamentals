using System;

namespace TestNinja.Mocking.Interface
{
	public interface IStatementGenerator
	{
		string SaveStatement(int housekeeperOid, string housekeeperName, DateTime statementDate);
	}
}
