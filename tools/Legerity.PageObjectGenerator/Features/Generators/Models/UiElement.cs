namespace Legerity.Features.Generators.Models;

internal class UiElement
{
    public UiElement(string type, string name, string by, string value)
    {
        this.Type = type;
        this.Name = name;
        this.By = by;
        this.Value = value;
    }

    public string Type { get; set; }

    public string Name { get; set; }

    public string By { get; set; }

    public string Value { get; set; }

    public override string ToString()
    {
        return $"[Type] {this.Type}; [Name] {this.Name}; [By] {this.By}; [Value] {this.Value};";
    }
}