using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAssemblyLine.Domain.Items;

namespace DataAssemblyLine.Domain.Steps
{
    public class HttpStep : Step
    {
        public string BodyTemplate { get; private set; }
        public string HttpMethod { get; private set; }
        public string Url { get; private set; }

        private HttpStep(string label, Step nextStep, string bodyTemplate, string httpMethod, string url) : base(label, nextStep) 
        {
            BodyTemplate = bodyTemplate;
            HttpMethod = httpMethod;
            Url = url;
        }

        public static HttpStep CreateGetStep(string label, Step nextStep, string url)
        {
            return new HttpStep(label, nextStep, null, "GET", url);
        }



    }
}
