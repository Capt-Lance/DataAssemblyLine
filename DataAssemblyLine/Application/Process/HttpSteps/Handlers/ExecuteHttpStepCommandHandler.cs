﻿using DataAssemblyLine.Application.Process.HttpSteps.Commands;
using MediatR;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DataAssemblyLine.Application.Process.HttpSteps.Handlers
{
    public class ExecuteHttpStepCommandHandler : IRequestHandler<ExecuteHttpStepCommand>
    {
        public async Task<Unit> Handle(ExecuteHttpStepCommand notification, CancellationToken cancellationToken)
        {
            HttpClient httpClient = new HttpClient();
            var result = await httpClient.GetAsync("https://google.com");
            if (result.IsSuccessStatusCode)
            {
                string data = await result.Content.ReadAsStringAsync();
            }
            else
            {
                notification.Item.SetStepFailed(result.ReasonPhrase);
            }
            return Unit.Value;
        }
    }
}