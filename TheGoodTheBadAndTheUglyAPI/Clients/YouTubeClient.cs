using TheGoodTheBadAndTheUglyAPI.Clients.Interfaces;
using TheGoodTheBadAndTheUglyAPI.Models;

namespace TheGoodTheBadAndTheUglyAPI.Clients;

public class YouTubeClient : IYouTubeClient
{

  public Task<IEnumerable<Video>> GetVideosAsync(CancellationToken cancellationToken)
  {
    // HttpClient...
    throw new NotImplementedException();
  }
}