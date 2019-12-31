using DataAssemblyLine.Domain.Items;
using DataAssemblyLine.Domain.Steps;

namespace DataAssemblyLine.Application.Process.WaitSteps.Commands
{
    public class ExecuteWaitStepCommand : IExecuteStepCommand
    {
        public Item Item { get; }
        public int TimeToWaitInSeconds { get; }
        
        public ExecuteWaitStepCommand(Item item, WaitStep waitStep)
        {
            Item = item;
            TimeToWaitInSeconds = waitStep.TimeToWaitInSeconds;
        } 
    }
}
