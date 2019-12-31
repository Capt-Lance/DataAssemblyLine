using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAssemblyLine.Domain.Items;

namespace DataAssemblyLine.Domain.Steps
{
    public class WaitStep: Step
    {
        public int TimeToWaitInSeconds { get; set; }

    }
}
