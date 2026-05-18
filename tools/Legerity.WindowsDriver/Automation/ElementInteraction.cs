namespace Legerity.WindowsDriver.Automation;

using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using Legerity.WindowsDriver.Exceptions;
using Legerity.WindowsDriver.Models;

public static class ElementInteraction
{
    public static void Click(AutomationElement element)
    {
        try
        {
            if (element.Patterns.Invoke.IsSupported)
            {
                element.Patterns.Invoke.Pattern.Invoke();
                return;
            }

            if (element.Patterns.Toggle.IsSupported)
            {
                element.Patterns.Toggle.Pattern.Toggle();
                return;
            }

            if (element.Patterns.SelectionItem.IsSupported)
            {
                element.Patterns.SelectionItem.Pattern.Select();
                return;
            }

            if (element.Patterns.ExpandCollapse.IsSupported)
            {
                var state = element.Patterns.ExpandCollapse.Pattern.ExpandCollapseState.Value;
                if (state == ExpandCollapseState.Collapsed)
                {
                    element.Patterns.ExpandCollapse.Pattern.Expand();
                }
                else
                {
                    element.Patterns.ExpandCollapse.Pattern.Collapse();
                }

                return;
            }

            // Fallback to mouse click
            element.Click();
        }
        catch (WebDriverException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new WebDriverException(WebDriverErrors.ElementNotInteractable,
                $"Failed to click element: {ex.Message}", 400);
        }
    }

    public static void SendKeys(AutomationElement element, string text)
    {
        try
        {
            if (element.Patterns.Value.IsSupported)
            {
                element.Patterns.Value.Pattern.SetValue(text);
                return;
            }

            // Fallback to keyboard input
            element.Focus();
            FlaUI.Core.Input.Keyboard.Type(text);
        }
        catch (WebDriverException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new WebDriverException(WebDriverErrors.ElementNotInteractable,
                $"Failed to send keys to element: {ex.Message}", 400);
        }
    }

    public static void Clear(AutomationElement element)
    {
        try
        {
            if (element.Patterns.Value.IsSupported)
            {
                element.Patterns.Value.Pattern.SetValue(string.Empty);
                return;
            }

            // Fallback: select all and delete
            element.Focus();
            FlaUI.Core.Input.Keyboard.TypeSimultaneously(
                FlaUI.Core.WindowsAPI.VirtualKeyShort.CONTROL,
                FlaUI.Core.WindowsAPI.VirtualKeyShort.KEY_A);
            FlaUI.Core.Input.Keyboard.Type(FlaUI.Core.WindowsAPI.VirtualKeyShort.DELETE);
        }
        catch (WebDriverException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new WebDriverException(WebDriverErrors.ElementNotInteractable,
                $"Failed to clear element: {ex.Message}", 400);
        }
    }

    public static string GetText(AutomationElement element)
    {
        // Try Value pattern first (text boxes)
        if (element.Patterns.Value.IsSupported)
        {
            return element.Patterns.Value.Pattern.Value.Value ?? string.Empty;
        }

        // Then try Name property
        return element.Properties.Name.ValueOrDefault ?? string.Empty;
    }

    public static string GetTagName(AutomationElement element)
    {
        return element.Properties.LocalizedControlType.ValueOrDefault ?? "Unknown";
    }

