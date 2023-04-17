namespace IngetMori.Persistence.Extensions;
internal static class LinqExtensions
{
    internal static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (action == null) throw new ArgumentNullException(nameof(action));

        foreach (T item in source) { action(item); }
    }
}
