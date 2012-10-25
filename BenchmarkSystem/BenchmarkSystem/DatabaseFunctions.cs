using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace BenchmarkSystemNs {
  class DatabaseFunctions {
    private DbContext db;

    public DatabaseFunctions(DbContext db) {
      this.db = db;
    }

    public Job getOldestJobOfType(Scheduler.JobType type) {
      return new Job(new Owner("dav"), 1, 1);
    }

    public IList<Owner> GetAllUsers() {
      return new List<Owner>();
    }
    public IList<Job> GetJobs(Owner User) {
      return new List<Job>();
    }
    public IList<Job> GetJobs(Owner User, uint DaysAgoMax) {
      return new List<Job>();
    }
    public IList<Job> GetJobs(Owner User, uint StartTimestamp, uint EndTimestamp) {
      return new List<Job>();
    }
    public IDictionary<JobState, IList<Job>> GetGroupedJobs(uint StartTimestamp, uint EndTimestamp) {
      return new Dictionary<JobState, IList<Job>>();
    }
    public IDictionary<JobState, IList<Job>> GetGroupedJobs(Owner owner, uint StartTimestamp, uint EndTimestamp) {
      return new Dictionary<JobState, IList<Job>>();
    }

  }
}
