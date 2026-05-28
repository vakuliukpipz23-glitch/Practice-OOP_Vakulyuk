namespace PracticeOOP_RPG.Domain;

public sealed class CharacterDto
{
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public int Health { get; set; }
    public int AttackPower { get; set; }
    public int Defense { get; set; }
    public WeaponDto? Weapon { get; set; }
}
