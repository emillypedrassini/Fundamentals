using System;

namespace InterfacesPolymorphism
{
	public class MailNotificationChannel : INotificationChannel
	{
		public void Send(Message message)
		{
			Console.WriteLine("Sending main ..." + message);
		}
	}
}
