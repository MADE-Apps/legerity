namespace Legerity.WindowsDriver.Endpoints;

using System.Text.Json;
using Legerity.WindowsDriver.Automation;
using Legerity.WindowsDriver.Exceptions;
using Legerity.WindowsDriver.Models;

public static class WebDriverEndpoints
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        PropertyNameCaseInsensitive = true,
    };

    public static void MapWebDriverRoutes(this WebApplication app, SessionManager sessionManager)
    {
        app.MapGet("/status", () => Results.Json(
            new WebDriverResponse
            {
                Value = new StatusResponse { Ready = true, Message = "Legerity Windows Driver is ready." }
            }));

        MapSessionEndpoints(app, sessionManager);
        MapElementEndpoints(app, sessionManager);
        MapWindowEndpoints(app, sessionManager);
        MapMiscEndpoints(app, sessionManager);
    }

    private static void MapSessionEndpoints(WebApplication app, SessionManager sessionManager)
    {
        app.MapPost("/session", async (HttpContext context) =>
        {
            var body = await ReadBody<NewSessionRequest>(context);
            var capabilities = MergeCapabilities(body);

            var session = sessionManager.CreateSession(capabilities);

            try
            {
                var app2 = GetCapabilityString(capabilities, "app")
                    ?? GetCapabilityString(capabilities, "appium:app")
                    ?? string.Empty;
                var appArguments = GetCapabilityString(capabilities, "appArguments")
                    ?? GetCapabilityString(capabilities, "appium:appArguments");
                var appTopLevelWindow = GetCapabilityString(capabilities, "appTopLevelWindow")
                    ?? GetCapabilityString(capabilities, "appium:appTopLevelWindow");
                var implicitWait = GetCapabilityInt(capabilities, "ms:waitForAppLaunch")
                    ?? GetCapabilityInt(capabilities, "appium:ms:waitForAppLaunch");

                if (implicitWait.HasValue)
                {
                    session.ImplicitWait = TimeSpan.FromMilliseconds(implicitWait.Value);
                }

                if (!string.IsNullOrEmpty(appTopLevelWindow))
                {
                    var handle = Convert.ToInt32(appTopLevelWindow, 16);
                    session.AttachToApp(handle);
                }
                else
                {
                    session.LaunchApp(app2, appArguments);
                }

                var response = new NewSessionResponse
                {
                    SessionId = session.Id,
                    Capabilities = session.Capabilities
                };

                return Results.Json(new WebDriverResponse { Value = response });
            }
            catch
            {
                sessionManager.DeleteSession(session.Id);
                throw;
            }
        });

        app.MapDelete("/session/{sessionId}", (string sessionId) =>
        {
            sessionManager.GetSession(sessionId); // Validates session exists
            sessionManager.DeleteSession(sessionId);
            return Results.Json(new WebDriverResponse { Value = null });
        });
    }

    private static void MapElementEndpoints(WebApplication app, SessionManager sessionManager)
    {
        // Find element
        app.MapPost("/session/{sessionId}/element", async (string sessionId, HttpContext context) =>
        {
            var session = sessionManager.GetSession(sessionId);
            var req = await ReadBody<FindElementRequest>(context);
            var element = session.FindElement(req.Using, req.Value);
            var elementId = session.RegisterElement(element);
            return Results.Json(new WebDriverResponse { Value = new ElementResponse { ElementId = elementId } });
        });

        // Find elements
        app.MapPost("/session/{sessionId}/elements", async (string sessionId, HttpContext context) =>
        {
            var session = sessionManager.GetSession(sessionId);
            var req = await ReadBody<FindElementRequest>(context);
            var elements = session.FindElements(req.Using, req.Value);
            var responses = elements.Select(e => new ElementResponse { ElementId = session.RegisterElement(e) }).ToArray();
            return Results.Json(new WebDriverResponse { Value = responses });
        });

        // Find element from element
        app.MapPost("/session/{sessionId}/element/{elementId}/element", async (string sessionId, string elementId, HttpContext context) =>
        {
            var session = sessionManager.GetSession(sessionId);
            var parent = session.GetElement(elementId);
            var req = await ReadBody<FindElementRequest>(context);
            var element = session.FindElement(req.Using, req.Value, parent);
            var newId = session.RegisterElement(element);
            return Results.Json(new WebDriverResponse { Value = new ElementResponse { ElementId = newId } });
        });

        // Find elements from element
        app.MapPost("/session/{sessionId}/element/{elementId}/elements", async (string sessionId, string elementId, HttpContext context) =>
        {
            var session = sessionManager.GetSession(sessionId);
            var parent = session.GetElement(elementId);
            var req = await ReadBody<FindElementRequest>(context);
            var elements = session.FindElements(req.Using, req.Value, parent);
            var responses = elements.Select(e => new ElementResponse { ElementId = session.RegisterElement(e) }).ToArray();
            return Results.Json(new WebDriverResponse { Value = responses });
        });

        // Click
        app.MapPost("/session/{sessionId}/element/{elementId}/click", (string sessionId, string elementId) =>
        {
            var session = sessionManager.GetSession(sessionId);
            var element = session.GetElement(elementId);
            ElementInteraction.Click(element);
            return Results.Json(new WebDriverResponse { Value = null });
        });

        // Send keys
        app.MapPost("/session/{sessionId}/element/{elementId}/value", async (string sessionId, string elementId, HttpContext context) =>
        {
            var session = sessionManager.GetSession(sessionId);
            var element = session.GetElement(elementId);
            var req = await ReadBody<SendKeysRequest>(context);
            var text = req.Text ?? (req.Value != null ? string.Join("", req.Value) : string.Empty);
            ElementInteraction.SendKeys(element, text);
            return Results.Json(new WebDriverResponse { Value = null });
        });

        // Clear
        app.MapPost("/session/{sessionId}/element/{elementId}/clear", (string sessionId, string elementId) =>
        {
            var session = sessionManager.GetSession(sessionId);
            var element = session.GetElement(elementId);
            ElementInteraction.Clear(element);
            return Results.Json(new WebDriverResponse { Value = null });
        });

        // Get text
        app.MapGet("/session/{sessionId}/element/{elementId}/text", (string sessionId, string elementId) =>
        {
            var session = sessionManager.GetSession(sessionId);
            var element = session.GetElement(elementId);
            var text = ElementInteraction.GetText(element);
            return Results.Json(new WebDriverResponse { Value = text });
        });

        // Get tag name
        app.MapGet("/session/{sessionId}/element/{elementId}/name", (string sessionId, string elementId) =>
        {
            var session = sessionManager.GetSession(sessionId);
            var element = session.GetElement(elementId);
            var name = ElementInteraction.GetTagName(element);
            return Results.Json(new WebDriverResponse { Value = name });
        });

        // Get attribute
        app.MapGet("/session/{sessionId}/element/{elementId}/attribute/{attributeName}", (string sessionId, string elementId, string attributeName) =>
        {
            var session = sessionManager.GetSession(sessionId);
            var element = session.GetElement(elementId);
            var value = ElementInteraction.GetAttribute(element, attributeName);
            return Results.Json(new WebDriverResponse { Value = value });
        });

        // Get property
        app.MapGet("/session/{sessionId}/element/{elementId}/property/{propertyName}", (string sessionId, string elementId, string propertyName) =>
        {
            var session = sessionManager.GetSession(sessionId);
            var element = session.GetElement(elementId);
            var value = ElementInteraction.GetProperty(element, propertyName);
            return Results.Json(new WebDriverResponse { Value = value });
        });

        // Is displayed
        app.MapGet("/session/{sessionId}/element/{elementId}/displayed", (string sessionId, string elementId) =>
        {
            var session = sessionManager.GetSession(sessionId);
            var element = session.GetElement(elementId);
            return Results.Json(new WebDriverResponse { Value = ElementInteraction.IsDisplayed(element) });
        });

        // Is enabled
        app.MapGet("/session/{sessionId}/element/{elementId}/enabled", (string sessionId, string elementId) =>
        {
            var session = sessionManager.GetSession(sessionId);
            var element = session.GetElement(elementId);
            return Results.Json(new WebDriverResponse { Value = ElementInteraction.IsEnabled(element) });
        });

        // Is selected
        app.MapGet("/session/{sessionId}/element/{elementId}/selected", (string sessionId, string elementId) =>
        {
            var session = sessionManager.GetSession(sessionId);
            var element = session.GetElement(elementId);
            return Results.Json(new WebDriverResponse { Value = ElementInteraction.IsSelected(element) });
        });

        // Get rect
        app.MapGet("/session/{sessionId}/element/{elementId}/rect", (string sessionId, string elementId) =>
        {
            var session = sessionManager.GetSession(sessionId);
            var element = session.GetElement(elementId);
            return Results.Json(new WebDriverResponse { Value = ElementInteraction.GetRect(element) });
        });

        // Element screenshot
        app.MapGet("/session/{sessionId}/element/{elementId}/screenshot", (string sessionId, string elementId) =>
        {
            var session = sessionManager.GetSession(sessionId);
            var element = session.GetElement(elementId);
            var bytes = session.TakeElementScreenshot(element);
            return Results.Json(new WebDriverResponse { Value = Convert.ToBase64String(bytes) });
        });
    }

    private static void MapWindowEndpoints(WebApplication app, SessionManager sessionManager)
    {
        // Get window handle
        app.MapGet("/session/{sessionId}/window", (string sessionId) =>
        {
            var session = sessionManager.GetSession(sessionId);
            return Results.Json(new WebDriverResponse { Value = session.GetWindowHandle() });
        });

        // Get window handles
        app.MapGet("/session/{sessionId}/window/handles", (string sessionId) =>
        {
            var session = sessionManager.GetSession(sessionId);
            return Results.Json(new WebDriverResponse { Value = session.GetWindowHandles() });
        });

        // Switch to window
        app.MapPost("/session/{sessionId}/window", async (string sessionId, HttpContext context) =>
        {
            var session = sessionManager.GetSession(sessionId);
            var req = await ReadBody<SwitchWindowRequest>(context);
            session.SwitchToWindow(req.Handle);
            return Results.Json(new WebDriverResponse { Value = null });
        });

        // Maximize window
        app.MapPost("/session/{sessionId}/window/maximize", (string sessionId) =>
        {
            var session = sessionManager.GetSession(sessionId);
            session.MaximizeWindow();
            return Results.Json(new WebDriverResponse { Value = session.GetWindowRect() });
        });

        // Get window rect
        app.MapGet("/session/{sessionId}/window/rect", (string sessionId) =>
        {
            var session = sessionManager.GetSession(sessionId);
            return Results.Json(new WebDriverResponse { Value = session.GetWindowRect() });
        });

        // Close window
        app.MapDelete("/session/{sessionId}/window", (string sessionId) =>
        {
            var session = sessionManager.GetSession(sessionId);
            session.CloseWindow();
            return Results.Json(new WebDriverResponse { Value = session.GetWindowHandles() });
        });
    }

    private static void MapMiscEndpoints(WebApplication app, SessionManager sessionManager)
    {
        // Get page source
        app.MapGet("/session/{sessionId}/source", (string sessionId) =>
        {
            var session = sessionManager.GetSession(sessionId);
            return Results.Json(new WebDriverResponse { Value = session.GetPageSource() });
        });

        // Set timeouts
        app.MapPost("/session/{sessionId}/timeouts", async (string sessionId, HttpContext context) =>
        {
            var session = sessionManager.GetSession(sessionId);
            var req = await ReadBody<TimeoutsRequest>(context);
            if (req.Implicit.HasValue)
            {
                session.ImplicitWait = TimeSpan.FromMilliseconds(req.Implicit.Value);
            }

            return Results.Json(new WebDriverResponse { Value = null });
        });

        // Get timeouts
        app.MapGet("/session/{sessionId}/timeouts", (string sessionId) =>
        {
            var session = sessionManager.GetSession(sessionId);
            return Results.Json(new WebDriverResponse
            {
                Value = new TimeoutsRequest
                {
                    Implicit = (int)session.ImplicitWait.TotalMilliseconds,
                    PageLoad = 300000,
                    Script = 30000
                }
            });
        });

        // Screenshot
        app.MapGet("/session/{sessionId}/screenshot", (string sessionId) =>
        {
            var session = sessionManager.GetSession(sessionId);
            var bytes = session.TakeScreenshot();
            return Results.Json(new WebDriverResponse { Value = Convert.ToBase64String(bytes) });
        });
    }

    private static async Task<T> ReadBody<T>(HttpContext context)
    {
        try
        {
            var result = await context.Request.ReadFromJsonAsync<T>(JsonOptions);
            return result ?? throw new WebDriverException(WebDriverErrors.InvalidArgument, "Request body is required.", 400);
        }
        catch (JsonException ex)
        {
            throw new WebDriverException(WebDriverErrors.InvalidArgument, $"Invalid JSON: {ex.Message}", 400);
        }
    }

    private static Dictionary<string, object> MergeCapabilities(NewSessionRequest request)
    {
        var merged = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);

        if (request.Capabilities.AlwaysMatch != null)
        {
            foreach (var (key, value) in request.Capabilities.AlwaysMatch)
            {
                merged[key] = value;
            }
        }

        if (request.Capabilities.FirstMatch is { Count: > 0 })
        {
            foreach (var (key, value) in request.Capabilities.FirstMatch[0])
            {
                merged.TryAdd(key, value);
            }
        }

        return merged;
    }

    private static string? GetCapabilityString(Dictionary<string, object> caps, string key)
    {
        if (caps.TryGetValue(key, out var value))
        {
            if (value is JsonElement jsonElement)
            {
                return jsonElement.GetString();
            }

            return value?.ToString();
        }

        return null;
    }

    private static int? GetCapabilityInt(Dictionary<string, object> caps, string key)
    {
        if (caps.TryGetValue(key, out var value))
        {
            if (value is JsonElement jsonElement)
            {
                if (jsonElement.TryGetInt32(out var intValue))
                {
                    return intValue;
                }
            }

            if (value is int i)
            {
                return i;
            }

            if (int.TryParse(value?.ToString(), out var parsed))
            {
                return parsed;
            }
        }

        return null;
    }
}
