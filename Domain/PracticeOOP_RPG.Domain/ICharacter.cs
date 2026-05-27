namespace PracticeOOP_RPG.Domain;

public interface ICharacter
{
    string Name { get; }
    int Health { get; }
    bool IsAlive { get; }
    Weapon? EquippedWeapon { get; }
    int GetAttackPower();
    AttackResult Attack(ICharacter defender, IAttackStrategy strategy);
    void EquipWeapon(Weapon weapon);
    void ReceiveDamage(int amount);
    string Describe();
}
