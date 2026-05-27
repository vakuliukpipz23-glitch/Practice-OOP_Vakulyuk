namespace PracticeOOP_RPG.Domain;

public sealed class MeleeAttackStrategy : IAttackStrategy
{
    public AttackResult Execute(ICharacter attacker, ICharacter defender)
    {
        if (attacker is not Character attackCharacter) throw new ArgumentException("Attacker must be a Character.", nameof(attacker));
        if (defender is not Character defendCharacter) throw new ArgumentException("Defender must be a Character.", nameof(defender));

        var attackPower = attackCharacter.GetAttackPower();
        var damage = defendCharacter.CalculateDamage(attackPower);
        var description = $"{attackCharacter.Name} attacks {defendCharacter.Name} with melee, dealing {damage} damage.";
        return new AttackResult(damage, description);
    }
}
