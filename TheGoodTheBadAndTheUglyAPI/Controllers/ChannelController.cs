using Microsoft.AspNetCore.Mvc;
using TheGoodTheBadAndTheUglyAPI.Clients.Interfaces;
using TheGoodTheBadAndTheUglyAPI.Models;
using TheGoodTheBadAndTheUglyAPI.Repositories.Interfaces;
using TheGoodTheBadAndTheUglyAPI.Services.Interfaces;

namespace TheGoodTheBadAndTheUglyAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ChannelController : ControllerBase
{
  private readonly IChannelService _service;
  private readonly IYouTubeClient _youTubeClient;
  private readonly IServiceScope _scope;
  private readonly ILogger<ChannelController> _logger;
  public ChannelController(IChannelService service, IYouTubeClient youTubeClient, IServiceScope scope, ILogger<ChannelController> logger)
  {
    _service = service;
    _youTubeClient = youTubeClient;
    _scope = scope;
    _logger = logger;
    _service = service;
    _youTubeClient = youTubeClient;
  }
  
  [HttpGet("/videos")]
  public async Task<IEnumerable<Video>> GetVideos(CancellationToken cancellationToken)
  {
    var repository = _scope.ServiceProvider.GetRequiredService<IVideosRepository>();
    var dbTask = repository.GetVideosAsync(cancellationToken);
    dbTask.ContinueWith(x => _logger.LogInformation("DB Task completed"));
    
    var youTubeTask = _youTubeClient.GetVideosAsync(cancellationToken);
    youTubeTask.ContinueWith(x => _logger.LogInformation("Client task Completed"));
    await Task.WhenAll(dbTask, youTubeTask);

    var result = new List<Video>();
    var hashSet = new HashSet<string>();
    foreach (var video in dbTask.Result)
    {
      if (hashSet.Add(video.Id))
      {
        result.Add(video);
      }
    }
    
    foreach (var video in youTubeTask.Result)
    {
      if (hashSet.Add(video.Id))
      {
        result.Add(video);
      }
    }

    return result;
  }

  [HttpGet("/playlists")]
  public async Task<IEnumerable<Playlist>> GetPlaylists(CancellationToken cancellationToken)
  {
    var log = new FileLogger();
    return await _service.GetPlaylistsAsync(_youTubeClient, log, cancellationToken);
  }

  [HttpGet("/video/{id}")]
  public async Task<VideoInfo> GetVideo(string id, CancellationToken token)
  {
    var task = _service.GetVideoAsync(id, token);
    var repository = _scope.ServiceProvider.GetRequiredService<IVideosRepository>();
    var dbTask = repository.GetVideoAsync(id, token);

    await Task.WhenAll(task, dbTask);

    return task.Result ?? dbTask.Result;
  }
}