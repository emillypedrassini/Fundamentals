﻿using System.Net;
using TestNinja.Mocking.Interface;

namespace TestNinja.Mocking
{
	public class FileDownloader : IFileDownloader
	{
		public void DownloadFile(string url, string path)
		{
			var client = new WebClient();
			client.DownloadFile(url, path);
		}
	}
}

