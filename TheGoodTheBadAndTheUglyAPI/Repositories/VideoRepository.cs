using Microsoft.EntityFrameworkCore;
using TheGoodTheBadAndTheUglyAPI.Models;
using TheGoodTheBadAndTheUglyAPI.Repositories.Data;
using TheGoodTheBadAndTheUglyAPI.Repositories.Interfaces;

namespace TheGoodTheBadAndTheUglyAPI.Repositories;

public class VideoRepository : IVideosRepository
{
  private readonly ApplicationDbContext _context;
  public VideoRepository(ApplicationDbContext context)
  {
    _context = context;

  }
  
  public async Task<Video[]> GetVideosAsync(CancellationToken cancellationToken)
  {
    return (await _context.Videos.ToArrayAsync(cancellationToken))
      .Select(x => new Video(x.Id.ToString(), x.Title, Environment.GetEnvironmentVariable("site_url") + x.PreviewUrl))
      .ToArray();
  }
  
  public async Task<VideoInfo> GetVideoAsync(string id, CancellationToken token)
  {
    var data = await _context.Videos.Where(x => x.Id.ToString() == id)
      .FirstOrDefaultAsync(token);
    return new VideoInfo(data.Id.ToString(), data.Title, data.PreviewUrl, data.Description, data.ChannelId, 
      data.Duration, data.ViewCount, data.LikeCount, data.DislikeCount, data.FavoriteCount, data.CommentCount);
  }
}