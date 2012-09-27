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

        public JobEventArgs(Job job, Exception e) {
            this.job = job;
            this.eventType = EventType.JobFailed;
            this.error = e;
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

        public Exception error {
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
