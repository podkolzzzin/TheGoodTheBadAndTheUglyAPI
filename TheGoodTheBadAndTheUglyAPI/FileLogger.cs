namespace TheGoodTheBadAndTheUglyAPI;

public class FileLogger : ILogger
{
  private class Disposable : IDisposable
  {
    public void Dispose()
    {
    }
  }
  public IDisposable? BeginScope<TState>(TState state) where TState : notnull
  {
    return new Disposable();
  }
  public bool IsEnabled(LogLevel logLevel) => true;
  public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
  {
    File.AppendAllText(formatter(state, exception), "log.txt");
  }
}