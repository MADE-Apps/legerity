namespace Legerity.WindowsDriver.Automation;

using System.Collections.Concurrent;

public sealed class SessionManager
{
    private readonly ConcurrentDictionary<string, DriverSession> _sessions = new();

    public DriverSession CreateSession(Dictionary<string, object> capabilities)
    {
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
}
