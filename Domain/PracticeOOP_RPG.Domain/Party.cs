namespace PracticeOOP_RPG.Domain;

public sealed class Party : IEnumerable<Character>
{
    private readonly List<Character> _members = new();

    public int Count => _members.Count;

    public Character this[int index]
    {
        get
        {
            if (index < 0 || index >= _members.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            return _members[index];
        }
    }

    public void Add(Character character)
    {
        if (character == null) throw new ArgumentNullException(nameof(character));
        if (_members.Contains(character)) return;

        _members.Add(character);
    }

    public bool Remove(Character character)
    {
        if (character == null) throw new ArgumentNullException(nameof(character));
        return _members.Remove(character);
    }

    public static Party operator +(Party? party, Character character)
    {
        if (party == null) throw new ArgumentNullException(nameof(party));
        party.Add(character);
        return party;
    }

    public static Party operator +(Party? first, Party? second)
    {
        if (first == null) throw new ArgumentNullException(nameof(first));
        if (second == null) throw new ArgumentNullException(nameof(second));

        var result = new Party();
        foreach (var member in first._members)
        {
            result.Add(member);
        }

        foreach (var member in second._members)
        {
            result.Add(member);
        }

        return result;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Party other) return false;
        if (Count != other.Count) return false;
        return _members.SequenceEqual(other._members);
    }

    public override int GetHashCode()
    {
        var hash = new HashCode();
        foreach (var member in _members)
        {
            hash.Add(member);
        }

        return hash.ToHashCode();
    }

    public static bool operator ==(Party? left, Party? right)
    {
        if (ReferenceEquals(left, right)) return true;
        if (left is null || right is null) return false;
        return left.Equals(right);
    }

    public static bool operator !=(Party? left, Party? right) => !(left == right);

    public IEnumerable<Character> GetAliveMembers() => _members.Where(member => member.IsAlive);

    public IEnumerator<Character> GetEnumerator() => _members.GetEnumerator();

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

    public override string ToString() => string.Join(", ", _members.Select(m => m.Name));
}
