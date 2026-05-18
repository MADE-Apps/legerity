namespace Legerity.WindowsDriver.Automation;

using System.Text.RegularExpressions;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using Legerity.WindowsDriver.Exceptions;

/// <summary>
/// Translates CSS selectors into UIA element searches against a FlaUI automation tree.
/// Supports: #id, .class, [attr="value"], tag names (mapped to ControlType), and comma-separated groups.
/// </summary>
public static partial class CssSelectorTranslator
{
    // Known control type names mapped from CSS tag names to UIA ControlType values.
    private static readonly Dictionary<string, ControlType> ControlTypeMap = new(StringComparer.OrdinalIgnoreCase)
    {
        ["button"] = ControlType.Button,
        ["edit"] = ControlType.Edit,
        ["text"] = ControlType.Text,
        ["checkbox"] = ControlType.CheckBox,
        ["combobox"] = ControlType.ComboBox,
        ["list"] = ControlType.List,
        ["listitem"] = ControlType.ListItem,
        ["menu"] = ControlType.Menu,
        ["menuitem"] = ControlType.MenuItem,
        ["menubar"] = ControlType.MenuBar,
        ["progressbar"] = ControlType.ProgressBar,
        ["radiobutton"] = ControlType.RadioButton,
        ["scrollbar"] = ControlType.ScrollBar,
        ["slider"] = ControlType.Slider,
        ["spinner"] = ControlType.Spinner,
        ["statusbar"] = ControlType.StatusBar,
        ["tab"] = ControlType.Tab,
        ["tabitem"] = ControlType.TabItem,
        ["table"] = ControlType.Table,
        ["toolbar"] = ControlType.ToolBar,
        ["tooltip"] = ControlType.ToolTip,
        ["tree"] = ControlType.Tree,
        ["treeitem"] = ControlType.TreeItem,
        ["window"] = ControlType.Window,
        ["hyperlink"] = ControlType.Hyperlink,
        ["image"] = ControlType.Image,
        ["document"] = ControlType.Document,
        ["group"] = ControlType.Group,
        ["pane"] = ControlType.Pane,
        ["datagrid"] = ControlType.DataGrid,
        ["dataitem"] = ControlType.DataItem,
        ["header"] = ControlType.Header,
        ["headeritem"] = ControlType.HeaderItem,
        ["separator"] = ControlType.Separator,
        ["thumb"] = ControlType.Thumb,
        ["titlebar"] = ControlType.TitleBar,
        ["calendar"] = ControlType.Calendar,
        ["splitbutton"] = ControlType.SplitButton,
        ["appbar"] = ControlType.AppBar,
        ["semanticzoom"] = ControlType.SemanticZoom,
    };

    /// <summary>
    /// Find the first element matching a CSS selector.
    /// </summary>
    public static AutomationElement? FindFirst(AutomationElement root, string cssSelector)
    {
        var groups = SplitSelectorGroups(cssSelector);
        foreach (var group in groups)
        {
            var result = FindBySimpleSelector(root, group.Trim());
            if (result != null)
            {
                return result;
            }
        }

        return null;
    }

    /// <summary>
    /// Find all elements matching a CSS selector.
    /// </summary>
    public static AutomationElement[] FindAll(AutomationElement root, string cssSelector)
    {
        var groups = SplitSelectorGroups(cssSelector);
        var results = new List<AutomationElement>();

        foreach (var group in groups)
        {
            var elements = FindAllBySimpleSelector(root, group.Trim());
            results.AddRange(elements);
        }

        return results.ToArray();
    }

