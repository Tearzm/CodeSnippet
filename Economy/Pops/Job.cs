using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PResources;
using Interactions;
using Map.building;

namespace Pops
{
    public class Job
    {

        private JobTypesList jobType;
        private bool isBusy;

        public ResourceActor actor;
        
        public JobTypesList JobType { get { return jobType; } }

        public Job(JobTypesList myjob, ResourceActor a)
        {
            jobType = myjob;
            actor = a;
        }



        //private List<T> Interactables
        //private List<T> SpecialInteractions

    }
}
