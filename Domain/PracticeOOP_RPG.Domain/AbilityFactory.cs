namespace PracticeOOP_RPG.Domain;

public static class AbilityFactory
{
    public static Ability CreateHeavyStrike()
        => new(
            name: "Heavy Strike",
            description: "Міцна атака, яка завдає додатковий урон.",
            manaCost: 0,
            attackStrategy: new HeavyStrikeStrategy(),
            healAmount: 0);

    public static Ability CreateArcaneBlast()
        => new(
            name: "Arcane Blast",
            description: "Магічний вибух, що наносить великий уривок шкоди.",
            manaCost: 5,
            attackStrategy: new SpellAttackStrategy(),
            healAmount: 0);

    public static Ability CreateHealingLight()
        => new(
            name: "Healing Light",
            description: "Відновлює здоров'я союзнику.",
            manaCost: 8,
            attackStrategy: null,
            healAmount: 18);
}