    /// <summary>
    /// Splits a CSS selector by commas (respecting brackets/quotes).
    /// </summary>
    private static string[] SplitSelectorGroups(string selector)
    {
        var groups = new List<string>();
        int depth = 0;
        bool inQuote = false;
        char quoteChar = '\0';
        int start = 0;

        for (int i = 0; i < selector.Length; i++)
        {
            char c = selector[i];
            if (inQuote)
            {
                if (c == quoteChar)
                {
                    inQuote = false;
                }

                continue;
            }

            if (c == '"' || c == '\'')
            {
                inQuote = true;
                quoteChar = c;
            }
            else if (c == '[')
            {
                depth++;
            }
            else if (c == ']')
            {
                depth--;
            }
            else if (c == ',' && depth == 0)
            {
                groups.Add(selector[start..i]);
                start = i + 1;
            }
        }

        groups.Add(selector[start..]);
        return groups.ToArray();
    }

    /// <summary>
    /// Handles a single selector group (no commas). Supports descendant combinator (space) and child combinator (>).
    /// </summary>
    private static AutomationElement? FindBySimpleSelector(AutomationElement root, string selector)
    {
        var segments = ParseCombinatorSegments(selector);
        if (segments.Count == 0)
        {
            return null;
        }

        // Start with the first segment
        var candidates = FindMatchingElements(root, segments[0].Selector, segments[0].IsChild);

        // Apply each subsequent segment
        for (int i = 1; i < segments.Count; i++)
        {
            var nextCandidates = new List<AutomationElement>();
            foreach (var candidate in candidates)
            {
                var found = FindMatchingElements(candidate, segments[i].Selector, segments[i].IsChild);
                nextCandidates.AddRange(found);
            }

            candidates = nextCandidates;
        }

        return candidates.FirstOrDefault();
    }

    private static AutomationElement[] FindAllBySimpleSelector(AutomationElement root, string selector)
    {
        var segments = ParseCombinatorSegments(selector);
        if (segments.Count == 0)
        {
            return [];
        }

        var candidates = FindMatchingElements(root, segments[0].Selector, segments[0].IsChild);

        for (int i = 1; i < segments.Count; i++)
        {
            var nextCandidates = new List<AutomationElement>();
            foreach (var candidate in candidates)
            {
                var found = FindMatchingElements(candidate, segments[i].Selector, segments[i].IsChild);
                nextCandidates.AddRange(found);
            }

            candidates = nextCandidates;
        }

        return candidates.ToArray();
    }

    /// <summary>
    /// Parse a selector into segments separated by combinators (space for descendant, > for child).
    /// </summary>
    private static List<SelectorSegment> ParseCombinatorSegments(string selector)
    {
        var segments = new List<SelectorSegment>();
        int i = 0;

        // Skip leading whitespace
        while (i < selector.Length && selector[i] == ' ')
        {
            i++;
        }

        int start = i;
        bool inBracket = false;
        bool inQuote = false;
        char quoteChar = '\0';
        bool nextIsChild = false;

        while (i < selector.Length)
        {
            char c = selector[i];

            if (inQuote)
            {
                if (c == quoteChar)
                {
                    inQuote = false;
                }

                i++;
                continue;
            }

            if (c == '"' || c == '\'')
            {
                inQuote = true;
                quoteChar = c;
                i++;
                continue;
            }

            if (c == '[')
            {
                inBracket = true;
                i++;
                continue;
            }

            if (c == ']')
            {
                inBracket = false;
                i++;
                continue;
            }

            if (inBracket)
            {
                i++;
                continue;
            }

            if (c == '>')
            {
                var segment = selector[start..i].Trim();
                if (segment.Length > 0)
                {
                    segments.Add(new SelectorSegment(segment, nextIsChild));
                }

                nextIsChild = true;
                i++;

                // Skip whitespace after >
                while (i < selector.Length && selector[i] == ' ')
                {
                    i++;
                }

                start = i;
                continue;
            }

            if (c == ' ')
            {
                var segment = selector[start..i].Trim();
                if (segment.Length > 0)
                {
                    segments.Add(new SelectorSegment(segment, nextIsChild));
                    nextIsChild = false;
                }

                // Skip whitespace and check for >
                while (i < selector.Length && selector[i] == ' ')
                {
                    i++;
                }

                if (i < selector.Length && selector[i] == '>')
                {
                    nextIsChild = true;
                    i++;
                    while (i < selector.Length && selector[i] == ' ')
                    {
                        i++;
                    }
                }

                start = i;
                continue;
            }

            i++;
        }

        var last = selector[start..].Trim();
        if (last.Length > 0)
        {
            segments.Add(new SelectorSegment(last, nextIsChild));
        }

        return segments;
    }