    public static string? GetAttribute(AutomationElement element, string attributeName)
    {
        return attributeName.ToLowerInvariant() switch
        {
            "automationid" or "accessibilityid" => element.Properties.AutomationId.ValueOrDefault,
            "name" => element.Properties.Name.ValueOrDefault,
            "classname" or "class" => element.Properties.ClassName.ValueOrDefault,
            "controltype" => element.Properties.ControlType.ValueOrDefault.ToString(),
            "localizedcontroltype" => element.Properties.LocalizedControlType.ValueOrDefault,
            "isenabled" or "enabled" => element.Properties.IsEnabled.ValueOrDefault.ToString().ToLowerInvariant(),
            "isoffscreen" => element.Properties.IsOffscreen.ValueOrDefault.ToString().ToLowerInvariant(),
            "processid" => element.Properties.ProcessId.ValueOrDefault.ToString(),
            "runtimeid" => string.Join(".", element.Properties.RuntimeId.ValueOrDefault ?? []),
            "helptext" => element.Properties.HelpText.ValueOrDefault,
            "frameworkid" => element.Properties.FrameworkId.ValueOrDefault,
            "ispassword" => element.Properties.IsPassword.ValueOrDefault.ToString().ToLowerInvariant(),
            "value" or "value.value" => element.Patterns.Value.IsSupported
                ? element.Patterns.Value.Pattern.Value.ValueOrDefault
                : null,
            "isreadonly" or "value.isreadonly" => element.Patterns.Value.IsSupported
                ? element.Patterns.Value.Pattern.IsReadOnly.ValueOrDefault.ToString().ToLowerInvariant()
                : null,
            "toggle.togglestate" => element.Patterns.Toggle.IsSupported
                ? ((int)element.Patterns.Toggle.Pattern.ToggleState.Value).ToString()
                : null,
            "selection.isselectionrequired" => element.Patterns.Selection.IsSupported
                ? element.Patterns.Selection.Pattern.IsSelectionRequired.ValueOrDefault.ToString().ToLowerInvariant()
                : null,
            "selection.selection" => element.Patterns.Selection.IsSupported
                ? string.Join(", ", element.Patterns.Selection.Pattern.Selection.ValueOrDefault
                    ?.Select(e => e.Properties.Name.ValueOrDefault ?? string.Empty) ?? [])
                : null,
            "selectionitem.isselected" or "isselected" => element.Patterns.SelectionItem.IsSupported
                ? element.Patterns.SelectionItem.Pattern.IsSelected.ValueOrDefault.ToString().ToLowerInvariant()
                : null,
            "expandcollapse.expandcollapsestate" => element.Patterns.ExpandCollapse.IsSupported
                ? ((int)element.Patterns.ExpandCollapse.Pattern.ExpandCollapseState.Value).ToString()
                : null,
            "rangevalue.value" => element.Patterns.RangeValue.IsSupported
                ? element.Patterns.RangeValue.Pattern.Value.ValueOrDefault.ToString()
                : null,
            "rangevalue.minimum" => element.Patterns.RangeValue.IsSupported
                ? element.Patterns.RangeValue.Pattern.Minimum.ValueOrDefault.ToString()
                : null,
            "rangevalue.maximum" => element.Patterns.RangeValue.IsSupported
                ? element.Patterns.RangeValue.Pattern.Maximum.ValueOrDefault.ToString()
                : null,
            "scroll.horizontalscrollpercent" => element.Patterns.Scroll.IsSupported
                ? element.Patterns.Scroll.Pattern.HorizontalScrollPercent.ValueOrDefault.ToString()
                : null,
            "scroll.verticalscrollpercent" => element.Patterns.Scroll.IsSupported
                ? element.Patterns.Scroll.Pattern.VerticalScrollPercent.ValueOrDefault.ToString()
                : null,
            "window.canmaximize" => element.Patterns.Window.IsSupported
                ? element.Patterns.Window.Pattern.CanMaximize.ValueOrDefault.ToString().ToLowerInvariant()
                : null,
            "window.canminimize" => element.Patterns.Window.IsSupported
                ? element.Patterns.Window.Pattern.CanMinimize.ValueOrDefault.ToString().ToLowerInvariant()
                : null,
            "window.ismodal" => element.Patterns.Window.IsSupported
                ? element.Patterns.Window.Pattern.IsModal.ValueOrDefault.ToString().ToLowerInvariant()
                : null,
            "window.windowvisualstate" => element.Patterns.Window.IsSupported
                ? ((int)element.Patterns.Window.Pattern.WindowVisualState.Value).ToString()
                : null,
            _ => null,
        };
    }

    public static string? GetProperty(AutomationElement element, string propertyName)
    {
        // Properties are the same as attributes in the UIA context
        return GetAttribute(element, propertyName);
    }

    public static bool IsDisplayed(AutomationElement element)
    {
        return !element.Properties.IsOffscreen.ValueOrDefault;
    }

    public static bool IsEnabled(AutomationElement element)
    {
        return element.Properties.IsEnabled.ValueOrDefault;
    }

    public static bool IsSelected(AutomationElement element)
    {
        if (element.Patterns.SelectionItem.IsSupported)
        {
            return element.Patterns.SelectionItem.Pattern.IsSelected.ValueOrDefault;
        }

        if (element.Patterns.Toggle.IsSupported)
        {
            return element.Patterns.Toggle.Pattern.ToggleState.Value == ToggleState.On;
        }

        return false;
    }

    public static ElementRect GetRect(AutomationElement element)
    {
        var bounds = element.BoundingRectangle;
        return new ElementRect
        {
            X = (int)bounds.X,
            Y = (int)bounds.Y,
            Width = (int)bounds.Width,
            Height = (int)bounds.Height
        };
    }
}
