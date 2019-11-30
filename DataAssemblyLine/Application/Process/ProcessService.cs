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
        public ProcessService(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task ProcessItemAsync(Item item)
        {
            if (item.LastCompletedStep == null)
            {
                await mediator.Publish(item.FirstStep.Execute(item));
            }
        }
    }
}
