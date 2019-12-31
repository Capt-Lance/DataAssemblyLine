using DataAssemblyLine.Domain.Steps;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAssemblyLine.Application.Process.CommandRepositories
{
    public class ExecuteStepCommandFactory : IExecuteStepCommandFactory
    {
        public IExecuteStepCommand GetExecuteStepCommand(Step step)
        {
            throw new NotImplementedException();
        }
    }
}
