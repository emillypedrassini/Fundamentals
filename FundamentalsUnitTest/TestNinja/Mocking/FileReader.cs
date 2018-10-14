using System.IO;
using TestNinja.Mocking.Interface;

namespace TestNinja.Mocking
{
	public class FileReader : IFileReader
	{
		public string Read(string path)
		{
			return File.ReadAllText(path);
		}
	}
}
