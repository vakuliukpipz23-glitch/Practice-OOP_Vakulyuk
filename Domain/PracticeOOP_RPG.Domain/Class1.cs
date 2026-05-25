namespace PracticeOOP_RPG.Domain;

public abstract class Character : IEquatable<Character>
{
    private readonly string _name;
    private int _health;
    private readonly int _baseAttackPower;
    private readonly int _baseDefense;

    protected Character(string name, int health, int attackPower, int defense)
    {
        _name = string.IsNullOrWhiteSpace(name) ? throw new ArgumentException("Name is required.", nameof(name)) : name;
        _health = Math.Max(0, health);
        _baseAttackPower = Math.Max(0, attackPower);
        _baseDefense = Math.Max(0, defense);
    }

    public string Name => _name;
    public int Health
    {
        get => _health;
        protected set => _health = Math.Max(0, value);
    }

    public int BaseAttackPower => _baseAttackPower;
    public int BaseDefense => _baseDefense;
    public bool IsAlive => Health > 0;
    public Weapon? EquippedWeapon { get; private set; }

    public void EquipWeapon(Weapon weapon)
    {
        EquippedWeapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
    }

    public int GetAttackPower() => BaseAttackPower + (EquippedWeapon?.Power ?? 0);

    public int CalculateDamage(int attackPower)
    {
        return Math.Max(1, attackPower - BaseDefense);
    }

    public AttackResult Attack(Character defender, IAttackStrategy strategy)
    {
        if (defender == null) throw new ArgumentNullException(nameof(defender));
        if (strategy == null) throw new ArgumentNullException(nameof(strategy));
        if (!IsAlive) return new AttackResult(0, $"{Name} cannot attack because they are defeated.");

        return strategy.Execute(this, defender);
    }

    public void ReceiveDamage(int amount)
    {
        if (amount <= 0) return;
        Health -= amount;
    }

    public abstract string Describe();

    public override string ToString() => $"{Name} [HP={Health}, ATK={GetAttackPower()}, DEF={BaseDefense}]";

    public override bool Equals(object? obj) => Equals(obj as Character);

    public bool Equals(Character? other)
    {
        return other != null && GetType() == other.GetType() && Name == other.Name;
    }

    public override int GetHashCode() => HashCode.Combine(Name, GetType());
}

