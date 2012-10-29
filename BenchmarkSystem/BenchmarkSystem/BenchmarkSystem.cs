using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;

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
    public Dictionary<Scheduler.JobType, byte> running = new Dictionary<Scheduler.JobType, byte>();
    private static JobContext _db;
    public static JobContext db {
      get {
        if (_db == null) {
          Database.SetInitializer<JobContext>(new DropCreateDatabaseAlways<JobContext>());
          _db = new JobContext();
          _db.Database.Initialize(force: true);
        }
        return _db;
      }
      set {
        _db = value;
      }
    }

    private uint _CPU = 30;
    public uint CPU{
        get { return _CPU; }
        set{_CPU = value;}
    }

    private uint CPUInUse = 0;
    /// <summary>
    /// Private constructor. This class is a singleton.
    /// </summary>
    private BenchmarkSystem() {
      scheduler = new Scheduler();
      JobContext temp = BenchmarkSystem.db;
      // Add events
      // These are used to keep track of number of jobs running
      JobStarted += new EventHandler<JobEventArgs>(benchmarkSystem_start);
      JobTerminated += new EventHandler<JobEventArgs>(benchmarkSystem_end);
      JobFailed += new EventHandler<JobEventArgs>(benchmarkSystem_end);

      // Initialize keys
      foreach (Scheduler.JobType type in Scheduler.JobType.getTypes()) {
        running.Add(type, 0);
      }
    }
    /*~BenchmarkSystem() {
      db.Dispose();
    }*/

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
    /// <returns>Status of the BenchmarkSystem</returns>
    public string Status() {
      StringBuilder str = new StringBuilder();
      lock (this) {
        foreach (Scheduler.JobType type in running.Keys) {
          str.AppendLine(type + ": " + running[type] + "/20 running");
        }
      }
      str.AppendLine(scheduler.ToString());
      str.AppendLine(CPUInUse + "/" + CPU + " CPUs used");
      return str.ToString();
    }
    private void Execute(Object o) {
      Job job = (Job)o;
        try {
          string[] args = { "" };
          job.State = Job.JobState.Running;
          job.process(args);
          job.State = Job.JobState.Succesfull;
          OnJobTerminated(job);
        } catch (Exception e) {
          job.State = Job.JobState.Failed;
          OnJobFailed(job, e);
        }
    }

    /// <summary>
    /// This method will run jobs from the job queues.
    /// </summary>
    public void ExecuteAll() {
      Job nextJob = null;
      while (TotalNumberOfJobs() > 0) {
        lock (this) {
          if ((nextJob = scheduler.PopJob(CPU - CPUInUse)) != null) {
            ParameterizedThreadStart ts = new ParameterizedThreadStart(Execute);
            Thread thread = new Thread(ts);
            OnJobStarted(nextJob);
            thread.Start(nextJob);
          } else {
            Thread.Sleep(200);
          }
        }
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
      this.CPUInUse += e.job.CPU;
      running[Scheduler.GetJobType(e.job)]++;
    }

    // These are used to keep track of number of jobs running
    private void benchmarkSystem_end(object sender, JobEventArgs e) {
      lock (this) {
        this.CPUInUse -= e.job.CPU;
        running[Scheduler.GetJobType(e.job)]--;
      }
    }
  }
}
