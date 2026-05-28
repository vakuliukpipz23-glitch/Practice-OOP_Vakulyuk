```mermaid
classDiagram
    class Character {
        - _name: string
        - _health: int
        - _baseAttackPower: int
        - _baseDefense: int
        + Name: string
        + Health: int
        + BaseAttackPower: int
        + BaseDefense: int
        + IsAlive: bool
        + EquippedWeapon: Weapon?
        + GetAttackPower(): int
        + Attack(target: Character, strategy: IAttackStrategy): AttackResult
        + EquipWeapon(weapon: Weapon)
        + ReceiveDamage(amount: int)
        + Describe(): string
    }
    class PlayerCharacter {
        + Mana: int
        + Abilities: List<Ability>
        + AddAbility(ability: Ability)
        + RestoreMana(amount: int)
    }
    class Monster
    class Ability {
        + Name: string
        + Description: string
        + ManaCost: int
        + IsHealing: bool
        + Execute(user: PlayerCharacter, target: Character): AttackResult
    }
    class IAttackStrategy
    class MeleeAttackStrategy
    class SpellAttackStrategy
    class HeavyStrikeStrategy
    class CharacterFactory
    class EnemyFactory
    class AbilityFactory
    class Encounter {
        + PlayerParty: Party
        + Waves: List<List<Monster>>
        + CurrentWaveNumber: int
        + TotalWaves: int
        + AddWave(monsters: Monster[])
        + AdvanceWave(): bool
        + GetAliveEnemies(): List<Monster>
    }
    class Party
    class Inventory {
        + Add(item: Item)
        + Remove(item: Item): bool
        + FindByName(partialName: string): IEnumerable<Item>
        + TotalWeight: double
        + TotalValue: int
    }
    class Item
    class Repository_T
    class Cache_TKey_TValue
    class GameStateDto
    class GameStateSerializer
    class GameStateXmlSerializer
    class RetryPolicy
    class CharacterDto
    class ItemDto
    class WeaponDto

    Character <|-- PlayerCharacter
    Character <|-- Monster
    PlayerCharacter --> Ability
    Character --> Weapon
    PlayerCharacter --> Inventory
    Encounter --> Party
    Encounter --> Monster
    Encounter --> Character
    Encounter --> Ability
    IAttackStrategy <|.. MeleeAttackStrategy
    IAttackStrategy <|.. SpellAttackStrategy
    IAttackStrategy <|.. HeavyStrikeStrategy
    CharacterFactory --> Character
    EnemyFactory --> Monster
    AbilityFactory --> Ability
    Repository_T --> Item
    Cache_TKey_TValue --> Item
    GameStateDto --> CharacterDto
    GameStateDto --> ItemDto
    GameStateDto --> WeaponDto

    note right of CharacterFactory : Factory pattern\nстворює персонажів та ворогів
    note right of IAttackStrategy : Strategy pattern\nреалізує різні атаки
    note right of Repository_T : Generic repository\nта кешування
    note bottom of Encounter : Encounter управляє хвилями ворогів\nта ходами бою
```

