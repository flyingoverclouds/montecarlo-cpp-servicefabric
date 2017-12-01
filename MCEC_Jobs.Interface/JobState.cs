using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MCEC_Jobs.Interface
{
    public enum JobStatus
    {
        Submitted,
        /// <summary>
        /// Not used in this version
        /// </summary>
        Allocated, 
        Started,
        Terminated,
        Error
    }

    [DataContract]
    public class JobState
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public DateTime CreationData { get; set; }
        [DataMember]
        public JobStatus Status { get; set; }
        [DataMember]
        public DateTime LastUpdate { get; set; }

        [DataMember]
        public MonteCarloJobSetting MonteCarloSetting { get; set; }

        [DataMember]
        public double? Result { get; set; }
    }
}
