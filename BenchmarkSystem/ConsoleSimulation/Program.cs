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
            for (int i = 0; i < 100; i++) {
                Job job = new Job(me, 2, 1);
                job.process = (a) => "Job" + i + " runs and runs";
                system.Submit(job);
            }
            system.Status();
            system.ExecuteAll();
        }
    }
}
