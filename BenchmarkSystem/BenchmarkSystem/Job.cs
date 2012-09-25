using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BenchmarkSystem {
  public class Job {
    public Job(Owner owner, byte CPU, int ExpectedRuntime) {
      if (CPU > 7) throw new ArgumentOutOfRangeException("No more than 6 CPU's available. Tried to add job with: " + CPU);
      this.owner = owner;
      this.CPU = CPU;
      this.ExpectedRuntime = ExpectedRuntime;
      State = JobState.Created;
    }
    public Owner owner {
      get;
      set;
    }

    public byte CPU {
      get;
      set;
    }

    public int ExpectedRuntime {
      get;
      set;
    }

    internal JobState State {
      get;
      set;
    }

    public Func<string[], string> process {
      get;
      set;
    }

    public long timestamp {
      private set;
      get;
    }
    public void SetTimestamp() {
      timestamp = System.DateTime.Now.Millisecond;
    }
    public override string ToString() {
      return "("+timestamp+")Job: [owner="+owner.Name+",CPU="+CPU+"ExpectedRuntime="+ExpectedRuntime+"] - "+State;
    }
  }

  enum JobState {
    Created,
    Queued,
    Running,
    Succesfull,
    Failed
  };
}
