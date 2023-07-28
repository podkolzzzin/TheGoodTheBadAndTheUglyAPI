namespace TheGoodTheBadAndTheUglyAPI.Models;

public record Video(string Id, string Title, string ThumbnailUrl);

public record Playlist(string Id, IEnumerable<Video> Videos);

public record VideoInfo(
  string Id, 
  string Title, 
  string Description, 
  string ThumbnailUrl,
  string ChannelId,
  TimeSpan Duration,
  int ViewCount, 
  int LikeCount, 
  int DislikeCount,
  int FavoriteCount, 
  int CommentCount);