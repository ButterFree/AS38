using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace BenchmarkSystemNs {
  static class DatabaseFunctions {

    public static IList<Job> GetJobs(JobContext db) {
      var query = from j in db.Jobs
                  orderby j.timestamp ascending
                  select j;
      return query.ToList();
    }
    public static IList<Job> GetJobs(JobContext db, Scheduler.JobType type) {
      var query = from j in db.Jobs
                  where j.ExpectedRuntime > type.MinRuntime && j.ExpectedRuntime < type.MaxRuntime
                  orderby j.timestamp ascending
                  select j;
      return query.ToList();
    }
    public static IList<Owner> GetAllUsers() {
      return new List<Owner>();
    }
    public static IList<Job> GetJobs(JobContext db, Owner User) {
      return new List<Job>();
    }
    public static IList<Job> GetJobs(JobContext db, Owner User, uint DaysAgoMax) {
      return new List<Job>();
    }
    public static IList<Job> GetJobs(JobContext db, Owner User, uint StartTimestamp, uint EndTimestamp) {
      return new List<Job>();
    }
    public static IDictionary<Job.JobState, IList<Job>> GetGroupedJobs(JobContext db, uint StartTimestamp, uint EndTimestamp) {
      return new Dictionary<Job.JobState, IList<Job>>();
    }
    public static IDictionary<Job.JobState, IList<Job>> GetGroupedJobs(JobContext db, Owner owner, uint StartTimestamp, uint EndTimestamp) {
      return new Dictionary<Job.JobState, IList<Job>>();
    }

  }
}
