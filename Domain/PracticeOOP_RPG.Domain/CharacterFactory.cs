namespace PracticeOOP_RPG.Domain;

public static class CharacterFactory
{
    public static PlayerCharacter CreateWarrior(string name)
        => new(name, "Warrior", health: 55, attackPower: 8, defense: 5);

    public static PlayerCharacter CreateMage(string name)
        => new(name, "Mage", health: 38, attackPower: 6, defense: 2);

    public static PlayerCharacter CreateRanger(string name)
        => new(name, "Ranger", health: 42, attackPower: 7, defense: 3);

    public static Monster CreateGoblin() => new("Goblin", "Goblin", 28, 5, 2);

    public static Monster CreateOrc() => new("Orc", "Orc", 35, 7, 4);

    public static Monster CreateSkeletonArcher() => new("Skeleton Archer", "Undead Archer", 22, 6, 1);
}
