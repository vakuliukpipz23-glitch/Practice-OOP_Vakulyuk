namespace PracticeOOP_RPG.Domain;

public sealed class PlayerCharacter : Character
{
    public string ClassName { get; }
    public int Mana { get; private set; }
    public int MaxMana { get; private set; }

    public PlayerCharacter(string name, string className, int health, int attackPower, int defense)
        : base(name, health, attackPower, defense)
    {
        ClassName = string.IsNullOrWhiteSpace(className) ? "Adventurer" : className;
        MaxMana = className == "Mage" ? 30 : 20;
        Mana = MaxMana;
    }

    public override string Describe()
    {
        return $"{Name} the {ClassName}: HP={Health}/{MaxHealth}, MP={Mana}/{MaxMana}, ATK={GetAttackPower()}, DEF={BaseDefense}.";
    }

    public bool TrySpendMana(int amount)
    {
        if (amount <= 0) return false;
        if (Mana < amount) return false;

        Mana -= amount;
        return true;
    }

    public void RestoreMana(int amount)
    {
        if (amount <= 0) return;
        Mana = Math.Min(MaxMana, Mana + amount);
    }
}
