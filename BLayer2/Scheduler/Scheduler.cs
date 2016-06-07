using BLayer.Front;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLayer.Scheduler
{
    public class Scheduler
    {
        static ISchedulerFactory schedFact;
        static IScheduler sched;
        public static IScheduler GetScheduler() {

            if (sched == null) {
                schedFact = new StdSchedulerFactory();
                // get a scheduler, start the schedular before triggers or anything else
                sched = schedFact.GetScheduler();
                sched.Start();
            }
            return sched;
        }

        public static void ScheduleInteraction(int interactionId, int time, string tenantId) {
            String jobId = interactionId.ToString();
            // create job
            IJobDetail job = JobBuilder.Create<InteractionEngine>()
                    .WithIdentity(jobId, jobId)
                    .UsingJobData("interactionId", interactionId.ToString())
                    .UsingJobData("tenantId", tenantId)
                    .Build();

            ISimpleTrigger trigger = (ISimpleTrigger)TriggerBuilder.Create()
            .WithIdentity(jobId, jobId)
            .StartAt(DateTime.Now.AddSeconds(time))  
            .ForJob(jobId, jobId)  
            .Build();

            GetScheduler().ScheduleJob(job, trigger);
        }
    }
}
