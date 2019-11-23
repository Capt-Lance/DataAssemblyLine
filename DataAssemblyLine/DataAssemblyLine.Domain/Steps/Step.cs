using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAssemblyLine.Domain.Steps
{
    public abstract class Step
    {
        public Step NextStep { get; private set; }
        public abstract Task RunAsync();
    }
}
