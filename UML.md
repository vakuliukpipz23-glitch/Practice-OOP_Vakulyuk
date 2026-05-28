# UML-діаграма класів

Це просте і зрозуміле представлення основної архітектури проєкту `Practice-OOP_RPG`.

## Основні елементи

- `Character` — абстрактний базовий клас для персонажів.
- `PlayerCharacter` і `Monster` — конкретні типи персонажів.
- `Weapon` — озброєння, яке може бути оснащене персонажем.
- `Ability` — здібність гравця, яка може використовувати стратегію атаки або лікування.
- `Battle` — логіка бою між двома персонажами.
- `IAttackStrategy` — інтерфейс для патерну "Стратегія" атак.
- `Party` та `Inventory` — колекції для персонажів та предметів.

## Mermaid UML

```mermaid
classDiagram
    ICharacter <|.. Character
    Character <|-- PlayerCharacter
    Character <|-- Monster
    IAttackStrategy <|.. MeleeAttackStrategy
    IAttackStrategy <|.. SpellAttackStrategy
    IAttackStrategy <|.. HeavyStrikeStrategy
    Character o-- Weapon : EquippedWeapon
    PlayerCharacter "1" o-- "*" Ability
    Ability --> IAttackStrategy
    Battle --> Character : first
    Battle --> Character : second
    Battle --> BattleEventArgs
    Party "1" o-- "*" Character
    Inventory "1" o-- "*" Item

    class Character {
        - string Name
        - int Health
        - int MaxHealth
        - int BaseAttackPower
        - int BaseDefense
        - Weapon? EquippedWeapon
        + GetAttackPower()
        + CalculateDamage(int)
        + Attack(ICharacter, IAttackStrategy)
        + ReceiveDamage(int)
        + Heal(int)
        + RestoreToFull()
        + Describe()
    }

    class PlayerCharacter {
        - string ClassName
        - int Mana
        - int MaxMana
        - List<Ability> _abilities
        + AddAbility(Ability)
        + TrySpendMana(int)
        + RestoreMana(int)
    }

    class Monster {
        - string MonsterType
    }

    class Ability {
        - string Name
        - string Description
        - int ManaCost
        - IAttackStrategy? AttackStrategy
        - int HealAmount
        + Execute(PlayerCharacter, Character)
    }

    class Weapon {
        - string Name
        - int Power
        - int Range
    }

    class Battle {
        - Character _first
        - Character _second
        + Start(IAttackStrategy, IAttackStrategy)
    }

    class MeleeAttackStrategy {
        + Execute(ICharacter, ICharacter)
    }

    class SpellAttackStrategy {
        + Execute(ICharacter, ICharacter)
    }

    class HeavyStrikeStrategy {
        + Execute(ICharacter, ICharacter)
    }

    class Party {
        - List<Character> _members
        + Add(Character)
        + Remove(Character)
        + GetAliveMembers()
    }

    class Inventory {
        - List<Item> _items
        + Add(Item)
        + Remove(Item)
    }

    class Item {
        - string Name
        - string Description
        - double Weight
        - int Value
    }
```


