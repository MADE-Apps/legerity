namespace Legerity.Features.Generators.Models;

internal class UiElement
{
    public UiElement(string type, string name, string by, string value)
    {
        Type = type;
        Name = name;
        By = by;
        Value = value;
    }

    public string Type { get; set; }

    public string Name { get; set; }

    public string By { get; set; }

    public string Value { get; set; }

    public override string ToString()
    {
        return $"[Type] {Type}; [Name] {Name}; [By] {By}; [Value] {Value};";
    }
}
