namespace PracticeOOP_RPG.Domain;

public sealed class SpellAttackStrategy : IAttackStrategy
{
    public AttackResult Execute(Character attacker, Character defender)
    {
        var attackPower = attacker.GetAttackPower() + 2;
        var damage = defender.CalculateDamage(attackPower);
        var description = $"{attacker.Name} casts a spell at {defender.Name}, dealing {damage} magical damage.";
        return new AttackResult(damage, description);
    }
}
