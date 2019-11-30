using DataAssemblyLine.Domain.Items;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAssemblyLine.Domain.Steps
{
    public class HttpStepExecutedEvent : INotification
    {
        public Item Item { get; }
        public string HttpMethod { get; }
        public string BodyTemplate { get; }

        public HttpStepExecutedEvent(Item item, string httpMethod, string bodyTemplate)
        {
            Item = item;
            HttpMethod = httpMethod;
            BodyTemplate = bodyTemplate;
        }
    }
}
