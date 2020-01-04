using DataAssemblyLine.Domain.Processes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAssemblyLine.Infrastructure.EFCore.Processes
{
    public class ItemProcessRepository : IProcessRepository<ItemProcess>
    {
        private readonly DataAssemblyLineContext context;

        public ItemProcessRepository(DataAssemblyLineContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<ItemProcess>> GetAllAsync()
        {
            return await context.Set<ItemProcess>().Include(itemProcesses => itemProcesses.Steps).ToListAsync();

        }
    }
}
