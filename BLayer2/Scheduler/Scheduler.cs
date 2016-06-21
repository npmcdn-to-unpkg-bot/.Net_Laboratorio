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
        static IScheduler sched;
        public static IScheduler GetScheduler() {

            if (sched == null) {
                // get a scheduler, start the schedular before triggers or anything else
                sched = new StdSchedulerFactory().GetScheduler();
                sched.Start();
            }
            return sched;
        }

        public static void ScheduleInteraction(int interactionId, float time, string tenantId, int round) {
            String jobId = String.Format("{0}-{1}-{2}", tenantId,interactionId.ToString(), round);
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

        public static void ScheduleUpload<T>(string tenantId, string fecha, int relId, int newlevel, int time) where T : Quartz.IJob  {

            String jobId = String.Format("{0}-{1}-{2}", tenantId, fecha, newlevel);
            // create job
            IJobDetail job = JobBuilder.Create<T>()
                    .WithIdentity(jobId, jobId)
                    .UsingJobData("relJugId", relId.ToString())
                    .UsingJobData("tenantId", tenantId)
                    .UsingJobData("cantidad", newlevel.ToString())
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
