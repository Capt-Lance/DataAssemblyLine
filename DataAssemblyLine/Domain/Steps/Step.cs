using DataAssemblyLine.Domain.Common;
using DataAssemblyLine.Domain.Items;
using System.Threading.Tasks;

namespace DataAssemblyLine.Domain.Steps
{
    public abstract class Step: AggregateRoot
    {
        public string Label { get; private set; }
        public Step NextStep { get; private set; }
        public abstract void Execute(Item item);
    }
}
