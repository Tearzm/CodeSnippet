using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pops;
using PResources;
using Map.building;

namespace Interactions
{

    /// <summary>
    /// Has a list of all Harvesting Intercations between different pops and provinces
    /// </summary>
    public static class Harvest
    {

        /// <summary>
        /// A person fills his resource storage from a harvest spot
        /// </summary>
        /// <param name="person"></param>
        /// <param name="harvestFrom"></param>
        /// <returns></returns>
        public static bool harvest(Job person, ResourceActor harvestFrom)
        {
            if(person.JobType == JobTypesList.Hunter)
            {
                if (harvestFrom.Buy(person.actor.MyResources))
                {
                    person.actor.Stolen(person.actor.MyResources);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Deliver a resource from a person to settlement storage
        /// </summary>
        /// <param name="person"></param>
        /// <param name="storage"></param>
        public static void Deliver(Job person, ResourceActor storage)
        {
            storage.Stolen(person.actor.Steal());
        }

        /// <summary>
        /// Harvest from a harvesting spot
        /// </summary>
        /// <param name="person"></param>
        /// <param name="spot"></param>
        /// <returns></returns>
        public static bool HarvestFromSpot(Job person, HarvestSpot spot)
        {
            if (person.JobType == spot.harvesterType)
            {
                foreach(ResourceBehaviours behaviour in spot.resources.MyResourceBehaviours)
                {
                    person.actor.AddBehaviour(behaviour, spot);
                }
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Stop harvesting from a given spot
        /// Use when leaving a spot
        /// </summary>
        /// <param name="person"></param>
        /// <param name="spot"></param>
        /// <returns></returns>
        public static bool StopHarvestFromSpot(Job person, HarvestSpot spot)
        {
            if (person.JobType == spot.harvesterType)
            {
                foreach (ResourceBehaviours behaviour in spot.resources.MyResourceBehaviours)
                {
                    person.actor.RemoveBehaviour(behaviour, spot);
                }
                return true;
            }
            else return false;
        }


        /// <summary>
        /// Needs more resource methods
        /// </summary>
        /// <param name="person"></param>
        /// <param name="spot"></param>
        /// <returns></returns>
        public static bool TakeFromSpot(Job person, HarvestSpot spot)
        {
            return false;
        }

    }
}
