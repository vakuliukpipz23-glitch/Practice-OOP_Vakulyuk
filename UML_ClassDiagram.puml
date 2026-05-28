@startuml
skinparam classAttributeIconSize 0
skinparam shadowing false
skinparam packageStyle rect

package Domain {
  abstract class Character {
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

  interface IAttackStrategy {
    + Execute(user: Character, target: Character): AttackResult
  }

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
  class Repository<T>
  class Cache<TKey, TValue>
  class GameStateDto
  class GameStateSerializer
  class GameStateXmlSerializer
  class RetryPolicy
}

package DTO {
  class CharacterDto
  class ItemDto
  class WeaponDto
}

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
Repository<T> --> T
Cache<TKey, TValue> --> TKey
Cache<TKey, TValue> --> TValue
GameStateDto --> CharacterDto
GameStateDto --> ItemDto
GameStateDto --> WeaponDto

note right of CharacterFactory
  Factory pattern
  створює персонажів
  та ворогів
end note

note right of IAttackStrategy
  Strategy pattern
  реалізує різні атаки
end note

note right of Repository<T>
  Generic repository
  та кешування
end note

note bottom of Encounter
  Encounter управляє хвилями ворогів
  та ходами бою
end note
@enduml
