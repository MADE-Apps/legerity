namespace Legerity.WindowsDriver.Models;

using System.Text.Json.Serialization;

public class WebDriverResponse
{
    [JsonPropertyName("value")]
    public object? Value { get; set; }
}

public class WebDriverError
{
    [JsonPropertyName("error")]
    public string Error { get; set; } = string.Empty;

    [JsonPropertyName("message")]
    public string Message { get; set; } = string.Empty;

    [JsonPropertyName("stacktrace")]
    public string Stacktrace { get; set; } = string.Empty;
}

public class NewSessionRequest
{
    [JsonPropertyName("capabilities")]
    public CapabilitiesRequest Capabilities { get; set; } = new();
}

public class CapabilitiesRequest
{
    [JsonPropertyName("alwaysMatch")]
    public Dictionary<string, object>? AlwaysMatch { get; set; }

    [JsonPropertyName("firstMatch")]
    public List<Dictionary<string, object>>? FirstMatch { get; set; }
}

public class NewSessionResponse
{
    [JsonPropertyName("sessionId")]
    public string SessionId { get; set; } = string.Empty;

    [JsonPropertyName("capabilities")]
    public Dictionary<string, object> Capabilities { get; set; } = new();
}

public class FindElementRequest
{
    [JsonPropertyName("using")]
    public string Using { get; set; } = string.Empty;

    [JsonPropertyName("value")]
    public string Value { get; set; } = string.Empty;
}

public class ElementResponse
{
    [JsonPropertyName("element-6066-11e4-a52e-4f735466cecf")]
    public string ElementId { get; set; } = string.Empty;
}

public class SendKeysRequest
{
    [JsonPropertyName("text")]
    public string Text { get; set; } = string.Empty;

    [JsonPropertyName("value")]
    public string[]? Value { get; set; }
}

public class SwitchWindowRequest
{
    [JsonPropertyName("handle")]
    public string Handle { get; set; } = string.Empty;
}

public class TimeoutsRequest
{
    [JsonPropertyName("implicit")]
    public int? Implicit { get; set; }

    [JsonPropertyName("pageLoad")]
    public int? PageLoad { get; set; }

    [JsonPropertyName("script")]
    public int? Script { get; set; }
}

public class ElementRect
{
    [JsonPropertyName("x")]
    public int X { get; set; }

    [JsonPropertyName("y")]
    public int Y { get; set; }

    [JsonPropertyName("width")]
    public int Width { get; set; }

    [JsonPropertyName("height")]
    public int Height { get; set; }
}

public class StatusResponse
{
    [JsonPropertyName("ready")]
    public bool Ready { get; set; }

    [JsonPropertyName("message")]
    public string Message { get; set; } = string.Empty;
}
