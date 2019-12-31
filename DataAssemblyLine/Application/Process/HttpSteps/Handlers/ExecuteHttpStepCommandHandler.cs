using DataAssemblyLine.Application.Process.HttpSteps.Commands;
using DataAssemblyLine.Domain.Items;
using DataAssemblyLine.Domain.Steps;
using MediatR;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DataAssemblyLine.Application.Process.HttpSteps.Handlers
{
    public class ExecuteHttpStepCommandHandler : IRequestHandler<ExecuteHttpStepCommand>
    {
        public async Task<Unit> Handle(ExecuteHttpStepCommand executeHttpStepCommand, CancellationToken cancellationToken)
        {
            try
            {
                await RunStepAsync(executeHttpStepCommand);
            }
            catch (Exception ex)
            {
                executeHttpStepCommand.Item.SetStepFailed(ex.ToString());
            }

            return Unit.Value;
        }

        private async Task<HttpResponseMessage> MakeHttpRequestAsync(HttpStep step, Item item)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage httpResponseMessage = null;
            switch (step.HttpMethod)
            {
                case "GET":
                    {
                        httpResponseMessage = await httpClient.GetAsync(step.Url);
                        break;
                    }
                case "POST":
                    {
                        throw new NotImplementedException();
                    }
                case "DELETE":
                    {
                        throw new NotImplementedException();
                    }
                case "PATCH":
                    {
                        throw new NotImplementedException();
                    }
            }
            return httpResponseMessage;
        }

        private async Task RunStepAsync(ExecuteHttpStepCommand executeHttpStepCommand)
        {
            var result = await MakeHttpRequestAsync(executeHttpStepCommand.Step, executeHttpStepCommand.Item);
            if (result.IsSuccessStatusCode)
            {
                string data = await result.Content.ReadAsStringAsync();
            }
            else
            {
                executeHttpStepCommand.Item.SetStepFailed(result.ReasonPhrase);
            }
        }
    }
}