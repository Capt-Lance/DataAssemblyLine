using DataAssemblyLine.Domain.Common;
using DataAssemblyLine.Domain.Steps;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAssemblyLine.Domain.Processes
{
    public abstract class Process: AggregateRoot
    {
        public string Description { get; private set; }

        private List<Step> steps;
        public IEnumerable<Step> Steps
        {
            get
            {
                return steps.AsReadOnly();
            }
        }
        public Step FirstStep { get; private set; }
        public int Id { get; private set; }
        public string Label { get; private set; }
        public int MaxItemsToProcess { get; private set; }
    }
}
