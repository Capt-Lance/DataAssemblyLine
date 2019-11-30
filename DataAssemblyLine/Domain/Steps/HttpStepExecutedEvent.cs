using DataAssemblyLine.Domain.Items;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAssemblyLine.Domain.Steps
{
    public class HttpStepExecutedEvent : INotification
    {
        public readonly Item Item;
        public readonly string HttpMethod;
        public readonly string BodyTemplate;

        public HttpStepExecutedEvent(Item item, string httpMethod, string bodyTemplate)
        {
            Item = item;
            HttpMethod = httpMethod;
            BodyTemplate = bodyTemplate;
        }
    }
}
