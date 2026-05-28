namespace PracticeOOP_RPG.Domain;

public static class EnumerableExtensions
{
    public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (action == null) throw new ArgumentNullException(nameof(action));

        foreach (var item in source)
        {
            action(item);
        }
    }

    public static IEnumerable<TResult> Map<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (selector == null) throw new ArgumentNullException(nameof(selector));

        foreach (var item in source)
        {
            yield return selector(item);
        }
    }

    public static TResult Reduce<TSource, TResult>(this IEnumerable<TSource> source, TResult seed, Func<TResult, TSource, TResult> aggregator)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (aggregator == null) throw new ArgumentNullException(nameof(aggregator));

        var result = seed;
        foreach (var item in source)
        {
            result = aggregator(result, item);
        }

        return result;
    }
}
