namespace PracticeOOP_RPG.Domain;

public sealed class MeleeAttackStrategy : IAttackStrategy
{
    public AttackResult Execute(Character attacker, Character defender)
    {
        var attackPower = attacker.GetAttackPower();
        var damage = defender.CalculateDamage(attackPower);
        var description = $"{attacker.Name} attacks {defender.Name} with melee, dealing {damage} damage.";
        return new AttackResult(damage, description);
    }
}
