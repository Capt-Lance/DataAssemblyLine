using DataAssemblyLine.Domain.Items;
using DataAssemblyLine.Domain.Steps;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAssemblyLine.Domain.Processes
{
    public class ItemProcess : Process
    {
        private ItemProcess(): base() { }
        public ItemProcess(string description, string label, int maxItemsToProcess, IEnumerable<Step> steps): base(description, label, maxItemsToProcess, steps)
        {
        }

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