    /// <summary>
    /// Find elements matching a single compound selector (no combinators).
    /// </summary>
    private static List<AutomationElement> FindMatchingElements(AutomationElement root, string compoundSelector, bool childOnly)
    {
        var parts = ParseCompoundSelector(compoundSelector);
        var condition = BuildCondition(root.ConditionFactory, parts);

        AutomationElement[] found;
        if (childOnly)
        {
            found = condition != null
                ? root.FindAllChildren(condition)
                : root.FindAllChildren();
        }
        else
        {
            found = condition != null
                ? root.FindAllDescendants(condition)
                : root.FindAllDescendants();
        }

        return found.ToList();
    }

    /// <summary>
    /// Parse a compound selector (e.g., "button#myId.myClass[name='foo']") into its component parts.
    /// </summary>
    private static SelectorParts ParseCompoundSelector(string selector)
    {
        var parts = new SelectorParts();
        int i = 0;

        while (i < selector.Length)
        {
            char c = selector[i];

            if (c == '#')
            {
                // ID selector -> AutomationId
                i++;
                var value = ReadIdentifier(selector, ref i);
                parts.AutomationId = value;
            }
            else if (c == '.')
            {
                // Class selector -> ClassName
                i++;
                var value = ReadIdentifier(selector, ref i);
                parts.ClassName = value;
            }
            else if (c == '[')
            {
                // Attribute selector
                i++;
                var (attrName, attrValue) = ReadAttributeSelector(selector, ref i);
                parts.Attributes.Add((attrName, attrValue));
            }
            else if (c == '*')
            {
                // Universal selector - matches anything
                parts.IsUniversal = true;
                i++;
            }
            else if (char.IsLetterOrDigit(c) || c == '_' || c == '-')
            {
                // Tag name -> ControlType
                var tagName = ReadIdentifier(selector, ref i);
                parts.TagName = tagName;
            }
            else
            {
                // Skip unexpected characters
                i++;
            }
        }

        return parts;
    }

    private static string ReadIdentifier(string selector, ref int i)
    {
        int start = i;
        while (i < selector.Length && (char.IsLetterOrDigit(selector[i]) || selector[i] == '_' || selector[i] == '-'))
        {
            i++;
        }

        return selector[start..i];
    }

    /// <summary>
    /// Reads a quoted string value, handling CSS backslash escape sequences (e.g., <c>\ </c> for a literal space).
    /// </summary>
    private static string ReadEscapedString(string selector, ref int i, char quote)
    {
        var sb = new System.Text.StringBuilder();
        while (i < selector.Length && selector[i] != quote)
        {
            if (selector[i] == '\\' && i + 1 < selector.Length)
            {
                i++; // skip backslash
                sb.Append(selector[i]); // append the escaped character as-is
            }
            else
            {
                sb.Append(selector[i]);
            }

            i++;
        }

        return sb.ToString();
    }

