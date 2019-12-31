using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAssemblyLine.Domain.Items
{
    public interface IItemRepository
    {
        public Task<IEnumerable<Item>> GetItemsAsync();
        public Task SaveAsync(Item item);
    }
}
