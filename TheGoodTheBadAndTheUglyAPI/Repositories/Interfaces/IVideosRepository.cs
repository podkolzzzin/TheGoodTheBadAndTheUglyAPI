using TheGoodTheBadAndTheUglyAPI.Models;

namespace TheGoodTheBadAndTheUglyAPI.Repositories.Interfaces;

public interface IVideosRepository
{
  Task<Video[]> GetVideosAsync(CancellationToken cancellationToken);
  Task<VideoInfo> GetVideoAsync(string id, CancellationToken token);
}