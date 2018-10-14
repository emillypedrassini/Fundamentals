using System.Collections.Generic;
using TestNinja.Mocking.Services;

namespace TestNinja.Mocking.Repositories.Interface
{
	public interface IVideoRepository
	{
		IEnumerable<Video> GetUnprocessedVideos();
	}
}