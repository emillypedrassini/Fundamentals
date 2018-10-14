using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using TestNinja.Mocking.Interface;
using TestNinja.Mocking.Repositories.Interface;
using TestNinja.Mocking.Services;

namespace TestNinja.UnitTest.Mocking
{
	[TestFixture]
	public class VideoServiceTests
	{
		private VideoService _videoService;
		private Mock<IFileReader> _mockFileReader;
		private Mock<IVideoRepository> _mockIVideoRepository;

		[SetUp]
		public void SetUp()
		{
			_mockFileReader = new Mock<IFileReader>();  //estamos dizendo a biblioteco do Moq que queremos um objeto que implemente a interface IFileReader
			_mockIVideoRepository = new Mock<IVideoRepository>();

			_videoService = new VideoService(_mockFileReader.Object, _mockIVideoRepository.Object);
		}

		[Test]
		public void ReadVideoTitle_EmptyFile_ReturnError()
		{
			/*estamos dizendo ao mock que:
			 * quando chamarmos o método Read() com um argumento ele deve retornar uma string vazia
			 * porem tem outras opções por ex: .Throws
			 * então aqui: o objeto mockado ira retornar uma string vazia quando chamar o metodo Read() com esse argumento Read("video.txt")
			 * documentação: https://github.com/Moq/moq4/wiki/Quickstart
			 */
			_mockFileReader.Setup(fr => fr.Read("video.txt")).Returns("");

			var result = _videoService.ReadVideoTitle();

			Assert.That(result, Does.Contain("error").IgnoreCase);
		}

		[Test]
		public void GetUnprocessedVideosAsCsv_AllVideosAreProcessed_ReturnAnEmptyString()
		{
			//Arrange
			_mockIVideoRepository.Setup(vr => vr.GetUnprocessedVideos()).Returns(new List<Video>());

			//Act
			var result = _videoService.GetUnprocessedVideosAsCsv();


			//Assert
			Assert.That(result, Is.EqualTo(""));
		}

		[Test]
		public void GetUnprocessedVideosAsCsv_AFewUnProcessedVideos_ReturnAStringWithIdOfUnprocessedVideos()
		{
			//Arrange
			_mockIVideoRepository.Setup(vr => vr.GetUnprocessedVideos()).Returns(new List<Video>
			{
				new Video { Id = 1, Title = "teste"},
				new Video { Id = 2, Title = "teste"},
				new Video { Id = 3, Title = "teste"}
			});

			//Act
			var result = _videoService.GetUnprocessedVideosAsCsv();


			//Assert
			Assert.That(result, Is.EqualTo("1,2,3"));
		}
	}
}
