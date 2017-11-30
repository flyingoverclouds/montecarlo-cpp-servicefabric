using System;

namespace MCEC_Jobs.Interface
{
    public interface IJobManagement
    {
        bool CreateNewJob(MonteCarloJobSetting settings);
    }
}
