using Moq;
using PracticeOOP_RPG.Domain;

namespace PracticeOOP_RPG.Tests;

public class AdditionalDomainTests
{
    [Fact]
    public void WeaponFactory_Should_Create_Sword_With_Correct_Stats()
    {
        var sword = WeaponFactory.CreateSword();

        Assert.Equal("Longsword", sword.Name);
        Assert.Equal(6, sword.Power);
        Assert.Equal(1, sword.Range);
    }

    [Fact]
    public void Character_WhenEquippingWeapon_IncreasesAttackPower()
    {
        var hero = CharacterFactory.CreateWarrior("Anna");
        var basePower = hero.BaseAttackPower;
        var sword = WeaponFactory.CreateSword();

        hero.EquipWeapon(sword);

        Assert.Equal(basePower + sword.Power, hero.GetAttackPower());
    }

    [Fact]
    public void Character_ReceiveDamage_CannotFallBelowZero()
    {
        var monster = EnemyFactory.CreateGoblin();

        monster.ReceiveDamage(1000);

        Assert.Equal(0, monster.Health);
        Assert.False(monster.IsAlive);
    }

    [Fact]
    public void Character_Heal_DoesNotExceedMaxHealth()
    {
        var hero = CharacterFactory.CreateMage("Lina");
        hero.ReceiveDamage(10);

        hero.Heal(100);

        Assert.Equal(hero.MaxHealth, hero.Health);
    }

    [Fact]
    public void Ability_Healing_ExecutesAndRestoresHealth()
    {
        var hero = new PlayerCharacter("Mira", "Cleric", health: 40, attackPower: 5, defense: 4);
        var target = CharacterFactory.CreateWarrior("Grom");
        target.ReceiveDamage(10);
        var healing = new Ability("Heal", "Відновлює силу", manaCost: 5, attackStrategy: null, healAmount: 10);

        hero.EquipWeapon(WeaponFactory.CreateStaff());
        var result = healing.Execute(hero, target);

        Assert.Equal(0, result.Damage);
        Assert.Contains("відновлює 10 HP", result.Description);
        Assert.Equal(target.MaxHealth, target.Health);
    }

    [Fact]
    public void Ability_NotEnoughMana_ReturnsZeroDamageMessage()
    {
        var hero = CharacterFactory.CreateMage("Nina");
        var target = CharacterFactory.CreateGoblin();
        var expensiveSpell = new Ability("Meteor", "Сильна магія", manaCost: 999, attackStrategy: new SpellAttackStrategy(), healAmount: 0);

        var result = expensiveSpell.Execute(hero, target);

        Assert.Equal(0, result.Damage);
        Assert.Contains("не має достатньо мани", result.Description);
    }

    [Fact]
    public void Ability_NoAttackStrategy_ThrowsInvalidOperationException()
    {
        var hero = CharacterFactory.CreateWarrior("Odin");
        var target = CharacterFactory.CreateOrc();
        var ability = new Ability("Strike", "Напад без стратегії", manaCost: 1, attackStrategy: null, healAmount: 0);

        Assert.Throws<InvalidOperationException>(() => ability.Execute(hero, target));
    }

    [Fact]
    public void Inventory_Add_Remove_UpdatesCountAndTotals()
    {
        var inventory = new Inventory();
        var potion = new Item("Potion", "Лікує", 0.7, 25);
        var scroll = new Item("Scroll", "Магічний сувій", 0.2, 50);

        inventory.Add(potion);
        inventory.Add(scroll);
        inventory.Remove(potion);

        Assert.Equal(1, inventory.Count);
        Assert.Equal(scroll.Weight, inventory.TotalWeight);
        Assert.Equal(scroll.Value, inventory.TotalValue);
    }

    [Fact]
    public void Inventory_FindByName_IsCaseInsensitive()
    {
        var inventory = new Inventory();
        inventory.Add(new Item("Health Potion", "Лікує", 0.5, 30));
        inventory.Add(new Item("Mana Potion", "Відновлює мана", 0.4, 35));

        var found = inventory.FindByName("health").ToList();

        Assert.Single(found);
        Assert.Equal("Health Potion", found[0].Name);
    }

    [Fact]
    public void GameStateXmlSerializer_Should_SaveAndLoad_Game_State()
    {
        var hero = CharacterFactory.CreateWarrior("Rok");
        hero.EquipWeapon(WeaponFactory.CreateSword());
        var gameState = new GameStateDto
        {
            Name = "XmlTest",
            SavedAt = DateTime.UtcNow,
            Characters = new List<CharacterDto>
            {
                new CharacterDto
                {
                    Name = hero.Name,
                    Type = "Warrior",
                    Health = hero.Health,
                    AttackPower = hero.BaseAttackPower,
                    Defense = hero.BaseDefense,
                    Weapon = new WeaponDto
                    {
                        Name = hero.EquippedWeapon!.Name,
                        Power = hero.EquippedWeapon.Power,
                        Range = hero.EquippedWeapon.Range
                    }
                }
            },
            Inventory = new List<ItemDto>()
        };

        var tempPath = Path.Combine(Path.GetTempPath(), $"gamestate_xml_{Guid.NewGuid()}.xml");
        try
        {
            GameStateXmlSerializer.Save(tempPath, gameState);
            var loaded = GameStateXmlSerializer.Load(tempPath);

            Assert.Equal(gameState.Name, loaded.Name);
            Assert.Equal(1, loaded.Characters.Count);
            Assert.Equal("Longsword", loaded.Characters[0].Weapon?.Name);
        }
        finally
        {
            if (File.Exists(tempPath)) File.Delete(tempPath);
        }
    }
}
