using DataAssemblyLine.Application.HttpSteps.Commands;
using DataAssemblyLine.Application.WaitSteps.Commands;
using DataAssemblyLine.Domain.Items;
using DataAssemblyLine.Domain.Steps;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAssemblyLine.Application.CommandRepositories
{
    public class ExecuteStepCommandFactory : IExecuteStepCommandFactory
    {
        public IExecuteStepCommand BuildExecuteStepCommand(Step step, Item item)
        {
            IExecuteStepCommand executeStepCommand;
            if (step is HttpStep httpStep)
            {
                executeStepCommand = new ExecuteHttpStepCommand(item, httpStep);
                
            }
            else if (step is WaitStep waitStep)
            {
                executeStepCommand = new ExecuteWaitStepCommand(item, waitStep);
            }
            else
            {
                throw new NotImplementedException($"Building {step.GetType()} has not been implemented");
            }
            return executeStepCommand;
        }
    }
}
