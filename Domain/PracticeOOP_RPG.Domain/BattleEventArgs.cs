namespace PracticeOOP_RPG.Domain;

public sealed class BattleEventArgs : EventArgs
{
    public string Message { get; }

    public BattleEventArgs(string message)
    {
        Message = message ?? string.Empty;
    }
}
