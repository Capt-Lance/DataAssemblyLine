using DataAssemblyLine.Domain.Steps;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAssemblyLine.Domain.Processes
{
    public class Process
    {
        public string Label { get; private set; }
        public string Description { get; private set; }
        public Step FirstStep { get; private set; }
    }
}
