namespace PracticeOOP_RPG.Domain;

public sealed class InvalidCharacterStateException : GameDomainException
{
    public InvalidCharacterStateException()
    {
    }

    public InvalidCharacterStateException(string message)
        : base(message)
    {
    }
}
