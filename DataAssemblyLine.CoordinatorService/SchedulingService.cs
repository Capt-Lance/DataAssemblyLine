using DataAssemblyLine.Application.Process;
using DataAssemblyLine.Application.Process.Handlers;
using DataAssemblyLine.CoordinatorService.Jobs;
using DataAssemblyLine.Domain.Items;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Impl;
using System;
using System.Threading.Tasks;

namespace DataAssemblyLine.CoordinatorService
{
    public class SchedulingService
    {
        private IScheduler _scheduler;
        private ISchedulerFactory _schedulerFactory;
        public async Task StartAsync()
        {
            Console.WriteLine("hi");
            _schedulerFactory = new StdSchedulerFactory();
            _scheduler = await _schedulerFactory.GetScheduler();
            var services = new ServiceCollection();
            services.AddSingleton<IProcessService, ProcessService>();
            services.AddTransient<IItemRepository, FakeItemRepository>();
            services.AddTransient<RunProcessJob>();
            services.AddMediatR(typeof(HttpStepExecutedHandler).Assembly);
            //services.AddTransient<DataRetrievalJob>();
            //services.AddTransient<EFEmployeeRepository>();
            var container = services.BuildServiceProvider();
            var jobFactory = new JobFactory(container);
            _scheduler.JobFactory = jobFactory;
            await _scheduler.Start();

            await CreateJobs();
        }

        public void StopAsync()
        {
            // noop
        }

        private async Task CreateJobs()
        {
            IJobDetail dataRetrievalJob = JobBuilder
                .Create<RunProcessJob>()
                .WithIdentity("job1", "group1")
                .Build();

            ITrigger dataRetrievalJobTrigger = TriggerBuilder.Create()
                .WithIdentity("trigger1", "group1")
                .WithCronSchedule("0/1 * * ? * * *")
                .Build();

            await _scheduler.ScheduleJob(dataRetrievalJob, dataRetrievalJobTrigger);
        }
    }
}