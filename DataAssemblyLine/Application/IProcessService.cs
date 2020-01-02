using DataAssemblyLine.Domain;
using DataAssemblyLine.Domain.Items;
using DataAssemblyLine.Domain.Processes;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataAssemblyLine.Application
{
    public interface IProcessService<T> where T : Process
    {
        public Task ProcessPendingItemAsync(T process, Item item, CancellationToken cancellationToken);

    }
}
