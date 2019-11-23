using DataAssemblyLine.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAssemblyLine.Domain
{
    public abstract class Item<T>: Entity
    {
        public T InitialData { get; private set; }
        public T CurrentData { get; private set; }
    }
}
