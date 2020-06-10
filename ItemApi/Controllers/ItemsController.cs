using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAssemblyLine.Domain.Items;
using DataAssemblyLine.Domain.Processes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ItemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ILogger<ItemsController> logger;
        private readonly IItemRepository itemRepository;

        public ItemsController(IItemRepository itemRepository, ILogger<ItemsController> logger)
        {
            this.logger = logger;
            this.itemRepository = itemRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            Item item = Item.CreateNew(1, null);
            await itemRepository.AddAsync(item);
            await itemRepository.SaveAsync();
            return Ok();
        }
    }
}
