namespace Question2_HealthSystem;

public class Repository<T>
{
    private readonly List<T> items = new();
    public void Add(T item) => items.Add(item);
    public List<T> GetAll() => new(items);
    public T? GetById(Func<T, bool> predicate) => items.FirstOrDefault(predicate);
    public bool Remove(Func<T, bool> predicate)
    {
        var toRemove = items.FirstOrDefault(predicate);
        if (toRemove is null) return false;
        return items.Remove(toRemove);
    }
}
