namespace FastAcademy.Shared.Extensions;

public static class LinqExtensions
{
    public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> input)
        => input.Select((item, index) => (item, index));
    
    public static IQueryable<T> Paging<T>(this IQueryable<T> query, int pageIndex, int pageSize)
        => query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
}