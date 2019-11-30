using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAssemblyLine.Domain.Items;

namespace DataAssemblyLine.Domain.Steps
{
    public class HttpStep: Step
    {
        public string BodyTemplate { get; private set; }
        public string HttpMethod { get; private set; }

        public override IStepExecutedEvent Execute(Item item)
        {
            return new HttpStepExecutedEvent(item, BodyTemplate, HttpMethod);
        }
    }
}
