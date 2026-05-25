namespace PracticeOOP_RPG.Domain;

public sealed class Weapon
{
    public string Name { get; }
    public int Power { get; }
    public int Range { get; }

    public Weapon(string name, int power, int range)
    {
        Name = string.IsNullOrWhiteSpace(name) ? throw new ArgumentException("Weapon name is required.", nameof(name)) : name;
        Power = Math.Max(0, power);
        Range = Math.Max(1, range);
    }

    public override string ToString() => $"{Name} (+{Power} ATK, range {Range})";
}
