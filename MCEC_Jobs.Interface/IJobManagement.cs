using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Collections;
using System.Collections.Generic;

namespace MCEC_Jobs.Interface
{
    /// <summary>
    /// This interface describe method expose by the Job management service to web frontend 
    /// and to compute engine
    /// </summary>
    public interface IJobManagement : IService
    {
        /// <summary>
        /// Use to create a new MonteCarlo job request. 
        /// The request is queued and new state returned to caller (typically web or api frontend)
        /// </summary>
        /// <param name="settings">MonteCarlo setting</param>
        /// <returns>state of new job</returns>
        JobState CreateNewJob(MonteCarloJobSetting settings);

        /// <summary>
        /// Return a list of 'count' job from a specified start position
        /// </summary>
        /// <param name="start">start position (default is ZERO)</param>
        /// <param name="count">count of job to return (default is 20)</param>
        /// <returns>Enumerable of Jobstate. Empty if no job in queue</returns>
        IEnumerable<JobState> GetJobList(int start=0,int count=20);

        /// <summary>
        /// Return detail information for a specific job 
        /// </summary>
        /// <param name="jobId">id of job to read</param>
        /// <returns>instance of JobState or null</returns>
        JobState GetJob(Guid jobId);

        /// <summary>
        /// Delete a specific job
        /// </summary>
        /// <param name="jobId">id of job to delete</param>
        /// <returns>true if deletion succeeded, false otherwise</returns>
        bool DeleteJob(Guid jobId);

        /// <summary>
        /// Return a job for the compute engine. 
        /// This method will only return a Job where state is Submitted. 
        /// When the job is poped from the waiting queue, it state changed to Started.
        /// (Allocated status is not supported in current version).
        /// </summary>
        /// <returns>Job to compute</returns>
        JobState PopJobForCompute();

        /// <summary>
        /// Used by the compute engine to set the result of the MonteCarlo calculation.
        /// IF result is null , status of job will be set to ERROR
        /// otherwise, statis is set to Terminated and the result stored.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        bool SetJobResult(Guid id, double? result);


    }
}
