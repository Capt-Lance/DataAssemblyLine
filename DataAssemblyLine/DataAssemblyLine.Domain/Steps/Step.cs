using DataAssemblyLine.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAssemblyLine.Domain.Steps
{
    public abstract class Step: Entity
    {
        public Step NextStep { get; private set; }
        public string Label { get; private set; }
    }
}
