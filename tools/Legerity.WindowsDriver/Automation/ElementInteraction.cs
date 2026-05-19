namespace Legerity.WindowsDriver.Automation;

using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.Core.WindowsAPI;
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
            var containsSpecialKeys = text.Any(c => c >= '\uE000' && c <= '\uE050');

            if (!containsSpecialKeys && element.Patterns.Value.IsSupported)
            {
                element.Patterns.Value.Pattern.SetValue(text);
                return;
            }

            element.Focus();

            foreach (var ch in text)
            {
                if (TryMapSpecialKey(ch, out var vk))
                {
                    FlaUI.Core.Input.Keyboard.Type(vk);
                }
                else
                {
                    FlaUI.Core.Input.Keyboard.Type(ch.ToString());
                }
            }
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

    private static bool TryMapSpecialKey(char ch, out VirtualKeyShort vk)
    {
        vk = ch switch
        {
            '\uE003' => VirtualKeyShort.BACK,
            '\uE004' => VirtualKeyShort.TAB,
            '\uE005' => VirtualKeyShort.CLEAR,
            '\uE006' => VirtualKeyShort.RETURN,
            '\uE007' => VirtualKeyShort.RETURN,
            '\uE008' => VirtualKeyShort.SHIFT,
            '\uE009' => VirtualKeyShort.CONTROL,
            '\uE00A' => VirtualKeyShort.ALT,
            '\uE00B' => VirtualKeyShort.PAUSE,
            '\uE00C' => VirtualKeyShort.ESCAPE,
            '\uE00D' => VirtualKeyShort.SPACE,
            '\uE00E' => VirtualKeyShort.PRIOR,
            '\uE00F' => VirtualKeyShort.NEXT,
            '\uE010' => VirtualKeyShort.END,
            '\uE011' => VirtualKeyShort.HOME,
            '\uE012' => VirtualKeyShort.LEFT,
            '\uE013' => VirtualKeyShort.UP,
            '\uE014' => VirtualKeyShort.RIGHT,
            '\uE015' => VirtualKeyShort.DOWN,
            '\uE016' => VirtualKeyShort.INSERT,
            '\uE017' => VirtualKeyShort.DELETE,
            '\uE031' => VirtualKeyShort.F1,
            '\uE032' => VirtualKeyShort.F2,
            '\uE033' => VirtualKeyShort.F3,
            '\uE034' => VirtualKeyShort.F4,
            '\uE035' => VirtualKeyShort.F5,
            '\uE036' => VirtualKeyShort.F6,
            '\uE037' => VirtualKeyShort.F7,
            '\uE038' => VirtualKeyShort.F8,
            '\uE039' => VirtualKeyShort.F9,
            '\uE03A' => VirtualKeyShort.F10,
            '\uE03B' => VirtualKeyShort.F11,
            '\uE03C' => VirtualKeyShort.F12,
            '\uE03D' => VirtualKeyShort.LWIN,
            '\uE01A' => VirtualKeyShort.NUMPAD0,
            '\uE01B' => VirtualKeyShort.NUMPAD1,
            '\uE01C' => VirtualKeyShort.NUMPAD2,
            '\uE01D' => VirtualKeyShort.NUMPAD3,
            '\uE01E' => VirtualKeyShort.NUMPAD4,
            '\uE01F' => VirtualKeyShort.NUMPAD5,
            '\uE020' => VirtualKeyShort.NUMPAD6,
            '\uE021' => VirtualKeyShort.NUMPAD7,
            '\uE022' => VirtualKeyShort.NUMPAD8,
            '\uE023' => VirtualKeyShort.NUMPAD9,
            '\uE024' => VirtualKeyShort.MULTIPLY,
            '\uE025' => VirtualKeyShort.ADD,
            '\uE026' => VirtualKeyShort.SEPARATOR,
            '\uE027' => VirtualKeyShort.SUBTRACT,
            '\uE028' => VirtualKeyShort.DECIMAL,
            '\uE029' => VirtualKeyShort.DIVIDE,
            _ => 0,
        };

        return vk != 0;
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
                ? GetSelectedChildNames(element)
                : null,
            "selectionitem.isselected" or "isselected" => element.Patterns.SelectionItem.IsSupported
                ? IsSelected(element).ToString().ToLowerInvariant()
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

    private static string GetSelectedChildNames(AutomationElement element)
    {
        var items = element.Patterns.Selection.Pattern.Selection.ValueOrDefault;
        return string.Join(", ", items?.Select(e => e.Properties.Name.ValueOrDefault ?? string.Empty) ?? []);
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
