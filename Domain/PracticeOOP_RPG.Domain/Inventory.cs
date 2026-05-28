namespace PracticeOOP_RPG.Domain;

public sealed class Inventory : IEnumerable<Item>
{
    private readonly List<Item> _items = new();

    public int Count => _items.Count;
    public double TotalWeight => _items.Sum(item => item.Weight);
    public int TotalValue => _items.Sum(item => item.Value);

    public Item this[int index]
    {
        get
        {
            if (index < 0 || index >= _items.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            return _items[index];
        }
    }

    public void Add(Item item)
    {
        if (item == null) throw new ArgumentNullException(nameof(item));
        _items.Add(item);
    }

    public bool Remove(Item item)
    {
        if (item == null) throw new ArgumentNullException(nameof(item));
        return _items.Remove(item);
    }

    public IEnumerable<Item> FindByName(string partialName)
    {
        if (partialName == null) throw new ArgumentNullException(nameof(partialName));
        return _items.Where(item => item.Name.Contains(partialName, StringComparison.OrdinalIgnoreCase));
    }

    public static Inventory operator +(Inventory inventory, Item item)
    {
        if (inventory == null) throw new ArgumentNullException(nameof(inventory));
        inventory.Add(item);
        return inventory;
    }

    public IEnumerator<Item> GetEnumerator() => _items.GetEnumerator();

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

    public override string ToString() => string.Join(", ", _items.Select(item => item.Name));
}
