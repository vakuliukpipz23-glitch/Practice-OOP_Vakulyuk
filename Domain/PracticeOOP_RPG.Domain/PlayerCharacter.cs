namespace PracticeOOP_RPG.Domain;

public sealed class PlayerCharacter : Character
{
    public string ClassName { get; }

    public PlayerCharacter(string name, string className, int health, int attackPower, int defense)
        : base(name, health, attackPower, defense)
    {
        ClassName = string.IsNullOrWhiteSpace(className) ? "Adventurer" : className;
    }

    public override string Describe()
    {
        return $"{Name} the {ClassName}: HP={Health}, ATK={GetAttackPower()}, DEF={BaseDefense}.";
    }
}
