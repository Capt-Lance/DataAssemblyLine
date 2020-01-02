using DataAssemblyLine.Domain.Items;
using DataAssemblyLine.Domain.Steps;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAssemblyLine.CoordinatorService
{
    public class FakeItemRepository : IItemRepository
    {
        private List<Item> items;
        public FakeItemRepository()
        {
            items.Add(Item.CreateNew());
        }
        public Task<IEnumerable<Item>> GetItemsAsync()
        {
            //List<Item> items = new List<Item>();
            //Step lastStep = new WaitStep("wait 5s", null, 5);
            //Step firstStep = HttpStep.CreateGetStep("get google.com", lastStep, "https://google.com");
            Item item = Item.CreateNew();
            //items.Add(item);
            return Task.FromResult(items as IEnumerable<Item>);
        }

        public Task SaveAsync(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
