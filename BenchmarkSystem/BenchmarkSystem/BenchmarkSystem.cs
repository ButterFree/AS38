using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BenchmarkSystemNs {
  /// <summary>
  /// BecnhmarkSystem is the main class for this project.
  /// Note: This is a singleton
  /// </summary>
  public sealed class BenchmarkSystem {
    // Events
    public event EventHandler<JobEventArgs> JobQueued;
    public event EventHandler<JobEventArgs> JobRemoved;
    public event EventHandler<JobEventArgs> JobStarted;
    public event EventHandler<JobEventArgs> JobTerminated;
    public event EventHandler<JobEventArgs> JobFailed;
    // Singleton instance
    public static readonly BenchmarkSystem instance = new BenchmarkSystem();
    // See Scheduler class
    private Scheduler scheduler;
    // Number of jobs running for each JobType
    Dictionary<Scheduler.JobType, byte> running = new Dictionary<Scheduler.JobType, byte>();

    /// <summary>
    /// Private constructor. This class is a singleton.
    /// </summary>
    private BenchmarkSystem() {
      scheduler = new Scheduler();
      // Add events
      // These are used to keep track of number of jobs running
      JobStarted += new EventHandler<JobEventArgs>(benchmarkSystem_start);
      JobTerminated += new EventHandler<JobEventArgs>(benchmarkSystem_end);
      JobFailed += new EventHandler<JobEventArgs>(benchmarkSystem_end);

      // Initialize keys
      foreach (Scheduler.JobType type in Enum.GetValues(typeof(Scheduler.JobType))) {
          running.Add(type, 0);
      }
    }

    /// <summary>
    /// Add a job. The job will be added to the Scheduler
    /// <see cref="BenchmarkSystemNS.Scheduler"/>
    /// </summary>
    /// <param name="job"></param>
    public void Submit(Job job) {
        if (job != null) {
            scheduler.AddJob(job);
            OnJobQueued(job);
        } else {
            throw new ArgumentNullException();
        }
    }

    /// <summary>
    /// Remove job will remove job from queue.
    /// </summary>
    /// <param name="job"></param>
    public void Remove(Job job) {
      scheduler.RemoveJob(job);
      OnJobRemoved(job);
    }

    /// <summary>
    /// Retuns status of the BenchmarkSystem as a string. This includes all jobs and their current state.
    /// </summary>
    /// <returns>Status of the BecnhmarkSystem</returns>
    public string Status() {
      StringBuilder str = new StringBuilder();
      foreach (Scheduler.JobType type in running.Keys) {
        str.AppendLine(type+": "+running[type]+"/20 running");
      }
      str.AppendLine(scheduler.ToString());
      return str.ToString();
    }

    /// <summary>
    /// This method will run jobs from the job queues.
    /// </summary>
    public void ExecuteAll() {
      Job nextJob = null;
      while((nextJob = scheduler.PopJob()) != null) {
        string[] args = { "" };
        nextJob.State = JobState.Running;
        running[Scheduler.GetJobType(nextJob)]++;
        OnJobStarted(nextJob);
        try {
          nextJob.process(args);
          nextJob.State = JobState.Succesfull;
          OnJobTerminated(nextJob);
        } catch (Exception e) {
          nextJob.State = JobState.Failed;
          OnJobFailed(nextJob,e);
        }
        running[Scheduler.GetJobType(nextJob)]--;
      }
    }

    /// <summary>
    /// Return total number of jobs on the queues.
    /// </summary>
    /// <returns>uint total number of jobs</returns>
    public uint TotalNumberOfJobs() {
      return scheduler.TotalNumberOfJobs();
    }

    /// <summary>
    /// Returns whether the queues holds the job
    /// </summary>
    /// <param name="job">Job</param>
    /// <returns>bool contains job</returns>
    public bool Contains(Job job) {
      return scheduler.Contains(job);
    }

    #region EventFunctions

    public void OnJobQueued(Job job) {
      if (JobQueued != null)
        JobQueued(this, new JobEventArgs(job, JobEventArgs.EventType.JobQueued));
    }

    public void OnJobRemoved(Job job) {
      if (JobRemoved != null)
        JobRemoved(this, new JobEventArgs(job, JobEventArgs.EventType.JobRemoved));
    }

    public void OnJobStarted(Job job) {
      if (JobStarted != null)
        JobStarted(this, new JobEventArgs(job, JobEventArgs.EventType.JobStarted));
    }

    public void OnJobTerminated(Job job) {
      if (JobTerminated != null)
        JobTerminated(this, new JobEventArgs(job, JobEventArgs.EventType.JobTerminated));
    }

    public void OnJobFailed(Job job, Exception e) {
      if (JobFailed != null)
        JobFailed(this, new JobEventArgs(job, e));
    }
    #endregion

    // These are used to keep track of number of jobs running
    private void benchmarkSystem_start(object sender, JobEventArgs e) {
      running[Scheduler.GetJobType(e.job)]++;
    }

    // These are used to keep track of number of jobs running
    private void benchmarkSystem_end(object sender, JobEventArgs e) {
      running[Scheduler.GetJobType(e.job)]--;
    }
  }
}
