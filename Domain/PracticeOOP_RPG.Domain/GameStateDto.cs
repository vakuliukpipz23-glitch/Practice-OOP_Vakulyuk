namespace PracticeOOP_RPG.Domain;

public sealed class GameStateDto
{
    public string Name { get; set; } = string.Empty;
    public DateTime SavedAt { get; set; }
    public List<CharacterDto> Characters { get; set; } = new();
    public List<ItemDto> Inventory { get; set; } = new();
}
