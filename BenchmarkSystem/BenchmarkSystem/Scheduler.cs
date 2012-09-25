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
          if (list.Count > 0) {
              if (jobToRun == null || list[0].timestamp < jobToRun.timestamp) {
                  jobToRun = list[0];
                  inList = list;
              }
          }
      }
      if (inList != null) inList.RemoveAt(0);
      return jobToRun;
    }

    public static JobType GetJobType(Job job) {
      if (job.ExpectedRuntime < 30) {
        return JobType.Short;
      } else if (job.ExpectedRuntime >= 30 && job.ExpectedRuntime < 120) {
        return JobType.Long;
      } else {
        return JobType.VeryLong;
      }
    }

    public override string ToString() {
      StringBuilder str = new StringBuilder();
      foreach (IList<Job> list in jobs.Values) {
        str.AppendLine(GetJobType(list[0])+": "+list.Count+" jobs");
        foreach(Job job in list) {
          str.AppendLine(job.ToString());
        }
      }
      return str.ToString();
    }
  }
}
