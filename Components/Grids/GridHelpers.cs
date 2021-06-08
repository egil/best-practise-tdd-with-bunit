using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Components.Grids
{
    internal static class GridHelpers
    {
        public static IEnumerable<PropertyInfo> GetGridColumns<TItem>()
            => typeof(TItem)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(x => x.CanRead);
    }    
}