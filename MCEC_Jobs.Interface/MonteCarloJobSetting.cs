using System;
using System.Collections.Generic;
using System.Text;

namespace MCEC_Jobs.Interface
{
    public class MonteCarloJobSetting
    {
        public int Steps;
        public int Simulations;
        public double Maturity;
        public double Strike;
        public double Spot;
        public double Volatility;
        public double InterestRate;
    }
}
