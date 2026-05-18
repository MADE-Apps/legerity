# Legerity Windows Driver

A W3C WebDriver compliant server for Windows desktop application UI testing, built as a modern replacement for WinAppDriver.

## Features

- **W3C WebDriver protocol** - Full compliance with the W3C WebDriver specification
- **Windows UI Automation** - Uses UIA3 via FlaUI for reliable element interaction
- **Session management** - Launch and manage Windows application sessions
- **Element finding** - Supports AutomationId, Name, ClassName, XPath, and TagName locator strategies
- **Element interaction** - Click, send keys, get text, get attributes, and more
- **.NET tool** - Install and run with `dotnet tool install`

## Installation

```bash
dotnet tool install --global Legerity.WindowsDriver
```

## Usage

```bash
legerity-windows-driver --port 4723
```

The server starts on `http://localhost:4723` by default and accepts standard W3C WebDriver requests.

## Supported Locator Strategies

| Strategy | UIA Property |
|----------|-------------|
| `accessibility id` | AutomationId |
| `name` | Name |
| `class name` | ClassName |
| `xpath` | XPath over UIA tree |
| `tag name` | LocalizedControlType |

## Supported Endpoints

### Session
- `POST /session` - Create session (launch application)
- `DELETE /session/{id}` - Quit session

### Element Finding
- `POST /session/{id}/element` - Find element
- `POST /session/{id}/elements` - Find elements
- `POST /session/{id}/element/{eid}/element` - Find child element
- `POST /session/{id}/element/{eid}/elements` - Find child elements

### Element Interaction
- `POST /session/{id}/element/{eid}/click` - Click element
- `POST /session/{id}/element/{eid}/value` - Send keys to element
- `POST /session/{id}/element/{eid}/clear` - Clear element
- `GET /session/{id}/element/{eid}/text` - Get element text
- `GET /session/{id}/element/{eid}/name` - Get element tag name
- `GET /session/{id}/element/{eid}/attribute/{name}` - Get element attribute
- `GET /session/{id}/element/{eid}/property/{name}` - Get element property
- `GET /session/{id}/element/{eid}/displayed` - Is element displayed
- `GET /session/{id}/element/{eid}/enabled` - Is element enabled
- `GET /session/{id}/element/{eid}/selected` - Is element selected
- `GET /session/{id}/element/{eid}/rect` - Get element rect

### Window
- `GET /session/{id}/window` - Get current window handle
- `GET /session/{id}/window/handles` - Get all window handles
- `POST /session/{id}/window` - Switch to window
- `POST /session/{id}/window/maximize` - Maximize window
- `GET /session/{id}/window/rect` - Get window rect
- `DELETE /session/{id}/window` - Close window

### Other
- `GET /session/{id}/source` - Get page source (UIA tree as XML)
- `POST /session/{id}/timeouts` - Set timeouts
- `GET /session/{id}/screenshot` - Take screenshot
- `GET /session/{id}/element/{eid}/screenshot` - Take element screenshot
- `GET /status` - Server status
