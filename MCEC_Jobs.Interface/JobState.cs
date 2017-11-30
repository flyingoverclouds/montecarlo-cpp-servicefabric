using System;
using System.Collections.Generic;
using System.Text;

namespace MCEC_Jobs.Interface
{
    public enum JobStatus
    {
        Submitted,
        Started,
        Terminated,
        Error
    }

    public class JobState
    {
        public Guid Id { get; set; }
        public JobState Status { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
