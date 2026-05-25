namespace PracticeOOP_RPG.Domain;

public interface IAttackStrategy
{
    AttackResult Execute(Character attacker, Character defender);
}
