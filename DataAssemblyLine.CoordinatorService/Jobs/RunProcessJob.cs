using DataAssemblyLine.Application.Process;
using DataAssemblyLine.Domain.Items;
using Quartz;
using System;
using System.Threading.Tasks;

namespace DataAssemblyLine.CoordinatorService.Jobs
{
    [DisallowConcurrentExecution]
    public class RunProcessJob : IJob, IDisposable
    {
        private IProcessService processService;
        public RunProcessJob(IProcessService processService)
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
                // get items to process
                var items = await processService.GetUnprocessedItemsAsync();

                // instead of directly processing them, maybe trigger event or use mediator 
                foreach (Item item in items)
                {
                    await processService.ProcessItemAsync(item);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

    }
}
