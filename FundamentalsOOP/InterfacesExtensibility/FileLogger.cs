using System.IO;

namespace InterfacesExtensibility
{
	public class FileLogger : ILogger
	{
		private readonly string _path;

		public FileLogger(string path)
		{
			this._path = path;
		}

		public void LogError(string message)
		{
			Log(message, "ERROR");

		}

		public void LogInfo(string message)
		{
			Log(message, "INFO");
		}

		public void Log(string message, string messageType)
		{
			using (var streamWriter = new StreamWriter(_path, true))
			{
				streamWriter.WriteLine(messageType + ": " + message);
			}
		}
	}
}
