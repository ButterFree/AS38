using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BenchmarkSystemNs {
  public class JobEventArgs : EventArgs {
    /// <summary>
    /// The default contructor for a job event, except JobFailed use (Job, Exception) instead.
    /// </summary>
    /// <param name="job">The Job affected</param>
    /// <param name="type">The type of event</param>
    public JobEventArgs(Job job, EventType type) {
      this.job = job;
      this.eventType = type;
    }

    /// <summary>
    /// Constructor for job failed event.
    /// </summary>
    /// <param name="job"></param>
    /// <param name="e">The exception that made the job fail</param>
    public JobEventArgs(Job job, Exception e) {
      this.job = job;
      this.eventType = EventType.JobFailed;
      this.error = e;
    }

    /// <summary>
    /// The job that was affected by the event.
    /// </summary>
    public Job job {
      get;
      private set;
    }

    /// <summary>
    /// The event fired
    /// </summary>
    public EventType eventType {
      get;
      private set;
    }

    /// <summary>
    /// The exception that made the the job fail, null if the eventtype isn't JobFailed.
    /// </summary>
    public Exception error {
      get;
      private set;
    }

    public enum EventType {
      JobQueued,
      JobRemoved,
      JobStarted,
      JobTerminated,
      JobFailed,
    }
  }
}
