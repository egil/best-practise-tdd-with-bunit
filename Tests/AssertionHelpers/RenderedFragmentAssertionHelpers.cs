using System.Collections.Generic;
using System.Linq;
using Bunit;
using Components.DataTables;

namespace Tests
{
    public static class RenderedFragmentAssertionHelpers
    {
        public static IEnumerable<TItem> FindItemsAssignedToRows<TItem>(this IRenderedFragment cut)
            => cut.FindComponents<DataTableRow<TItem>>()
                  .Select(x => x.Instance.Item);

    }
}
