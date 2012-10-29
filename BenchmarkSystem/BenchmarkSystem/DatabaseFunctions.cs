using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace BenchmarkSystemNs {
  public static class DatabaseFunctions {

    public static bool JobExists(Job job, Job.JobState State) {
      lock (BenchmarkSystem.db) {
        var query = from j in BenchmarkSystem.db.Jobs
                    where j.name == job.name && j.DbState == (int)State
                    select j;
        return (query.Count() > 0);
      }
    }
    public static IList<Job> GetJobs(Job.JobState State) {
      lock (BenchmarkSystem.db) {
        var query = from j in BenchmarkSystem.db.Jobs
                    where j.DbState == (int)State
                    orderby j.timestamp ascending
                    select j;
        return query.ToList();
      }
    }
    public static IList<Job> GetJobs(Scheduler.JobType type, Job.JobState State) {
      lock (BenchmarkSystem.db) {
        var query = from j in BenchmarkSystem.db.Jobs
                    where j.ExpectedRuntime >= type.MinRuntime && j.ExpectedRuntime <= type.MaxRuntime && j.DbState == (int)State
                    orderby j.timestamp ascending
                    select j;
        return query.ToList();
      }
    }
    public static IList<Owner> GetAllUsers() {
      lock (BenchmarkSystem.db) {
        var query = from o in BenchmarkSystem.db.Owners
                    select o;
        return query.ToList();
      }
    }
    public static IList<Job> GetJobs(Owner User) {
      lock (BenchmarkSystem.db) {
        var query = from j in BenchmarkSystem.db.Jobs
                    where j.owner.Name == User.Name
                    select j;
        return query.ToList();
      }
    }
    public static IList<Job> GetJobs(Owner User, uint DaysAgoMax) {
      lock (BenchmarkSystem.db) {
        DateTime minDate = System.DateTime.Now;
        minDate = minDate.AddDays(-DaysAgoMax);
        long minTimestamp = minDate.Ticks;
        var query = from j in BenchmarkSystem.db.Jobs
                    where j.owner.Name == User.Name && j.timestamp > minTimestamp
                    select j;
        return query.ToList();
      }
    }
    public static IList<Job> GetJobs(Owner User, long StartTimestamp, long EndTimestamp) {
      lock (BenchmarkSystem.db) {
        var query = from j in BenchmarkSystem.db.Jobs
                    where j.owner.Name == User.Name &&
                          j.timestamp >= StartTimestamp && j.timestamp <= EndTimestamp
                    select j;
        return query.ToList();
      }
    }
    public static IDictionary<Job.JobState, IList<Job>> GetGroupedJobs(long StartTimestamp, long EndTimestamp) {
      lock (BenchmarkSystem.db) {
        Dictionary<Job.JobState, IList<Job>> jobs = new Dictionary<Job.JobState, IList<Job>>();
        foreach (Job.JobState state in Enum.GetValues(typeof(Job.JobState))) {
          var query = from j in BenchmarkSystem.db.Jobs
                      where j.DbState == (int)state && j.timestamp >= StartTimestamp && j.timestamp <= EndTimestamp
                      select j;
          jobs.Add(state, query.ToList());
        }
        return jobs;
      }
    }
    public static IDictionary<Job.JobState, IList<Job>> GetGroupedJobs(Owner owner, long StartTimestamp, long EndTimestamp) {
      lock (BenchmarkSystem.db) {
        Dictionary<Job.JobState, IList<Job>> jobs = new Dictionary<Job.JobState, IList<Job>>();
        foreach (Job.JobState state in Enum.GetValues(typeof(Job.JobState))) {
          var query = from j in BenchmarkSystem.db.Jobs
                      where j.DbState == (int)state && j.timestamp >= StartTimestamp && j.timestamp <= EndTimestamp && j.owner.Name == owner.Name
                      select j;
          jobs.Add(state, query.ToList());
        }
        return jobs;
      }
    }
  }
}
