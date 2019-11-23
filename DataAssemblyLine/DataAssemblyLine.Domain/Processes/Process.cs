using DataAssemblyLine.Domain.Clients;
using DataAssemblyLine.Domain.Common;
using DataAssemblyLine.Domain.Steps;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAssemblyLine.Domain.Processes
{
    public class Process: Entity
    {
        public string Label { get; private set; }
        public string Description { get; private set; }
        public Step FirstStep { get; private set; }
        public Client Client { get; private set; }
    }
}
