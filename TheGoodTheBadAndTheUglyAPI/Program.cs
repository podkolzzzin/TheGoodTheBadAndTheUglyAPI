using TheGoodTheBadAndTheUglyAPI.Clients;
using TheGoodTheBadAndTheUglyAPI.Clients.Interfaces;
using TheGoodTheBadAndTheUglyAPI.Repositories;
using TheGoodTheBadAndTheUglyAPI.Repositories.Data;
using TheGoodTheBadAndTheUglyAPI.Repositories.Interfaces;
using TheGoodTheBadAndTheUglyAPI.Services;
using TheGoodTheBadAndTheUglyAPI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddScoped<IVideosRepository, VideoRepository>();
builder.Services.AddScoped<IChannelService, ChannelService>();
builder.Services.AddScoped<IYouTubeClient, YouTubeClient>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();