using DataAssemblyLine.Domain.Common;
using DataAssemblyLine.Domain.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAssemblyLine.Domain.Processes
{
    public abstract class Process: AggregateRoot
    {
        private List<Step> steps;

        protected Process() { }

        public Process(string description, string label, int maxItemsToProcess, IEnumerable<Step> steps)
        {
            Description = description;
            Label = label;
            MaxItemsToProcess = maxItemsToProcess;
            //Steps = steps;
            //if (Steps.Count() > 0)
            //{
            //    FirstStep = this.steps[0];
            //}
            FirstStep = steps.ToList()[0];
            
        }


        public string Description { get; private set; }
        public Step FirstStep { get; private set; }

        public int Id { get; private set; }

        public string Label { get; private set; }

        public int MaxItemsToProcess { get; private set; }

        public IEnumerable<Step> Steps
        {
            get
            {
                return steps.AsReadOnly();
            }
            private set 
            { 
                steps = value.ToList(); 
            }
        }
    }
}
