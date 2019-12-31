using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAssemblyLine.Application.Process.CommandRepositories;
using DataAssemblyLine.Domain.Items;
using DataAssemblyLine.Domain.Steps;
using MediatR;

namespace DataAssemblyLine.Application.Process
{
    public class ProcessService : IProcessService
    {
        private readonly IMediator mediator;
        private readonly IItemRepository itemRepository;
        private readonly IExecuteStepCommandFactory executeStepCommandFactory;
        public ProcessService(IMediator mediator, IItemRepository itemRepository, IExecuteStepCommandFactory executeStepCommandRepository)
        {
            this.mediator = mediator;
            this.itemRepository = itemRepository;
            this.executeStepCommandFactory = executeStepCommandRepository;
        }

        public async Task<IEnumerable<Item>> GetUnprocessedItemsAsync()
        {
            var items = await itemRepository.GetItemsAsync();
            return items;
        }

        public async Task ProcessPendingItemAsync(Item item, CancellationToken cancellationToken)
        {
            while (item.IsPending() && cancellationToken.IsCancellationRequested)
            {
                await ProcessItemAsync(item);
            }
        }

        private async Task ProcessItemAsync(Item item)
        {
            Step nextStep = item.GetNextStep();
            IExecuteStepCommand executeStepCommand = executeStepCommandFactory.BuildExecuteStepCommand(nextStep, item);
            await mediator.Send(executeStepCommand);

        }
    }
}
