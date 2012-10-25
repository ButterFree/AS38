using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BenchmarkSystemNs;
using System.Threading;

namespace ConsoleSimulation {
  class ConsoleApp {
    static void Main(string[] args) {
      Owner me = new Owner("Test");
      BenchmarkSystem system = BenchmarkSystem.instance;
      Random random = new Random();
        
      int id = 0;
      while (true) {
          for (int i = 1; i <= 10; i++) {
              Job job = new Job(me, (byte)(random.Next(9)+1), (float)(random.NextDouble()*4.9+0.1));
              job.id = id;
              int value = id;
              job.process = (a) =>
              {
                  Console.WriteLine("Job" + value + " runs and runs");
                  Thread.Sleep(random.Next(5) * 1000);
                  Console.WriteLine("Job" + value + "finished");
                  return "";
              };
              system.Submit(job);
              id++;
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
