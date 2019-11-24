using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAssemblyLine.Domain.Steps
{
    public class HttpStep: Step
    {
        public string BodyTemplate { get; private set; }
        public string HttpMethod { get; private set; }
    }
}
