using DataAssemblyLine.Domain.Steps;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataAssemblyLine.Application.Process.Handlers
{
    public class HttpStepExecutedHandler : INotificationHandler<HttpStepExecutedEvent>
    {
        public Task Handle(HttpStepExecutedEvent notification, CancellationToken cancellationToken)
        {
            
            throw new NotImplementedException();
        }
    }
}
