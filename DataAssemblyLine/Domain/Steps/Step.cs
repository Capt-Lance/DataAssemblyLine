using DataAssemblyLine.Domain.Common;
using DataAssemblyLine.Domain.Items;
using System.Threading.Tasks;

namespace DataAssemblyLine.Domain.Steps
{
    public abstract class Step: AggregateRoot
    {
        public int Id { get; private set; }
        public string Label { get; private set; }
        public Step NextStep { get; private set; }

        /// <summary>
        /// Only so EFCore can work properly
        /// </summary>
        protected Step() { }
        public Step(string label, Step nextStep)
        {
            Label = label;
            NextStep = nextStep;
        }

        public Step(string label)
        {
            Label = label;
        }
    }
}
