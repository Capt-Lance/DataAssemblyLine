using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAssemblyLine.Domain.Processes;
using DataAssemblyLine.Domain.Steps;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ItemApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemProcessesController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ItemProcessesController> logger;
        private readonly IProcessRepository<ItemProcess> itemProcessRepository;

        public ItemProcessesController(IProcessRepository<ItemProcess> itemProcessRepository, ILogger<ItemProcessesController> logger)
        {
            this.logger = logger;
            this.itemProcessRepository = itemProcessRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            HttpStep httpStep = HttpStep.CreateGetStep("label", null, "https://google.com");
            ItemProcess itemProcess = new ItemProcess("desc", "label", 1, new List<Step>() { httpStep });
            await itemProcessRepository.AddAsync(itemProcess);
            await itemProcessRepository.SaveAsync();
            return Ok();
        }
    }
}
