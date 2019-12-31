using DataAssemblyLine.Domain.Common;
using DataAssemblyLine.Domain.Steps;
using System;

namespace DataAssemblyLine.Domain.Items
{
    public class Item : AggregateRoot
    {
        public DateTime Created { get; set; }
        public string CurrentData { get; private set; }
        public string FailureMessage { get; private set; }

        //public Step FirstStep { get; private set; }
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

        public static Item CreateNew()
        {
            Item item = new Item();
            item.IsProcessed = false;
            item.IsFailed = false;
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