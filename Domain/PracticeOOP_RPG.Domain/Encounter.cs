namespace PracticeOOP_RPG.Domain;

public sealed class Encounter
{
    private readonly List<Character> _enemies = new();

    public Party PlayerParty { get; }
    public IReadOnlyList<Character> Enemies => _enemies.AsReadOnly();

    public Encounter(Party playerParty)
    {
        PlayerParty = playerParty ?? throw new ArgumentNullException(nameof(playerParty));
    }

    public void AddEnemy(Character enemy)
    {
        if (enemy == null) throw new ArgumentNullException(nameof(enemy));
        _enemies.Add(enemy);
    }

    public IEnumerable<Character> GetAlivePlayers() => PlayerParty.GetAliveMembers();

    public IEnumerable<Character> GetAliveEnemies() => _enemies.Where(enemy => enemy.IsAlive);
}
