namespace PracticeOOP_RPG.Domain;

public sealed class Encounter
{
    private readonly List<List<Character>> _waves = new();
    private int _currentWaveIndex;

    public Party PlayerParty { get; }
    public int CurrentWaveNumber => _currentWaveIndex + 1;
    public int TotalWaves => _waves.Count;

    public Encounter(Party playerParty)
    {
        PlayerParty = playerParty ?? throw new ArgumentNullException(nameof(playerParty));
    }

    public void AddWave(params Character[] enemies)
    {
        if (enemies == null) throw new ArgumentNullException(nameof(enemies));
        if (enemies.Length == 0) return;
        _waves.Add(enemies.ToList());
    }

    public IEnumerable<Character> GetAlivePlayers() => PlayerParty.GetAliveMembers();

    public IReadOnlyList<Character> GetCurrentWaveEnemies() =>
        _currentWaveIndex < _waves.Count ? _waves[_currentWaveIndex].AsReadOnly() : Array.Empty<Character>();

    public IEnumerable<Character> GetAliveEnemies() => GetCurrentWaveEnemies().Where(enemy => enemy.IsAlive);

    public IEnumerable<Character> GetAllEnemies() => _waves.SelectMany(wave => wave);

    public bool IsCurrentWaveCleared() => !GetAliveEnemies().Any();

    public bool AdvanceWave()
    {
        if (!IsCurrentWaveCleared() || _currentWaveIndex + 1 >= _waves.Count)
        {
            return false;
        }

        _currentWaveIndex++;
        return true;
    }
}
