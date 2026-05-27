using PracticeOOP_RPG.Domain;

namespace PracticeOOP_RPG.Tests;

public class BattleTests
{
    [Fact]
    public void Battle_Should_End_With_Monster_Defeated_When_Player_Stronger()
    {
        var hero = new PlayerCharacter("Elena", "Paladin", health: 45, attackPower: 8, defense: 4);
        hero.EquipWeapon(WeaponFactory.CreateSword());

        var goblin = EnemyFactory.CreateGoblin();
        goblin.EquipWeapon(WeaponFactory.CreateClub());

        var battle = new Battle(hero, goblin);
        var log = new List<string>();
        battle.BattleLog += (_, args) => log.Add(args.Message);

        battle.Start(new MeleeAttackStrategy(), new MeleeAttackStrategy());

        Assert.True(hero.IsAlive);
        Assert.False(goblin.IsAlive);
        Assert.Contains(log, entry => entry.Contains("is defeated"));
    }

    [Fact]
    public void SpellAttackStrategy_Should_Do_More_Damage_Than_Melee_When_Using_Staff()
    {
        var mage = new PlayerCharacter("Lira", "Mage", health: 30, attackPower: 5, defense: 2);
        mage.EquipWeapon(WeaponFactory.CreateStaff());

        var skeleton = EnemyFactory.CreateSkeletonArcher();
        skeleton.EquipWeapon(WeaponFactory.CreateBow());

        var meleeResult = new MeleeAttackStrategy().Execute(mage, skeleton);
        var spellResult = new SpellAttackStrategy().Execute(mage, skeleton);

        Assert.True(spellResult.Damage >= meleeResult.Damage);
        Assert.Contains("casts a spell", spellResult.Description);
    }

    [Fact]
    public void Party_Should_Support_Indexer_And_Addition_Operators()
    {
        var hero = new PlayerCharacter("Kira", "Rogue", health: 38, attackPower: 7, defense: 3);
        var ally = new PlayerCharacter("Taro", "Archer", health: 34, attackPower: 6, defense: 2);

        var party = new Party();
        party += hero;
        party += ally;

        Assert.Equal(2, party.Count);
        Assert.Equal(hero, party[0]);
        Assert.Equal(ally, party[1]);
        Assert.Equal("Kira, Taro", party.ToString());
    }

    [Fact]
    public void Parties_With_Same_Members_Should_Be_Equal()
    {
        var hero = new PlayerCharacter("Ilya", "Cleric", health: 40, attackPower: 5, defense: 4);
        var ally = new PlayerCharacter("Mira", "Mage", health: 32, attackPower: 6, defense: 2);

        var first = new Party();
        first += hero;
        first += ally;

        var second = new Party();
        second += hero;
        second += ally;

        Assert.True(first == second);
        Assert.False(first != second);
    }
}
