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
            benchmarkSystem.JobQueued += new EventHandler<JobEventArgs>(benchmarkSystem_JobSubmitted);
            benchmarkSystem.JobRemoved += new EventHandler<JobEventArgs>(benchmarkSystem_JobCancelled);
            benchmarkSystem.JobStarted += new EventHandler<JobEventArgs>(benchmarkSystem_JobRunning);
            benchmarkSystem.JobTerminated += new EventHandler<JobEventArgs>(benchmarkSystem_JobTerminated);
            benchmarkSystem.JobFailed += new EventHandler<JobEventArgs>(benchmarkSystem_JobFailed);
        } else {
            benchmarkSystem.JobQueued -= new EventHandler<JobEventArgs>(benchmarkSystem_JobSubmitted);
            benchmarkSystem.JobRemoved -= new EventHandler<JobEventArgs>(benchmarkSystem_JobCancelled);
            benchmarkSystem.JobStarted -= new EventHandler<JobEventArgs>(benchmarkSystem_JobRunning);
            benchmarkSystem.JobTerminated -= new EventHandler<JobEventArgs>(benchmarkSystem_JobTerminated);
            benchmarkSystem.JobFailed -= new EventHandler<JobEventArgs>(benchmarkSystem_JobFailed);
        }
    }

   static void benchmarkSystem_JobSubmitted(object sender, JobEventArgs e) {
      Console.WriteLine("Job Submitted: " + e.job);
    }

    static void benchmarkSystem_JobCancelled(object sender, JobEventArgs e) {
      Console.WriteLine("Job Cancelled: " + e.job);
    }

    static void benchmarkSystem_JobRunning(object sender, JobEventArgs e) {
      Console.WriteLine("Job Running: " + e.job);
    }

    static void benchmarkSystem_JobTerminated(object sender, JobEventArgs e) {
      Console.WriteLine("Job Terminated: " + e.job);
    }

    static void benchmarkSystem_JobFailed(object sender, JobEventArgs e) {
      Console.WriteLine("Job Failed: " + e.job);
    }
  }
}
