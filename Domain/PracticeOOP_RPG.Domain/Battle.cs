namespace PracticeOOP_RPG.Domain;

public sealed class Battle
{
    private readonly Character _first;
    private readonly Character _second;

    public event EventHandler<BattleEventArgs>? BattleLog;

    public Battle(Character first, Character second)
    {
        _first = first ?? throw new ArgumentNullException(nameof(first));
        _second = second ?? throw new ArgumentNullException(nameof(second));
    }

    public void Start(IAttackStrategy firstStrategy, IAttackStrategy secondStrategy)
    {
        if (firstStrategy == null) throw new ArgumentNullException(nameof(firstStrategy));
        if (secondStrategy == null) throw new ArgumentNullException(nameof(secondStrategy));

        Character attacker = _first;
        Character defender = _second;
        IAttackStrategy strategy = firstStrategy;

        while (attacker.IsAlive && defender.IsAlive)
        {
            var result = attacker.Attack(defender, strategy);
            defender.ReceiveDamage(result.Damage);
            RaiseLog(result.Description);

            if (!defender.IsAlive)
            {
                RaiseLog($"{defender.Name} is defeated.");
                break;
            }

            (attacker, defender) = (defender, attacker);
            strategy = strategy == firstStrategy ? secondStrategy : firstStrategy;
        }
    }

    private void RaiseLog(string message)
    {
        BattleLog?.Invoke(this, new BattleEventArgs(message));
    }
}
