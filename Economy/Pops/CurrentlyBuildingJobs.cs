using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PResources;

namespace Pops
{
    public class CurrentlyBuildingJobs
    {
        private Person person;
        private int remainingTime;
        private DefaultJobContainer defaultJobContainer;

        //For building by building queue
        private Object Source;

        public int RemainingTime { get { return remainingTime; } }
        public Person CurrentPerson { get { return person; } }
        public DefaultJobContainer JobContainer { get { return defaultJobContainer; } }

        public CurrentlyBuildingJobs(DefaultJobContainer job)
        {
            defaultJobContainer = job;
            remainingTime = job.TrainTime();
        }

        public CurrentlyBuildingJobs(DefaultJobContainer job, int time)
        {
            defaultJobContainer = job;
            remainingTime = time;
        }

        public CurrentlyBuildingJobs(Person _person, DefaultJobContainer job, int time)
        {
            person = _person;
            defaultJobContainer = job;
            remainingTime = time;
        }

        public JobTypesList GetJob()
        {
            return defaultJobContainer.Job;
        }

        public ResourceHolderInitializer GetResourceHolder()
        {
            return defaultJobContainer.ResourceHolder;
        }


        public List<ResourceBehaviour> GetResourceBehaviours()
        {
            return defaultJobContainer.Upkeep;
        }

        public void PassTurn()
        {
            remainingTime--;
        }

    }
}
