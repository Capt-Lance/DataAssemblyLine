using DataAssemblyLine.Domain.Items;
using DataAssemblyLine.Domain.Steps;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAssemblyLine.Application.Process.CommandRepositories
{
    public interface IExecuteStepCommandFactory
    {
        public IExecuteStepCommand BuildExecuteStepCommand(Step step, Item item);
    }
}
