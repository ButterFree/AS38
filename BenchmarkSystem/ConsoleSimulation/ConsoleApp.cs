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
      while (true) {
          for (int i = 1; i <= 10; i++) {
              Owner me = new Owner("Test" + (int)random.Next(100));
              Job job = new Job("ConsoleJob"+id++, me, (byte)(random.Next(9)+1), (float)(random.NextDouble()*4.9+0.1));
              job.process = (a) =>
              {
                  Console.WriteLine("Job "+job.name+" runs and runs");
                  Thread.Sleep(random.Next(5) * 1000);
                  Console.WriteLine("Job " + job.name + " finished");
                  return "";
              };
              system.Submit(job);
          }

          Console.WriteLine("Status: ");
          Console.WriteLine(system.Status());
          Console.WriteLine("Executing all:");
          system.ExecuteAll();
          Console.WriteLine("\nStatus: ");
          Console.WriteLine(system.Status());

          Thread.Sleep(7000);
      }
    }
  }
}
