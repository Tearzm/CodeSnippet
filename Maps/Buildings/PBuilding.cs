using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interactions;
using Pops;
using PResources;

namespace Map.building
{
    public class PBuilding : Interactable<Person>
    {
        public ResourceActor resources;

        /// <summary>
        /// Needs change in the future to implement different provinces and entities
        /// </summary>
        /// <param name="settlement"></param>

        public virtual void EnterRegion(Person person)
        {
            if (person.myJob.JobType == JobTypesList.Hunter)
            {
                if (this is IHarvestinteraction) Harvest.harvest(person.myJob, resources);
            }
        }

        public virtual void EnterSettlement(Person person)
        {
            throw new System.NotImplementedException();
        }

        public virtual void LeaveRegion(Person person)
        {
            throw new System.NotImplementedException();
        }


    }
}
