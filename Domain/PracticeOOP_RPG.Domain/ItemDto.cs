namespace PracticeOOP_RPG.Domain;

public sealed class ItemDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double Weight { get; set; }
    public int Value { get; set; }
}
