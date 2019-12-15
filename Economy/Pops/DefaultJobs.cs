using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pops {


    /// <summary>
    /// Default job requirments for each empire
    /// </summary>
    [System.Serializable]
    [CreateAssetMenu(fileName = "DefaultJobs", menuName = "Pops/DefaultJobInit")]
    public class DefaultJobs : ScriptableObject
    {
        /// <summary>
        /// needs to change to private
        /// </summary>
        [SerializeField]
        public List<DefaultJobContainer> AllJobs;

        public DefaultJobContainer GetJob(JobTypesList type)
        {
            foreach (DefaultJobContainer j in AllJobs) if (j.Job == type) return j;
            return null;
        }

        public void AddJobsToList(DefaultJobs j)
        {
            AllJobs.AddRange(j.AllJobs);
        }

        

    }
}
