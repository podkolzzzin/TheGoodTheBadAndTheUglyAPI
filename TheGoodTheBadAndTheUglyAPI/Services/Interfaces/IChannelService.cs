using TheGoodTheBadAndTheUglyAPI.Clients.Interfaces;
using TheGoodTheBadAndTheUglyAPI.Models;

namespace TheGoodTheBadAndTheUglyAPI.Services.Interfaces;

public interface IChannelService
{
  Task<IEnumerable<Playlist>> GetPlaylistsAsync(IYouTubeClient youTubeClient, ILogger log, CancellationToken cancellationToken);
  Task<VideoInfo> GetVideoAsync(string id, CancellationToken token);
}