using DataAssemblyLine.Domain.Items;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAssemblyLine.Infrastructure.EFCore.Processes
{
    public class ItemRepository : IItemRepository
    {
        private readonly DataAssemblyLineContext context;
        public ItemRepository(DataAssemblyLineContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Item>> GetNonStartedItemsByProcessIdAsync(int processId)
        {
            return await context.Set<Item>().Where(x => !x.IsStarted && x.ProcessId == processId).ToListAsync();
        }

        public async Task SaveAsync(Item item)
        {
            await context.SaveChangesAsync();
        }
    }
}
