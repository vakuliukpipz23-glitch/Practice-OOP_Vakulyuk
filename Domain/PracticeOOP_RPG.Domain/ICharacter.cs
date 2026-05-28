namespace PracticeOOP_RPG.Domain;

/// <summary>
/// Інтерфейс для ігрової сутності, яка може брати участь у бою.
/// </summary>
public interface ICharacter
{
    /// <summary>
    /// Ім'я персонажа.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Поточне здоров'я персонажа.
    /// </summary>
    int Health { get; }

    /// <summary>
    /// Чи живий персонаж.
    /// </summary>
    bool IsAlive { get; }

    /// <summary>
    /// Обрана зброя персонажа.
    /// </summary>
    Weapon? EquippedWeapon { get; }

    /// <summary>
    /// Обчислити потужність атаки з урахуванням зброї.
    /// </summary>
    int GetAttackPower();

    /// <summary>
    /// Атакувати іншого персонажа за допомогою стратегії.
    /// </summary>
    AttackResult Attack(ICharacter defender, IAttackStrategy strategy);

    /// <summary>
    /// Оснастити персонажа зброєю.
    /// </summary>
    void EquipWeapon(Weapon weapon);

    /// <summary>
    /// Отримати пошкодження та зменшити здоров'я.
    /// </summary>
    void ReceiveDamage(int amount);

    /// <summary>
    /// Отримати текстовий опис персонажа.
    /// </summary>
    string Describe();
}
