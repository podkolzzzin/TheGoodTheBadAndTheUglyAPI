using TheGoodTheBadAndTheUglyAPI.Models;

namespace TheGoodTheBadAndTheUglyAPI.Clients.Interfaces;

public interface IYouTubeClient
{
  Task<IEnumerable<Video>> GetVideosAsync(CancellationToken cancellationToken);
}