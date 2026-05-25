namespace PracticeOOP_RPG.Domain;

public sealed class Monster : Character
{
    public string MonsterType { get; }

    public Monster(string name, string monsterType, int health, int attackPower, int defense)
        : base(name, health, attackPower, defense)
    {
        MonsterType = string.IsNullOrWhiteSpace(monsterType) ? "Monster" : monsterType;
    }

    public override string Describe()
    {
        return $"{Name} the {MonsterType}: HP={Health}, ATK={GetAttackPower()}, DEF={BaseDefense}.";
    }
}
