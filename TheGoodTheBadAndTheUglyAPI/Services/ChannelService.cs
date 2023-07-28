using TheGoodTheBadAndTheUglyAPI.Clients.Interfaces;
using TheGoodTheBadAndTheUglyAPI.Models;
using TheGoodTheBadAndTheUglyAPI.Repositories.Interfaces;
using TheGoodTheBadAndTheUglyAPI.Services.Interfaces;

namespace TheGoodTheBadAndTheUglyAPI.Services;

public class ChannelService : IChannelService
{
  private readonly IVideosRepository _repository;
  private readonly IYouTubeClient _client;

  public ChannelService(IVideosRepository repository, IYouTubeClient client)
  {
    _repository = repository;
    _client = client;
  }
  
  public async Task<IEnumerable<Playlist>> GetPlaylistsAsync(IYouTubeClient youTubeClient, ILogger log, CancellationToken cancellationToken)
  {
    var videos = await _client.GetVideosAsync(cancellationToken);
    return new[] { new Playlist(Guid.NewGuid().ToString(), videos) };
  }
  public Task<VideoInfo> GetVideoAsync(string id, CancellationToken token)
  {
    // Do Smth with repository
    // Do Smth with client
    throw new NotImplementedException();
  }
}