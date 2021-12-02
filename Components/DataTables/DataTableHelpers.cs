using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Components.DataTables;

internal static class DataTableHelpers
{
    public static IEnumerable<PropertyInfo> GetItemsPropertyInfo<TItem>()
        => typeof(TItem)
            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(x => x.CanRead);

    public static IEnumerable<TItem> SortBy<TItem>(this IEnumerable<TItem> items, (string ColumnName, bool Ascending) sortBy)
    {
        if (string.IsNullOrEmpty(sortBy.ColumnName))
        {
            return items;
        }

        var source = items.AsQueryable();
        var type = typeof(TItem);
        var property = type.GetProperty(sortBy.ColumnName);
        var parameter = Expression.Parameter(type, "p");
        var propertyAccess = Expression.MakeMemberAccess(parameter, property);
        var orderByExp = Expression.Lambda(propertyAccess, parameter);
        var typeArguments = new Type[] { type, property.PropertyType };
        var methodName = sortBy.Ascending ? "OrderBy" : "OrderByDescending";
        var resultExp = Expression.Call(typeof(Queryable), methodName, typeArguments, source.Expression, Expression.Quote(orderByExp));

        return source.Provider.CreateQuery<TItem>(resultExp);
    }
}    
