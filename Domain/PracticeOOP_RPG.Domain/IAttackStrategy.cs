namespace PracticeOOP_RPG.Domain;

public interface IAttackStrategy
{
    AttackResult Execute(ICharacter attacker, ICharacter defender);
}
