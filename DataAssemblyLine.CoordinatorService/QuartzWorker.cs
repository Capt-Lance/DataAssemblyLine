using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAssemblyLine.Application;
using DataAssemblyLine.Application.CommandRepositories;
using DataAssemblyLine.Application.HttpSteps.Handlers;
using DataAssemblyLine.CoordinatorService.Jobs;
using DataAssemblyLine.Domain.Items;
using DataAssemblyLine.Domain.Processes;
using DataAssemblyLine.Infrastructure.EFCore;
using DataAssemblyLine.Infrastructure.EFCore.Processes;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Quartz;
using Quartz.Impl;

namespace DataAssemblyLine.CoordinatorService
{
    public class QuartzWorker : BackgroundService
    {
        private readonly ILogger<QuartzWorker> _logger;
        private readonly IConfiguration configuration;
        private IScheduler _scheduler;
        private ISchedulerFactory _schedulerFactory;
        public QuartzWorker(ILogger<QuartzWorker> logger)
        {
            _logger = logger;
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            configuration = builder.Build();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("hi");
            _schedulerFactory = new StdSchedulerFactory();
            _scheduler = await _schedulerFactory.GetScheduler();
            var services = new ServiceCollection();
            ConfigureServices(services);

            var container = services.BuildServiceProvider();
            var jobFactory = new JobFactory(container);
            _scheduler.JobFactory = jobFactory;
            await _scheduler.Start();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddDbContext<DataAssemblyLineContext>(options => options.UseSqlServer(configuration.GetConnectionString("DataAssemblyLineConnectionString")));
            services.AddSingleton<IProcessService<ItemProcess>, ItemProcessService>();
            services.AddSingleton<IExecuteStepCommandFactory, ExecuteStepCommandFactory>();
            services.AddTransient<IItemRepository, ItemRepository>();
            services.AddTransient<IProcessRepository<ItemProcess>, ItemProcessRepository>();
            services.AddTransient<RunItemProcessJob>();
            services.AddMediatR(typeof(ExecuteHttpStepCommandHandler).Assembly);
            //services.AddTransient<DataRetrievalJob>();
            //services.AddTransient<EFEmployeeRepository>();
        }
    }
}
