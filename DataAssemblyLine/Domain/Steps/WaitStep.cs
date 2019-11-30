using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAssemblyLine.Domain.Items;

namespace DataAssemblyLine.Domain.Steps
{
    public class WaitStep: Step
    {
        public int TimeToWait { get; set; }

        public override IStepExecutedEvent Execute(Item item)
        {
            return new WaitStepExecutedEvent(item, TimeToWait);
        }
    }
}
