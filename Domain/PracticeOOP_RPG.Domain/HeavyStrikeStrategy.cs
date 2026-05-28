namespace PracticeOOP_RPG.Domain;

public sealed class HeavyStrikeStrategy : IAttackStrategy
{
    public AttackResult Execute(ICharacter attacker, ICharacter defender)
    {
        if (attacker is not Character attackCharacter) throw new ArgumentException("Attacker must be a Character.", nameof(attacker));
        if (defender is not Character defendCharacter) throw new ArgumentException("Defender must be a Character.", nameof(defender));

        var attackPower = attackCharacter.GetAttackPower() + 3;
        var damage = defendCharacter.CalculateDamage(attackPower);
        var description = $"{attackCharacter.Name} завдає сильний удар {defendCharacter.Name}, наносячи {damage} пошкодження.";
        return new AttackResult(damage, description);
    }
}
