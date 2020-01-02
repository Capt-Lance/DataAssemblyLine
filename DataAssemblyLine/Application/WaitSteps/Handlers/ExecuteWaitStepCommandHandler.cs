using DataAssemblyLine.Application.WaitSteps.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DataAssemblyLine.Application.WaitSteps.Handlers
{
    public class ExecuteWaitStepCommandHandler : IRequestHandler<ExecuteWaitStepCommand>
    {
        public async Task<Unit> Handle(ExecuteWaitStepCommand notification, CancellationToken cancellationToken)
        {
            await Task.Delay(notification.Step.TimeToWaitInSeconds * 1000, cancellationToken);
            return Unit.Value;
        }
    }
}