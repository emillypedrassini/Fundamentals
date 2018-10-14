using System;

namespace InterfacesPolymorphism
{
	public class SmsNotificationChannel : INotificationChannel
	{
		public void Send(Message message)
		{
			Console.WriteLine("Sending SMS ..." + message);
		}
	}
}