    private static (string name, string? value) ReadAttributeSelector(string selector, ref int i)
    {
        // Skip whitespace
        while (i < selector.Length && selector[i] == ' ')
        {
            i++;
        }

        // Read attribute name
        int nameStart = i;
        while (i < selector.Length && selector[i] != '=' && selector[i] != ']' && selector[i] != ' ')
        {
            i++;
        }

        var name = selector[nameStart..i].Trim();

        // Skip whitespace
        while (i < selector.Length && selector[i] == ' ')
        {
            i++;
        }

        if (i >= selector.Length || selector[i] == ']')
        {
            if (i < selector.Length)
            {
                i++; // skip ]
            }

            return (name, null);
        }

        if (selector[i] == '=')
        {
            i++; // skip =

            // Skip whitespace
            while (i < selector.Length && selector[i] == ' ')
            {
                i++;
            }

            // Read value (possibly quoted)
            string value;
            if (i < selector.Length && (selector[i] == '"' || selector[i] == '\''))
            {
                char quote = selector[i];
                i++; // skip opening quote
                value = ReadEscapedString(selector, ref i, quote);
                if (i < selector.Length)
                {
                    i++; // skip closing quote
                }
            }
            else
            {
                int valStart = i;
                while (i < selector.Length && selector[i] != ']' && selector[i] != ' ')
                {
                    i++;
                }

                value = selector[valStart..i];
            }

            // Skip to closing bracket
            while (i < selector.Length && selector[i] != ']')
            {
                i++;
            }

            if (i < selector.Length)
            {
                i++; // skip ]
            }

            return (name, value);
        }

        // Unexpected - skip to ]
        while (i < selector.Length && selector[i] != ']')
        {
            i++;
        }

        if (i < selector.Length)
        {
            i++;
        }

        return (name, null);
    }

    /// <summary>
    /// Build a FlaUI condition from parsed selector parts.
    /// </summary>
    private static ConditionBase? BuildCondition(ConditionFactory cf, SelectorParts parts)
    {
        var conditions = new List<ConditionBase>();

        // Tag name -> ControlType
        if (!string.IsNullOrEmpty(parts.TagName))
        {
            if (ControlTypeMap.TryGetValue(parts.TagName, out var controlType))
            {
                conditions.Add(cf.ByControlType(controlType));
            }
            else
            {
                // Try as a localized control type
                conditions.Add(cf.ByLocalizedControlType(parts.TagName));
            }
        }

        // #id -> AutomationId
        if (!string.IsNullOrEmpty(parts.AutomationId))
        {
            conditions.Add(cf.ByAutomationId(parts.AutomationId));
        }

        // .class -> ClassName
        if (!string.IsNullOrEmpty(parts.ClassName))
        {
            conditions.Add(cf.ByClassName(parts.ClassName));
        }

        // [attr=value] -> mapped to UIA properties
        foreach (var (attrName, attrValue) in parts.Attributes)
        {
            var condition = BuildAttributeCondition(cf, attrName, attrValue);
            if (condition != null)
            {
                conditions.Add(condition);
            }
        }

        return conditions.Count switch
        {
            0 => null,
            1 => conditions[0],
            _ => new AndCondition(conditions.ToArray()),
        };
    }

    private static ConditionBase? BuildAttributeCondition(ConditionFactory cf, string attrName, string? attrValue)
    {
        if (attrValue == null)
        {
            // Presence-only selector like [name] - no value to match, skip
            return null;
        }

        return attrName.ToLowerInvariant() switch
        {
            "name" => cf.ByName(attrValue),
            "automationid" or "id" => cf.ByAutomationId(attrValue),
            "classname" or "class" => cf.ByClassName(attrValue),
            "controltype" => ControlTypeMap.TryGetValue(attrValue, out var ct)
                ? cf.ByControlType(ct)
                : cf.ByLocalizedControlType(attrValue),
            "helptext" => cf.ByHelpText(attrValue),
            _ => throw new WebDriverException(WebDriverErrors.InvalidSelector,
                $"Unsupported CSS attribute selector: [{attrName}=\"{attrValue}\"]. " +
                $"Supported attributes: name, automationid, id, classname, class, controltype, helptext.", 400),
        };
    }

    private record SelectorSegment(string Selector, bool IsChild);

    private class SelectorParts
    {
        public string? TagName { get; set; }
        public string? AutomationId { get; set; }
        public string? ClassName { get; set; }
        public bool IsUniversal { get; set; }
        public List<(string Name, string? Value)> Attributes { get; } = new();
    }
}
