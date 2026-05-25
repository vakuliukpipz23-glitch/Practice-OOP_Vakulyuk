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
}
