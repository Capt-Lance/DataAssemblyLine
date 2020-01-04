using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataAssemblyLine.Infrastructure.EFCore
{
    public class DataAssemblyLineContextFactory : IDesignTimeDbContextFactory<DataAssemblyLineContext>
    {
        public DataAssemblyLineContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataAssemblyLineContext>();
            optionsBuilder.UseSqlServer(@"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=DataAssemblyLine;Integrated Security=True");

            return new DataAssemblyLineContext(optionsBuilder.Options);
        }
    }
}
