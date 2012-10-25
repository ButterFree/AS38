using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace BenchmarkSystemNs {
  public class Activity {

    public Activity(Job Job, Job.JobState State, long Timestamp) {
      this.Job = Job;
      this.State = State;
      this.Timestamp = Timestamp;
    }

    [Key]
    [Column(Order = 0)]
    public Job Job { get; set; }
    public int DbState { get; set; }
    public Job.JobState State {
      get { return (Job.JobState)DbState; }
      set { DbState = (int)value; }
    }
    [Key]
    [Column(Order = 1)]
    public long Timestamp { get; set; }
  }
}
