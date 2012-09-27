using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BenchmarkSystemNs
{
    public class JobEventArgs : EventArgs
    {
        public JobEventArgs(Job job, EventType type)
        {
            this.job = job;
            this.eventType = type;
        }

        public Job job
        {
            get;
            private set;
        }

        public EventType eventType {
          get;
          private set;
        }

        public enum EventType {
          JobQueued,
          JobRemoved,
          JobStarted,
          JobTerminated,
          JobFailed,
        }
    }
}
