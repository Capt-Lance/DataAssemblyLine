using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAssemblyLine.Domain.Items
{
    public interface IItemRepository
    {
        public Task<IEnumerable<Item>> GetNonStartedItemsByProcessIdAsync(int processId);

        public Task AddAsync(Item item);
        public Task SaveAsync();
    }
}
