using DataAssemblyLine.Domain;
using DataAssemblyLine.Domain.Items;
using DataAssemblyLine.Domain.Processes;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataAssemblyLine.Application.Process
{
    public interface IProcessService
    {
        public Task ProcessPendingItemAsync(Process process, Item item, CancellationToken cancellationToken);

        public Task<IEnumerable<Item>> GetUnprocessedItemsAsync();
    }
}
