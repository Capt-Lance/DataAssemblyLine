using DataAssemblyLine.Domain.Items;
using DataAssemblyLine.Domain.Steps;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAssemblyLine.Application.Process.HttpSteps.Commands
{
    public class ExecuteHttpStepCommand : IExecuteStepCommand
    {
        public Item Item { get; }
        public string HttpMethod { get; }
        public string BodyTemplate { get; }

        public ExecuteHttpStepCommand(Item item, HttpStep httpStep)
        {
            Item = item;
            HttpMethod = httpStep.HttpMethod;
            BodyTemplate = httpStep.BodyTemplate;
        }
    }
}
