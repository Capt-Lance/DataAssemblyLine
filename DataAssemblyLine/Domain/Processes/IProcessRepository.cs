using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAssemblyLine.Domain.Processes
{
    public interface IProcessRepository<T> where T : Process
    {
        Task<IEnumerable<T>> GetAllAsync();
    }
}
