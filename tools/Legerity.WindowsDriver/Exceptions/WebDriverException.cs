namespace Legerity.WindowsDriver.Exceptions;

public class WebDriverException : Exception
{
    public string ErrorCode { get; }
    public int StatusCode { get; }

    public WebDriverException(string errorCode, string message, int statusCode = 500)
        : base(message)
    {
        ErrorCode = errorCode;
        StatusCode = statusCode;
    }
}

public static class WebDriverErrors
{
    public const string SessionNotCreated = "session not created";
    public const string InvalidSessionId = "invalid session id";
    public const string NoSuchElement = "no such element";
    public const string NoSuchWindow = "no such window";
    public const string StaleElementReference = "stale element reference";
    public const string ElementNotInteractable = "element not interactable";
    public const string InvalidArgument = "invalid argument";
    public const string InvalidSelector = "invalid selector";
    public const string UnknownCommand = "unknown command";
    public const string UnknownError = "unknown error";
    public const string Timeout = "timeout";
}
