using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BenchmarkSystemNs;

namespace ConsoleSimulation {
  class ConsoleApp {
    static void Main(string[] args) {
      Owner me = new Owner("Test");
      BenchmarkSystem system = BenchmarkSystem.instance;
      //Logger logger = new Logger(system);
      for (int i = 1; i <= 100; i++) {
        Job job = new Job(me, 2, 1);
        int value = i;
        job.process = (a) => {
          Console.WriteLine("Job" + value + " runs and runs");
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
      Console.Read();
    }
  }
}
