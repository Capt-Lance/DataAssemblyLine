using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAssemblyLine.Domain.Items;

namespace DataAssemblyLine.Domain.Steps
{
    public class WaitStep: Step
    {
        public int TimeToWaitInSeconds { get; private set; }

        private WaitStep(): base()
        {

        }

        public WaitStep(string label, Step nextStep, int timeToWaitInSeconds): base(label, nextStep)
        {
            TimeToWaitInSeconds = timeToWaitInSeconds;
        }
    }
}
