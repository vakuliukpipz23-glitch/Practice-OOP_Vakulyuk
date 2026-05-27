namespace PracticeOOP_RPG.Domain;

public sealed class Cache<TKey, TValue> where TKey : notnull
{
    private readonly Dictionary<TKey, TValue> _items = new();

    public bool TryGetValue(TKey key, out TValue value) => _items.TryGetValue(key, out value!);

    public TValue GetOrAdd(TKey key, Func<TKey, TValue> factory)
    {
        if (factory == null) throw new ArgumentNullException(nameof(factory));
        if (_items.TryGetValue(key, out var existing))
        {
            return existing;
        }

        var created = factory(key);
        _items[key] = created;
        return created;
    }

    public void Add(TKey key, TValue value)
    {
        if (key == null) throw new ArgumentNullException(nameof(key));
        _items[key] = value;
    }

    public bool Remove(TKey key) => _items.Remove(key);
}
