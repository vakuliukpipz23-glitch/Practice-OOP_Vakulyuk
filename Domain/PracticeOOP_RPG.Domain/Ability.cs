namespace PracticeOOP_RPG.Domain;

public sealed class Ability
{
    public string Name { get; }
    public string Description { get; }
    public int ManaCost { get; }
    public IAttackStrategy? AttackStrategy { get; }
    public int HealAmount { get; }

    public bool IsHealing => HealAmount > 0;

    public Ability(string name, string description, int manaCost, IAttackStrategy? attackStrategy, int healAmount)
    {
        Name = string.IsNullOrWhiteSpace(name) ? throw new ArgumentException("Ability name is required.", nameof(name)) : name;
        Description = description ?? string.Empty;
        ManaCost = Math.Max(0, manaCost);
        AttackStrategy = attackStrategy;
        HealAmount = Math.Max(0, healAmount);
    }

    public AttackResult Execute(PlayerCharacter user, Character target)
    {
        if (user == null) throw new ArgumentNullException(nameof(user));
        if (target == null) throw new ArgumentNullException(nameof(target));

        if (user.Mana < ManaCost)
        {
            return new AttackResult(0, $"{user.Name} не має достатньо мани для {Name}.");
        }

        user.TrySpendMana(ManaCost);

        if (IsHealing)
        {
            target.Heal(HealAmount);
            return new AttackResult(0, $"{user.Name} використовує {Name} і відновлює {HealAmount} HP.");
        }

        if (AttackStrategy == null)
        {
            throw new InvalidOperationException($"Ability {Name} не має стратегії атаки.");
        }

        var result = AttackStrategy.Execute(user, target);
        return new AttackResult(result.Damage, $"{user.Name} застосовує {Name} до {target.Name}. {result.Description}");
    }
}
