using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Components.Grids
{
    internal static class DataTableHelpers
    {
        public static IEnumerable<PropertyInfo> GetItemsPropertyInfo<TItem>()
            => typeof(TItem)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(x => x.CanRead);
    }    
}