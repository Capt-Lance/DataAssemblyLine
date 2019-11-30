using DataAssemblyLine.Domain.Items;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAssemblyLine.Domain.Steps
{
    public class WaitStepExecutedEvent : INotification
    {
        public Item Item { get; }
        public int TimeToWait { get; }
        
        public WaitStepExecutedEvent(Item item, int timeToWait)
        {
            Item = item;
            TimeToWait = timeToWait;
        } 
    }
}
