namespace PracticeOOP_RPG.Domain;

public interface IRepository<T> where T : class
{
    void Add(T item);
    bool Remove(T item);
    IEnumerable<T> GetAll();
    T? Find(Func<T, bool> predicate);
}
