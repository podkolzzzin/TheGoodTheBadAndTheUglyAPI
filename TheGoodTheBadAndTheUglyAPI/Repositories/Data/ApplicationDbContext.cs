using Microsoft.EntityFrameworkCore;

namespace TheGoodTheBadAndTheUglyAPI.Repositories.Data;

public class ApplicationDbContext : DbContext
{
  public DbSet<VideoEntity> Videos { get; set; }
}

public class VideoEntity
{
  public int Id { get; set; }
  public string Title { get; set; }
  public string PreviewUrl { get; set; }
  
  public string Description { get; set; }
  
  public string ChannelId { get; set; }
  
  public string ChannelTitle { get; set; }
  
  public DateTime PublishedAt { get; set; }
  
  public TimeSpan Duration { get; set; }
  
  public int ViewCount { get; set; }
  
  public int LikeCount { get; set; }
  
  public int DislikeCount { get; set; }
  
  public int FavoriteCount { get; set; }
  
  public int CommentCount { get; set; }
  
  public string Tags { get; set; }
  
  public string CategoryId { get; set; }
  
  public string LiveBroadcastContent { get; set; }
}