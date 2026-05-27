namespace PracticeOOP_RPG.Domain;

public sealed class Item
{
    public string Name { get; }
    public string Description { get; }
    public double Weight { get; }
    public int Value { get; }

    public Item(string name, string description, double weight, int value)
    {
        Name = string.IsNullOrWhiteSpace(name) ? throw new ArgumentException("Item name is required.", nameof(name)) : name;
        Description = description ?? string.Empty;
        Weight = Math.Max(0.0, weight);
        Value = Math.Max(0, value);
    }

    public override string ToString() => $"{Name} ({Description}) - Weight: {Weight}, Value: {Value}";
}
