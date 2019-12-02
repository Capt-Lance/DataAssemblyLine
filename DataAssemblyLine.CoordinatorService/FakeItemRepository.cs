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
        public Task<IEnumerable<Item>> GetItemsAsync()
        {
            List<Item> items = new List<Item>();
            Item item = Item.CreateNew(new HttpStep());
            items.Add(item);
            return Task.FromResult(items as IEnumerable<Item>);
        }
    }
}
