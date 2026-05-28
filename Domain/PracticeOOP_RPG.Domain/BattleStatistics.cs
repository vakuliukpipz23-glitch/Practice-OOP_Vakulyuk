namespace PracticeOOP_RPG.Domain;

public sealed class BattleStatistics
{
    public int Turns { get; private set; }
    public int TotalDamageDealt { get; private set; }
    public int TotalDamageTaken { get; private set; }
    public int AbilitiesUsed { get; private set; }
    public int EnemiesDefeated { get; private set; }

    public void RecordTurn() => Turns++;

    public void RecordDamageDealt(int amount)
    {
        if (amount > 0)
        {
            TotalDamageDealt += amount;
        }
    }

    public void RecordDamageTaken(int amount)
    {
        if (amount > 0)
        {
            TotalDamageTaken += amount;
        }
    }

    public void RecordAbilityUsed() => AbilitiesUsed++;

    public void RecordEnemyDefeated() => EnemiesDefeated++;
}
