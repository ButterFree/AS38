using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BenchmarkSystemNs {
  /// <summary>
  /// Scheduler holds the job queues.
  /// </summary>
  class Scheduler {
    
    /// <summary>
    /// JobType is used to descripe the queue and the jobs within the queue.
    /// </summary>
    public enum JobType {
      Short,
      Long,
      VeryLong
    }

    // A list of jobs per JobType
    private Dictionary<JobType, IList<Job>> jobs = new Dictionary<JobType, IList<Job>>();

    /// <summary>
    /// Constructor for Scheduler.
    /// </summary>
    public Scheduler() {
      // Initialize Dictionary of jobs
      foreach (JobType type in Enum.GetValues(typeof(JobType))) {
        jobs.Add(type, new List<Job>());
      }
    }

    /// <summary>
    /// Add a job to the scheduler
    /// </summary>
    /// <param name="job">Job to be added</param>
    public void AddJob(Job job) {
      // Set timestamp to keep track of when this job was added to a queue
      job.SetTimestamp();
      job.State = JobState.Queued;
      jobs[GetJobType(job)].Add(job);
    }

    /// <summary>
    /// Remove a job from the queue.
    /// </summary>
    /// <param name="job"></param>
    public void RemoveJob(Job job) {
      jobs[GetJobType(job)].Remove(job);
    }

    /// <summary>
    /// Get the next job from the internal queues.
    /// </summary>
    /// <returns></returns>
    public Job PopJob() {
      Job jobToRun = null;
      IList<Job> inList = null;
      foreach (IList<Job> list in jobs.Values) {
        // if list not empty
          if (list.Count > 0) {
            // if the next job was queued before jobToRun
              if (jobToRun == null || list[0].timestamp < jobToRun.timestamp) {
                  jobToRun = list[0];
                  inList = list;
              }
          }
      }
      // Following will be false, if queues are empty
      if (inList != null) inList.RemoveAt(0);
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
      if (job.ExpectedRuntime < 30) {
        return JobType.Short;
      } else if (job.ExpectedRuntime >= 30 && job.ExpectedRuntime < 120) {
        return JobType.Long;
      } else {
        return JobType.VeryLong;
      }
    }

    /// <summary>
    /// Returns the state of each job as a string.
    /// This is used by BenchmarkSystem.Status()
    /// </summary>
    /// <returns>String</returns>
    public override string ToString() {
      StringBuilder str = new StringBuilder();
      foreach (JobType type in jobs.Keys) {
        str.AppendLine(type+": "+jobs[type].Count+" jobs");
        foreach(Job job in jobs[type]) {
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
      uint count = 0;
      foreach (IList<Job> list in jobs.Values) {
        count += (uint)list.Count;
      }
      return count;
    }

    /// <summary>
    /// Returns whether the queues holds the job
    /// </summary>
    /// <param name="job">Job</param>
    /// <returns>bool contains job</returns>
    public bool Contains(Job job) {
      bool contains = false;
      foreach (IList<Job> list in jobs.Values) {
        if (list.Contains(job)) {
          contains = true;
          break;
        }
      }
      return contains;
    }
  }
}
