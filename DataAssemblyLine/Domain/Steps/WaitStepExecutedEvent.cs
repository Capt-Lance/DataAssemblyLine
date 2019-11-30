using DataAssemblyLine.Domain.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAssemblyLine.Domain.Steps
{
    public class WaitStepExecutedEvent
    {
        readonly Item Item;
        readonly int TimeToWait;
        
        public WaitStepExecutedEvent(Item item, int timeToWait)
        {
            Item = item;
            TimeToWait = timeToWait;
        } 
    }
}
