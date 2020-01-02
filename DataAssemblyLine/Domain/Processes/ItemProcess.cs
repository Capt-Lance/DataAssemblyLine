using DataAssemblyLine.Domain.Items;
using DataAssemblyLine.Domain.Steps;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAssemblyLine.Domain.Processes
{
    public class ItemProcess : Process
    {
        public Step GetNextStep(Item item)
        {
            if (item.IsStarted)
            {
                return item.LastCompletedStep;
            }
            return FirstStep;
        }
    }
}
