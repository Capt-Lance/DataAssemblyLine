using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAssemblyLine.Domain.Steps
{
    public interface IStepExecutedEvent : INotification
    {
    }
}
