using DataAssemblyLine.Domain.Items;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAssemblyLine.Infrastructure.EFCore.Processes
{
    public class ItemRepository : IItemRepository
    {
        public Task<IEnumerable<Item>> GetNonStartedItemsByProcessIdAsync(int processId)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
