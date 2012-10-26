using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BenchmarkSystemNs {
  /// <summary>
  /// Scheduler holds the job queues.
  /// </summary>
  public class Scheduler {

    /// <summary>
    /// JobType is used to descripe the queue and the jobs within the queue.
    /// </summary>
    public class JobType {
      public string Name {get; private set;}
      public float MinRuntime {get;private set;}
      public float MaxRuntime {get;private set;}
      private JobType(string name, float min, float max) {
        this.Name = name;
        MinRuntime = min;
        MaxRuntime = max;
      }
      public static JobType Short    = new JobType("Short"   , (float)0.1, (float)0.5);
      public static JobType Long     = new JobType("Long"    , (float)0.5, (float)2.0);
      public static JobType VeryLong = new JobType("VeryLong", (float)2.0, (float)5.0);
      public static IList<JobType> getTypes() {
        Type t = typeof(JobType);
        List<JobType> types = new List<JobType>();
        foreach (FieldInfo f in t.GetFields()) {
          types.Add((JobType)f.GetValue(null));
        }
        return types;
      }
      public override string ToString() {
        return Name;
      }
    }

    /// <summary>
    /// Add a job to the scheduler
    /// </summary>
    /// <param name="job">Job to be added</param>
    public void AddJob(Job job) {
      // Set timestamp to keep track of when this job was added to a queue
      job.SetTimestamp();
      job.State = Job.JobState.Queued;
    }

    /// <summary>
    /// Remove a job from the queue.
    /// </summary>
    /// <param name="job"></param>
    public void RemoveJob(Job job) {
      job.State = Job.JobState.Failed;
      BenchmarkSystem.db.SaveChanges();
    }

    /// <summary>
    /// Get the next job from the internal queues.
    /// </summary>
    /// <returns></returns>
    public Job PopJob(uint maxCPU) {
      Job jobToRun = null;
      foreach (JobType type in JobType.getTypes()) {
        IList<Job> jobs = DatabaseFunctions.GetJobs(type, Job.JobState.Queued);
        Job OldestJob = null;
        if (jobs.Count > 0) OldestJob = jobs[0];
        if (OldestJob != null && (jobToRun == null || OldestJob.timestamp < jobToRun.timestamp)) {
          jobToRun = OldestJob;
        }
      }
      //if (jobToRun != null) RemoveJob(jobToRun);
      return jobToRun;
    }

    /// <summary>
    /// Identify the JobType.
    /// This is used to add the job to the correct queue.
    /// </summary>
    /// <see cref="BenchmarkSystemNs.Scheduler.JobType"/>
    /// <param name="job">Job</param>
    /// <returns>JobType</returns>
    public static JobType GetJobType(Job job) {
      foreach (JobType type in JobType.getTypes()) {
        if (job.ExpectedRuntime >= type.MinRuntime && job.ExpectedRuntime <= type.MaxRuntime) return type;
      }
      throw new ArgumentException("No jobtype found for the job");
    }

    /// <summary>
    /// Returns the state of each job as a string.
    /// This is used by BenchmarkSystem.Status()
    /// </summary>
    /// <returns>String</returns>
    public override string ToString() {
      StringBuilder str = new StringBuilder();
      foreach (JobType type in JobType.getTypes()) {
        str.AppendLine(type + ": " + DatabaseFunctions.GetJobs(type, Job.JobState.Queued).Count() + " jobs");
        foreach (Job job in DatabaseFunctions.GetJobs(type, Job.JobState.Queued)) {
          str.AppendLine(job.ToString());
        }
      }
      return str.ToString();
    }

    /// <summary>
    /// Return total number of jobs on the queues.
    /// </summary>
    /// <returns>uint total number of jobs</returns>
    public uint TotalNumberOfJobs() {
      return (uint)DatabaseFunctions.GetJobs(Job.JobState.Queued).Count();
    }

    /// <summary>
    /// Returns whether the queues holds the job
    /// </summary>
    /// <param name="job">Job</param>
    /// <returns>bool contains job</returns>
    public bool Contains(Job job) {
      return DatabaseFunctions.JobExists(job, Job.JobState.Queued);
    }
  }
}
