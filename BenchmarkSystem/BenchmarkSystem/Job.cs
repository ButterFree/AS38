using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BenchmarkSystemNs {
  public class Job {
    /// <summary>
    /// Constructor for Job
    /// </summary>
    /// <param name="owner">Owner for class</param>
    /// <param name="CPU">Number of threads</param>
    /// <param name="ExpectedRuntime">Expected runtime</param>
    public Job(string name, Owner owner, byte CPU, float ExpectedRuntime) {
      if (CPU > 10) throw new ArgumentOutOfRangeException("No more than 10 CPU's available. Tried to add job with: " + CPU);
      if (CPU < 1) throw new ArgumentOutOfRangeException("No less than 1 CPU. Tried to add job with: " + CPU);
      this.name = name;
      this.owner = owner;
      this.CPU = CPU;
      this.ExpectedRuntime = ExpectedRuntime;
      State = JobState.Created;
      BenchmarkSystem.db.Jobs.Add(this);
      Activity ac = new Activity(this, Job.JobState.Created, System.DateTime.Now.Ticks);
      BenchmarkSystem.db.Activities.Add(ac);
      BenchmarkSystem.db.SaveChanges();
    }
    public Job() {}
    [Key]
    public string name { get; set; }
    /// <summary>
    /// Owner of this job.
    /// </summary>
    public virtual Owner owner {
      get;
      set;
    }

    /// <summary>
    /// Number of threads used by this job
    /// </summary>
    public byte CPU {
      get;
      set;
    }

    /// <summary>
    /// Expected runtime
    /// </summary>
    //TODO: Add unit
    //TODO: 0 is okay?
    public float ExpectedRuntime {
      get;
      set;
    }

    /// <summary>
    /// State of this job. See State enum
    /// </summary>
    public int DbState { get; set; }
    public Job.JobState State {
      get { return (Job.JobState)DbState; }
      set {
        DbState = (int)value;
        BenchmarkSystem.db.SaveChanges();
      }
    }

    /// <summary>
    /// Algorithm this job runs
    /// </summary>
    public Func<string[], string> process {
      get;
      set;
    }

    /// <summary>
    /// Timestamp. This should be set when the job is added to a queue. Use SetTimestamp()
    /// </summary>
    public long timestamp {
      internal set;
      get;
    }

    /// <summary>
    /// Sets the timestamp of the job. This should be used when the job is added to the queue.
    /// </summary>
    public void SetTimestamp() {
      timestamp = System.DateTime.Now.Ticks;
    }

    /// <summary>
    /// Prints: Timestamp, owner, number of CPUs, expected runtime, state.
    /// </summary>
    /// <returns>String descriping this job</returns>
    public override string ToString() {
      return "(" + timestamp + ")Job: [name="+name+",owner=" + owner.Name + ",CPU=" + CPU + "ExpectedRuntime=" + ExpectedRuntime + "] - " + State;
    }
    /// <summary>
    /// Enum descriping the state of the Job.
    /// </summary>
    public enum JobState {
      Created,
      Queued,
      Running,
      Succesfull,
      Failed
    }
  }
}
