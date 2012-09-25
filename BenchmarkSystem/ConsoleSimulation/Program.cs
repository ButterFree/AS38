using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BenchmarkSystemNs;

namespace ConsoleSimulation
{
    class Program
    {
        static void Main(string[] args) {
            Owner me = new Owner("Test");
            BenchmarkSystemNs.BenchmarkSystem system = BenchmarkSystemNs.BenchmarkSystem.instance;
            Logger logger = new Logger(system);
            for (int i = 0; i < 100; i++) {
                Job job = new Job(me, 2, 1);
                job.process = (a) =>
                {
                    Console.WriteLine("Job" + i + " runs and runs");
                    return "";
                };
                system.Submit(job);
            }
            system.Status();
            Console.WriteLine("Executing all:");
            system.ExecuteAll();
            Console.Read();
        }
    }
}
