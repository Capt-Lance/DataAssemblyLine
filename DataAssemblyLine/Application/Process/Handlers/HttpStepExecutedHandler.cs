using DataAssemblyLine.Domain.Steps;
using MediatR;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataAssemblyLine.Application.Process.Handlers
{
    public class HttpStepExecutedHandler : IRequestHandler<HttpStepExecutedEvent, string>
    {
        public async Task<string> Handle(HttpStepExecutedEvent notification, CancellationToken cancellationToken)
        {
            HttpClient httpClient = new HttpClient();
            var result = await httpClient.GetAsync("https://google.com");
            if (result.IsSuccessStatusCode)
            {
                string data = await result.Content.ReadAsStringAsync();
                return data;
            }
            throw new NotImplementedException();
        }
    }
}
