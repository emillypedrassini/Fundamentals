using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesPolymorphism
{
	class Program
	{
		static void Main(string[] args)
		{
			var encoder = new VideoEncoder();

			encoder.RegisterNotificationChannel(new MailNotificationChannel());
			encoder.RegisterNotificationChannel(new SmsNotificationChannel());

			encoder.Encode(new Video());

			Console.ReadLine();
		}
	}

	public class VideoEncoder
	{
		//private readonly MailService _mailService;
		private readonly IList<INotificationChannel> _notificationChannels;

		public VideoEncoder()
		{
			//_mailService = new MailService();
			_notificationChannels = new List<INotificationChannel>();
		}

		public void Encode(Video video)
		{
			//video encoding logic
			// ...

			// _mailService.Send(new Mail());
			foreach (var channel in _notificationChannels)
			{
				channel.Send(new Message());
			}
		}

		public void RegisterNotificationChannel(INotificationChannel channel)
		{
			_notificationChannels.Add(channel);
		}
	}
}
