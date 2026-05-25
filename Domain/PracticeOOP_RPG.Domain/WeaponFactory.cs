namespace PracticeOOP_RPG.Domain;

public static class WeaponFactory
{
    public static Weapon CreateSword() => new Weapon("Longsword", 6, 1);
    public static Weapon CreateStaff() => new Weapon("Arcane Staff", 4, 2);
    public static Weapon CreateBow() => new Weapon("Short Bow", 5, 3);
    public static Weapon CreateClub() => new Weapon("Spiked Club", 4, 1);
}
