using DataAssemblyLine.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAssemblyLine.Domain.Steps
{
    public abstract class Step: AggregateRoot
    {
        public string Label { get; private set; }
        public Step NextStep { get; private set; }
    }
}
