using DataAssemblyLine.Domain.Items;
using DataAssemblyLine.Domain.Processes;
using DataAssemblyLine.Domain.Steps;
using Microsoft.EntityFrameworkCore;

namespace DataAssemblyLine.Infrastructure.EFCore
{
    public class DataAssemblyLineContext : DbContext
    {
        public DbSet<Item> Items { get; private set; }
        public DbSet<ItemProcess> ItemProcesses { get; set; }
        public DbSet<Process> Processes { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<HttpStep> HttpSteps { get; set; }
        public DbSet<WaitStep> WaitSteps { get; set; }

        public DataAssemblyLineContext(DbContextOptions<DataAssemblyLineContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().Ignore(i => i.DomainEvents);
            modelBuilder.Entity<Item>()
                .HasOne<Process>()
                .WithMany()
                .HasForeignKey(i => i.ProcessId);
            modelBuilder.Entity<Process>().Ignore(i => i.DomainEvents);
            modelBuilder.Entity<Step>().Ignore(s => s.DomainEvents);
        }
    }
}
