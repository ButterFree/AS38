using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace BenchmarkSystemNs {
  public static class DatabaseFunctions {

    public static Job.JobState GetJobstate(Job job) {
      var query = from a in BenchmarkSystem.db.Activities
                  where a.Job.Equals(job)
                  orderby a.Timestamp
                  select a;
      return query.First().State;
    }
    public static bool JobExists(Job job, Job.JobState State) {
      var query = from j in BenchmarkSystem.db.Jobs
                  where j.name == job.name && j.DbState == (int)State
                  select j;
      return (query.Count() > 0);
    }
    public static IList<Job> GetJobs(Job.JobState State) {
      var query = from j in BenchmarkSystem.db.Jobs
                  where j.DbState == (int)State
                  orderby j.timestamp ascending
                  select j;
      return query.ToList();
    }
    public static IList<Job> GetJobs(Scheduler.JobType type, Job.JobState State) {
      var query = from j in BenchmarkSystem.db.Jobs
                  where j.ExpectedRuntime >= type.MinRuntime && j.ExpectedRuntime <= type.MaxRuntime && j.DbState == (int)State
                  orderby j.timestamp ascending
                  select j;
      return query.ToList();
    }
    public static IList<Owner> GetAllUsers() {
      var query = from o in BenchmarkSystem.db.Owners
                  select o;
      return query.ToList();
    }
    public static IList<Job> GetJobs(Owner User) {
      var query = from j in BenchmarkSystem.db.Jobs
                  where j.owner.Name == User.Name
                  select j;
      return query.ToList();
    }
    public static IList<Job> GetJobs(Owner User, uint DaysAgoMax) {
      DateTime minDate = System.DateTime.Now;
      minDate.AddDays(-DaysAgoMax);
      long minTimestamp = minDate.Ticks;
      var query = from j in BenchmarkSystem.db.Jobs
                  where j.owner.Name == User.Name && j.timestamp > minTimestamp
                  select j;
      return query.ToList();
    }
    public static IList<Job> GetJobs(Owner User, uint StartTimestamp, uint EndTimestamp) {
      var query = from j in BenchmarkSystem.db.Jobs
                  join a in BenchmarkSystem.db.Activities on j equals a.Job
                  where j.owner.Name == User.Name &&
                        j.timestamp > StartTimestamp && j.timestamp < EndTimestamp &&
                        a.Timestamp < EndTimestamp
                  select j;
      return query.ToList();
    }
    public static IDictionary<Job.JobState, IList<Job>> GetGroupedJobs(uint StartTimestamp, uint EndTimestamp) {
      Dictionary<Job.JobState, IList<Job>> jobs = new Dictionary<Job.JobState, IList<Job>>();
      foreach (Scheduler.JobType type in Scheduler.JobType.getTypes()) {
        var query = from j in BenchmarkSystem.db.Jobs
                    where j.ExpectedRuntime > type.MinRuntime && j.ExpectedRuntime < type.MaxRuntime && j.timestamp > StartTimestamp && j.timestamp < EndTimestamp
                    select j;

      }
      return new Dictionary<Job.JobState, IList<Job>>();
    }
    public static IDictionary<Job.JobState, IList<Job>> GetGroupedJobs(Owner owner, uint StartTimestamp, uint EndTimestamp) {
      return new Dictionary<Job.JobState, IList<Job>>();
    }

  }
}
