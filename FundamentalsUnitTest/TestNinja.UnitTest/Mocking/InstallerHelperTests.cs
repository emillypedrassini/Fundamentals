using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;
using TestNinja.Mocking.Interface;

namespace TestNinja.UnitTest.Mocking
{
	[TestFixture]
	public class InstallerHelperTests
	{
		private InstallerHelper _installerHelper;
		private Mock<IFileDownloader> _mockFileDownloader;

		[SetUp]
		public void SetUp()
		{
			_mockFileDownloader = new Mock<IFileDownloader>();
			_installerHelper = new InstallerHelper(_mockFileDownloader.Object);
		}

		[Test]
		public void DownloadInstaller_DownloadFails_ReturnFalse()
		{
			//Arrange
			_mockFileDownloader.Setup(fb =>
				fb.DownloadFile(It.IsAny<string>(), It.IsAny<string>()))
				.Throws<WebException>();

			//Act
			var result = _installerHelper.DownloadInstaller("customer", "installer");

			//Assert
			Assert.That(result, Is.False);
		}

		[Test]
		public void DownloadInstaller_DownloadSucess_ReturnTrue()
		{
			//Arrange
			//_mockFileDownloader.Setup(fd => fd.DownloadFile("http://example.com/customer/installer", "path"));

			//Act
			var result = _installerHelper.DownloadInstaller("customer", "installer");

			//Assert
			Assert.That(result, Is.True);

		}


	}
}
