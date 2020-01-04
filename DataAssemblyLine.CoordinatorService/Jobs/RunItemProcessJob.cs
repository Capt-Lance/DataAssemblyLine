using DataAssemblyLine.Application;
using DataAssemblyLine.Domain.Items;
using DataAssemblyLine.Domain.Processes;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DataAssemblyLine.CoordinatorService.Jobs
{
    [DisallowConcurrentExecution]
    public class RunItemProcessJob : IJob, IDisposable
    {
        private readonly IProcessService<ItemProcess> processService;
        private readonly IItemRepository itemRepository;
        private readonly IProcessRepository<ItemProcess> itemProcessRepository;
        public RunItemProcessJob(IProcessService<ItemProcess> processService)
        {
            this.processService = processService;
        }

        public void Dispose()
        {
        }

        public async Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Hello from the DataRetrievalJob");
            try
            {
                var itemProcessesIEnum = await itemProcessRepository.GetAllAsync();
                List<ItemProcess> itemProcesses = itemProcessesIEnum.ToList();

                // instead of directly processing them, maybe trigger event or use mediator 
                Task[] runProccessTasks = new Task[itemProcesses.Count];
                for(int i = 0; i < itemProcesses.Count; i++)
                {
                    runProccessTasks[i] = RunProcessAsync(itemProcesses[i]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


        private async Task RunProcessAsync(ItemProcess itemProcess)
        {
            var itemsIEnum = await itemRepository.GetNonStartedItemsByProcessIdAsync(itemProcess.Id);
            var items = itemsIEnum.ToList();
            Task[] tasks = new Task[items.Count];
            for(int i = 0; i < items.Count; i++)
            {
                tasks[i] = processService.ProcessPendingItemAsync(itemProcess, items[i], new CancellationToken());
            }
            await Task.WhenAll(tasks);

        }

    }
}
