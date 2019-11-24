using DataAssemblyLine.Domain.Common;
using DataAssemblyLine.Domain.Steps;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAssemblyLine.Domain
{
    public abstract class Item<T>: Entity
    {
        public DateTime Created { get; set; }
        public T CurrentData { get; private set; }
        public string FailureMessage { get; private set; }
        public T InitialData { get; private set; }
        public bool IsFailed { get; private set; }
        public bool IsProcessed { get; private set; }
        public Step LastCompletedStep { get; private set; }
        public DateTime Modified { get; set; }
        public void CompleteStep(Step stepCompleted, T data)
        {
            LastCompletedStep = stepCompleted;
            CurrentData = data;
            Modified = DateTime.UtcNow;
        }

        public void MarkAsFailure(string reason)
        {
            IsFailed = true;
            FailureMessage = reason;
        }

        public void MarkAsProcessed(Step stepCompleted, T data)
        {
            LastCompletedStep = stepCompleted;
            CurrentData = data;
            Modified = DateTime.UtcNow;
            IsProcessed = true;
        }
    }
}
