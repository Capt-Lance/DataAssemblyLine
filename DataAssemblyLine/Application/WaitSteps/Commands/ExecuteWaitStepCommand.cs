using DataAssemblyLine.Domain.Items;
using DataAssemblyLine.Domain.Steps;

namespace DataAssemblyLine.Application.WaitSteps.Commands
{
    public class ExecuteWaitStepCommand : IExecuteStepCommand
    {
        public Item Item { get; }
        public WaitStep Step { get; }
        
        public ExecuteWaitStepCommand(Item item, WaitStep waitStep)
        {
            Item = item;
            Step = waitStep;
        } 
    }
}
