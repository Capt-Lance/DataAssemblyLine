using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DataAssemblyLine.Application.CommandRepositories;
using DataAssemblyLine.Domain.Items;
using DataAssemblyLine.Domain.Processes;
using DataAssemblyLine.Domain.Steps;
using MediatR;

namespace DataAssemblyLine.Application
{
    public class ItemProcessService : IProcessService<ItemProcess>
    {
        private readonly IMediator mediator;
        private readonly IItemRepository itemRepository;
        private readonly IExecuteStepCommandFactory executeStepCommandFactory;
        public ItemProcessService(IMediator mediator, IItemRepository itemRepository, IExecuteStepCommandFactory executeStepCommandRepository)
        {
            this.mediator = mediator;
            this.itemRepository = itemRepository;
            this.executeStepCommandFactory = executeStepCommandRepository;
        }

        public async Task ProcessPendingItemAsync(ItemProcess process, Item item, CancellationToken cancellationToken)
        {
            while (item.IsPending && !cancellationToken.IsCancellationRequested)
            {
                await ExecuteNextStepAsync(process, item).ConfigureAwait(false);
            }
        }

        private async Task ExecuteNextStepAsync(ItemProcess process, Item item)
        {
            //Step nextStep = item.GetNextStep();
            Step nextStep = process.GetNextStep(item);
            IExecuteStepCommand executeStepCommand = executeStepCommandFactory.BuildExecuteStepCommand(nextStep, item);
            await mediator.Send(executeStepCommand).ConfigureAwait(false);
            await itemRepository.SaveAsync();
        }
    }
}
