namespace PracticeOOP_RPG.Domain;

public static class EnemyFactory
{
    public static Monster CreateGoblin() => new Monster("Goblin", "Goblin", 28, 5, 2);
    public static Monster CreateOrc() => new Monster("Orc", "Orc", 35, 7, 4);
    public static Monster CreateSkeletonArcher() => new Monster("Skeleton Archer", "Undead Archer", 22, 6, 1);
    public static Monster CreateBandit() => new Monster("Bandit", "Rogue Bandit", 30, 6, 3);
    public static Monster CreateWraith() => new Monster("Wraith", "Spectral Wraith", 24, 8, 2);
}
