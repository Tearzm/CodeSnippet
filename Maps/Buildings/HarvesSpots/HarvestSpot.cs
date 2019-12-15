using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PResources;
using Pops;
using Interactions;

namespace Map.building
{
    public class HarvestSpot : PBuilding
    {
        private ResourceActor HarvestingResources { get { return base.resources; } set { base.resources = value; } }

        public ResourceTypes harvestType;
        public JobTypesList harvesterType;
        public int efficiency;

        private bool isNull;

        /// <summary>
        /// Create a new harvesting spot
        /// </summary>
        /// <param name="rhi"></param>
        public HarvestSpot(List<ResourceBehaviour> rbi, int e)
        {
            HarvestingResources = new ResourceActor(rbi);
            efficiency = e;
            isNull = true;
        }

        /// <summary>
        /// Create a new harvesting spot where you can harvest of R type
        /// </summary>
        /// <param name="rhi"></param>
        /// <param name="r">Type of resource you can get from this spot</param>
        public HarvestSpot(List<ResourceBehaviour> rbi, int e, ResourceTypes r) : this(rbi, e)
        {
            harvestType = r;
            
        }

        /// <summary>
        /// Create a new harvesting spot where you can harvest of R type by a job of type H
        /// </summary>
        /// <param name="rhi"></param>
        /// <param name="r">Type of resource you can get from this spot</param>
        /// <param name="h">Type of job who can harvest from here</param>
        public HarvestSpot(List<ResourceBehaviour> rbi, int e, ResourceTypes r, JobTypesList h) : this(rbi, e, r)
        {
            harvesterType = h;
            isNull = false;
        }

        public HarvestSpot(HarvestSpotInit rsi)
        {
            HarvestingResources = new ResourceActor(rsi.ResourceBehavioursInit);
            efficiency = rsi.efficiency;
            harvestType = rsi.harvestType;
            harvesterType = rsi.harvesterType;
            isNull = false;
        }

        /// <summary>
        /// Invoke when a person enters a new harvest spot
        /// </summary>
        /// <param name="person"></param>
        public override void EnterRegion(Person person)
        {
            if(!isNull)
            {
                Harvest.HarvestFromSpot(person.myJob, this);
            }
            else
            {
                Harvest.TakeFromSpot(person.myJob, this);
            }
        }


        /// <summary>
        /// Invoke when a person leaves a harvest spot
        /// </summary>
        /// <param name="person"></param>
        public override void LeaveRegion(Person person)
        {
            if(!isNull)
            {
                Harvest.StopHarvestFromSpot(person.myJob, this);
            }
            else
            {
                
            }
        }

    }
}
