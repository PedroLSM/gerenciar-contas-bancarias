using GCB.BackgroundTasks.Jobs;
using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCB.BackgroundTasks
{
    public class HangfireJobScheduler
    {
        public static void ScheduleRecurringJobs()
        {
            RecurringJob.RemoveIfExists(nameof(AdicionarReferenciaJob));
            RecurringJob.RemoveIfExists(nameof(CalcularDiferencaSaldoReferenciaJob));

            RecurringJob.AddOrUpdate<AdicionarReferenciaJob>(
                nameof(AdicionarReferenciaJob),
                job => job.Run(JobCancellationToken.Null), 
                "*/30 * * * *", 
                TimeZoneInfo.Local
            );

            RecurringJob.AddOrUpdate<CalcularDiferencaSaldoReferenciaJob>(
                nameof(CalcularDiferencaSaldoReferenciaJob),
                job => job.Run(JobCancellationToken.Null),
                "*/15 * * * *",
                TimeZoneInfo.Local
            );
        }
    }
}
