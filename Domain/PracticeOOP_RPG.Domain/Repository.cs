namespace PracticeOOP_RPG.Domain;

public sealed class Repository<T> : IRepository<T> where T : class
{
    private readonly List<T> _items = new();

    public void Add(T item)
    {
        if (item == null) throw new ArgumentNullException(nameof(item));
        _items.Add(item);
    }

    public bool Remove(T item)
    {
        if (item == null) throw new ArgumentNullException(nameof(item));
        return _items.Remove(item);
    }

    public IEnumerable<T> GetAll() => _items.AsReadOnly();

    public T? Find(Func<T, bool> predicate)
    {
        if (predicate == null) throw new ArgumentNullException(nameof(predicate));
        return _items.FirstOrDefault(predicate);
    }
}
