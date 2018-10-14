namespace TestNinja.Mocking.Interface
{
	public interface IEmailService
	{
		void EmailFile(string emailAddress, string emailBody, string filename, string subject);
	}
}
