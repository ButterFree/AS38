using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BenchmarkSystemNs;
using System.Threading;
using System.Data.Entity;

namespace ConsoleSimulation {
  class ConsoleApp {
    static void Main(string[] args) {
      Random random = new Random();
      BenchmarkSystem system = BenchmarkSystem.instance;

      Database.SetInitializer<JobContext>(new DropCreateDatabaseAlways<JobContext>());
      JobContext c = new JobContext();
      c.Database.CreateIfNotExists();

      int id = 0;
      long timestamp = System.DateTime.Now.Ticks;
      Owner me = new Owner("Test");
      Timer timer1 = new Timer(((e) => { Console.Clear(); Console.WriteLine(BenchmarkSystem.instance.Status()); }), null, 2000, 200);
      while (true) {
        while (BenchmarkSystem.instance.TotalNumberOfJobs() < 100) {
          Job job = new Job("ConsoleJob" + id++, me, (byte)(random.Next(9) + 1), (float)(random.NextDouble() * 4.9 + 0.1));
          job.process = (a) => {
            //Console.WriteLine("Job "+job.name+" runs and runs");
            Thread.Sleep((int)job.ExpectedRuntime*1000);
            //Console.WriteLine("Job " + job.name + " finished");
            return "";
          };
          system.Submit(job);
        }
        system.ExecuteAll();
      }
    }
  }
}
