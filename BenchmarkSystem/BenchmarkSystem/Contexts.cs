using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace BenchmarkSystemNs {
  public class JobContext : DbContext {
    public DbSet<Job> Jobs { get; set; }
    public DbSet<Owner> Owners { get; set; }
  }
}
