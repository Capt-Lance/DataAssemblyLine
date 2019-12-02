using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAssemblyLine.Domain.Items;
using MediatR;

namespace DataAssemblyLine.Application.Process
{
    public class ProcessService : IProcessService
    {
        private readonly IMediator mediator;
        private readonly IItemRepository itemRepository;
        public ProcessService(IMediator mediator, IItemRepository itemRepository)
        {
            this.mediator = mediator;
            this.itemRepository = itemRepository;
        }

        public async Task<IEnumerable<Item>> GetUnprocessedItemsAsync()
        {
            var items = await itemRepository.GetItemsAsync();
            return items;
        }

        public async Task ProcessItemAsync(Item item)
        {
            if (item.LastCompletedStep == null)
            {
                string result = await mediator.Send(item.FirstStep.Execute(item));
            }
        }
    }
}
