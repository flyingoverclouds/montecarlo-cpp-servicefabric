using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MCEC_Jobs.Interface
{
    [DataContract]
    public class MonteCarloJobSetting
    {
        [DataMember]
        public int Steps { get; set; }
        [DataMember]
        public int Simulations { get; set; }
        [DataMember]
        public double Maturity { get; set; }
        [DataMember]
        public double Strike { get; set; }
        [DataMember]
        public double Spot { get; set; }
        [DataMember]
        public double Volatility { get; set; }
        [DataMember]
        public double InterestRate { get; set; }
    }
}
