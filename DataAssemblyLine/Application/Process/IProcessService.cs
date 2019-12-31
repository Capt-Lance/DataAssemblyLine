using DataAssemblyLine.Domain;
using DataAssemblyLine.Domain.Items;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataAssemblyLine.Application.Process
{
    public interface IProcessService
    {
        public Task ProcessPendingItemAsync(Item item, CancellationToken cancellationToken);

        public Task<IEnumerable<Item>> GetUnprocessedItemsAsync();
    }
}
