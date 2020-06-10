using DataAssemblyLine.Domain.Common;
using DataAssemblyLine.Domain.Steps;
using System;

namespace DataAssemblyLine.Domain.Items
{
    public class Item : AggregateRoot
    {
        private Item() { }
        public DateTime Created { get; set; }
        public string CurrentData { get; private set; }
        public string FailureMessage { get; private set; }
        public int Id { get; private set; }
        public string InitialData { get; private set; }

        public bool IsFailed { get; private set; }

        public bool IsPending
        {
            get
            {
                return !IsFailed && !IsProcessed;
            }
        }

        public bool IsProcessed { get; private set; }

        public bool IsStarted
        {
            get
            {
                return LastCompletedStep != null;
            }
        }

        public Step LastCompletedStep { get; private set; }
        public DateTime Modified { get; set; }
        public int ProcessId { get; private set; }

        public static Item CreateNew(int processId, string intialData)
        {
            Item item = new Item();
            item.IsProcessed = false;
            item.IsFailed = false;
            item.InitialData = intialData;
            item.ProcessId = processId;
            return item;
        }

        public void CompleteStep(Step stepCompleted, string data)
        {
            LastCompletedStep = stepCompleted;
            CurrentData = data;
            Modified = DateTime.UtcNow;
        }

        public void SetProcessCompleted(Step stepCompleted, string data)
        {
            LastCompletedStep = stepCompleted;
            CurrentData = data;
            Modified = DateTime.UtcNow;
            IsProcessed = true;
            AddDomainEvent(new ItemProcessedEvent());
        }

        public void SetStepCompleted(Step stepCompleted, string data)
        {
            LastCompletedStep = stepCompleted;
            CurrentData = data;
            Modified = DateTime.UtcNow;
            AddDomainEvent(new ItemStepCompletedEvent());
        }

        public void SetStepFailed(string reason)
        {
            IsFailed = true;
            FailureMessage = reason;
            AddDomainEvent(new ItemStepFailedEvent());
        }
    }
}