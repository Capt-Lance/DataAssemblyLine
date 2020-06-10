using DataAssemblyLine.Domain.Steps;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAssemblyLine.Domain.Processes
{
    public class ScheduledProcess : Process
    {
        public ScheduledProcess(string description, string label, int maxItemsToProcess, IEnumerable<Step> steps) : base(description, label, maxItemsToProcess, steps)
        {
        }
    }
}
