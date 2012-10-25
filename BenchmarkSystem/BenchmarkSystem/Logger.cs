using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BenchmarkSystemNs {
  /// <summary>
  /// Logger uses Events to log.
  /// Logger simply writes to console.
  /// </summary>
  public class Logger {

    public static void Enable(bool enable) {
      BenchmarkSystem benchmarkSystem = BenchmarkSystem.instance;
      if (enable) {
        benchmarkSystem.JobQueued += new EventHandler<JobEventArgs>(benchmarkSystem_JobQueued);
        benchmarkSystem.JobRemoved += new EventHandler<JobEventArgs>(benchmarkSystem_JobRemoved);
        benchmarkSystem.JobStarted += new EventHandler<JobEventArgs>(benchmarkSystem_JobStarted);
        benchmarkSystem.JobTerminated += new EventHandler<JobEventArgs>(benchmarkSystem_JobTerminated);
        benchmarkSystem.JobFailed += new EventHandler<JobEventArgs>(benchmarkSystem_JobFailed);
      } else {
        benchmarkSystem.JobQueued -= new EventHandler<JobEventArgs>(benchmarkSystem_JobQueued);
        benchmarkSystem.JobRemoved -= new EventHandler<JobEventArgs>(benchmarkSystem_JobRemoved);
        benchmarkSystem.JobStarted -= new EventHandler<JobEventArgs>(benchmarkSystem_JobStarted);
        benchmarkSystem.JobTerminated -= new EventHandler<JobEventArgs>(benchmarkSystem_JobTerminated);
        benchmarkSystem.JobFailed -= new EventHandler<JobEventArgs>(benchmarkSystem_JobFailed);
      }
    }

    static void benchmarkSystem_JobQueued(object sender, JobEventArgs e) {
      Activity ac = new Activity(e.job, Job.JobState.Queued, System.DateTime.Now.Ticks);
      BenchmarkSystem.db.Activities.Add(ac);
      BenchmarkSystem.db.SaveChanges();
      Console.WriteLine("Job Submitted: " + e.job);
    }

    static void benchmarkSystem_JobRemoved(object sender, JobEventArgs e) {
      Activity ac = new Activity(e.job, Job.JobState.Failed, System.DateTime.Now.Ticks);
      BenchmarkSystem.db.Activities.Add(ac);
      BenchmarkSystem.db.SaveChanges();
      Console.WriteLine("Job Cancelled: " + e.job);
    }

    static void benchmarkSystem_JobStarted(object sender, JobEventArgs e) {
      Activity ac = new Activity(e.job, Job.JobState.Running, System.DateTime.Now.Ticks);
      BenchmarkSystem.db.Activities.Add(ac);
      BenchmarkSystem.db.SaveChanges();
      Console.WriteLine("Job Running: " + e.job);
    }

    static void benchmarkSystem_JobTerminated(object sender, JobEventArgs e) {
      Activity ac = new Activity(e.job, Job.JobState.Succesfull, System.DateTime.Now.Ticks);
      BenchmarkSystem.db.Activities.Add(ac);
      BenchmarkSystem.db.SaveChanges();
      Console.WriteLine("Job Terminated: " + e.job);
    }

    static void benchmarkSystem_JobFailed(object sender, JobEventArgs e) {
      Activity ac = new Activity(e.job, Job.JobState.Failed, System.DateTime.Now.Ticks);
      BenchmarkSystem.db.Activities.Add(ac);
      BenchmarkSystem.db.SaveChanges();
      Console.WriteLine("Job Failed: " + e.job);
    }
  }
}
