namespace Legerity.WindowsDriver.Automation;

using System.Collections.Concurrent;

public sealed class SessionManager
{
    private readonly ConcurrentDictionary<string, DriverSession> _sessions = new();
    private CancellationTokenSource? _shutdownCts;

    public DriverSession CreateSession(Dictionary<string, object> capabilities)
    {
        // Cancel any pending shutdown since a new session is being created
        _shutdownCts?.Cancel();
        _shutdownCts = null;

        var id = Guid.NewGuid().ToString();
        var session = new DriverSession(id, capabilities);
        _sessions[id] = session;
        return session;
    }

    public DriverSession GetSession(string sessionId)
    {
        if (!_sessions.TryGetValue(sessionId, out var session))
        {
            throw new Exceptions.WebDriverException(
                Exceptions.WebDriverErrors.InvalidSessionId,
                $"No active session with ID: {sessionId}",
                404);
        }

        return session;
    }

    public void DeleteSession(string sessionId)
    {
        if (_sessions.TryRemove(sessionId, out var session))
        {
            session.Dispose();
        }
    }

    public bool HasActiveSessions => !_sessions.IsEmpty;

    /// <summary>
    /// Schedules a shutdown after a grace period, cancellable if a new session is created.
    /// </summary>
    public void ScheduleShutdown(IHostApplicationLifetime lifetime, TimeSpan gracePeriod)
    {
        _shutdownCts?.Cancel();
        _shutdownCts = new CancellationTokenSource();
        var token = _shutdownCts.Token;

        _ = Task.Run(async () =>
        {
            try
            {
                await Task.Delay(gracePeriod, token);
                if (!HasActiveSessions)
                {
                    lifetime.StopApplication();
                }
            }
            catch (TaskCanceledException)
            {
                // New session was created, shutdown cancelled
            }
        });
    }
}
