using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PResources;
using Pops;
using Interactions;

namespace Map.building
{
    public class Settlement : PBuilding
    {

        public string SettlementName;
        public string SettlementDescription;

        private List<SettlementBuilding> myBuildings;
        public ResourceActor settlementResources { get { return base.resources; } set { base.resources = value; } }

        private BuildQueueManager buildManager;
        private PopsManager popsManager;
        private List<SettlementBuildingInit> allBuildings;

        private Settlement()
        {
            SettlementName = "Settlement";
            SettlementDescription = "New Settlement";
        }

        public Settlement(DefaultJobs jobs, ResourceHolderInitializer rhi, List<ResourceBehaviour> rbi) : this()
        {
            buildManager = new BuildQueueManager();
            myBuildings = new List<SettlementBuilding>();
            settlementResources = new ResourceActor(rhi, rbi);
            popsManager = new PopsManager(jobs, settlementResources, 20);
            
        }

        public Settlement(DefaultJobs jobs, ResourceHolderInitializer rhi, List<ResourceBehaviour> rbi, int MaxPops) : this()
        {
            buildManager = new BuildQueueManager();
            myBuildings = new List<SettlementBuilding>();
            settlementResources = new ResourceActor(rhi, rbi);
            popsManager = new PopsManager(jobs, settlementResources, MaxPops);
        }


        public Settlement(DefaultJobs jobs, ResourceHolderInitializer rhi, List<ResourceBehaviour> rbi, List<SettlementBuildingInit> allbuildings) : this(jobs, rhi, rbi)
        {
            allBuildings = allbuildings;
        }

        public Settlement(DefaultJobs jobs, ResourceHolderInitializer rhi, List<ResourceBehaviour> rbi, EmpireBuildings allbuildings) : this(jobs, rhi, rbi, allbuildings.AllBuildings) { }

        /// <summary>
        /// Lists all building that can be build on this settlement
        /// </summary>
        /// <returns></returns>
        public List<SettlementBuildingInit> availableBuildings()
        {
            List<SettlementBuildingInit> settlements = new List<SettlementBuildingInit>();
            foreach(SettlementBuildingInit s in allBuildings)
            {
                if (canBuild(s)) settlements.Add(s);
            }
            return settlements;
        }

        public DefaultJobs availableJobs()
        {
            return popsManager.availableJobs();
        }



        /// <summary>
        /// Add a building to the current building queue
        /// </summary>
        /// <param name="s"></param>
        public bool AddBuilding(SettlementBuildingInit s)
        {
            if (canBuild(s))
            {
                if (settlementResources.Buy(s))
                {
                    AddToBuildingQueue(s);
                    Debug.Log("Building" + s.Bname);
                    //myBuildings.Add();
                }
            }
            return false;
        }


        /// <summary>
        /// Stop building this building
        /// </summary>
        /// <param name="s"></param>
        public void StopBuilding(SettlementBuildingInit s)
        {
            RemoveFromBuildingQueue(s);
        }


        /// <summary>
        /// Needs heavy optimization
        /// Needs debugging (s as settlement) might not work......
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private bool canBuild(SettlementBuildingInit s)
        {
            bool okie;
            okie = true;
            foreach (SettlementBuildingEnumList rs in s.requiredBuildings)
            {
                if (!HasBuildingOfType(rs)) okie = false;

            }
            if (s is UpgradableSettlementBuildingInit)
            {
                if (!HasBuildingOfType((s as UpgradableSettlementBuildingInit).oldBuilding)) okie = false;
            }
            if (!HasSufficientResources(s)) okie = false;
            return okie;
        }

        /// <summary>
        /// Check if you has suffiecent resources for this building
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool HasSufficientResources(SettlementBuildingInit s)
        {
            return (settlementResources.HasResources(s));
        }

        /// <summary>
        /// Build a new pop of the given type
        /// </summary>
        /// <param name="_type"></param>
        public void BuildPop(JobTypesList _type)
        {
            popsManager.BuildANewPop(_type);
        }

        /// <summary>
        /// Add a unit resources to the settlement
        /// </summary>
        /// <param name="ra"></param>
        public void ReachSettlement(ResourceActor ra)
        {
            settlementResources.Stolen(ra.Steal());
        }


        public void PassTurn()
        {
            popsManager.PassTurn();
            AddBuildings(buildManager.PassTurn());

        }

        private void AddBuildings(List<SettlementBuildingInit> buildings)
        {
            foreach (SettlementBuildingInit building in buildings) doneBuilding(building);
        }


        /// <summary>
        /// needs more stuff
        /// </summary>
        /// <param name="s"></param>
        private void doneBuilding(SettlementBuildingInit s)
        {
            Debug.Log("Done Building " + s.Bname);
            //myBuildings.Add()
            popsManager.AddJobs(s.buildingJobs);
        }

        private bool HasBuildingOfType(SettlementBuildingEnumList b)
        {
            foreach (SettlementBuilding sb in myBuildings) if (BuildingTypeComparer(sb, b)) return true;
            return false;
        }

        private bool BuildingTypeComparer(SettlementBuilding a, SettlementBuildingEnumList b)
        {
            if (a.Type == b) return true;
            return false;
        }

        private void AddToBuildingQueue(SettlementBuildingInit s)
        {
            buildManager.AddToBuildingsQueue(s);
        }

        private void RemoveFromBuildingQueue(SettlementBuildingInit s)
        {
            buildManager.RemoveFromBuildingQueue(s);
        }

        ////////////////////////////////////////INTERFACE INTERACTIONS////////////////////////////////////////////////////

            /// <summary>
            /// Invoke when a person enters a settlement
            /// </summary>
            /// <param name="person"></param>
        public override void EnterSettlement(Person person)
        {
            //base.EnterSettlement(person);
            if (person.myJob is IHarvestinteraction)
            {
                Harvest.Deliver(person.myJob, resources);
            }
        }

        /// <summary>
        /// invoke all buildings inside a settlement when a person enters
        /// </summary>
        /// <param name="person"></param>
        public override void EnterRegion(Person person)
        {
            foreach (SettlementBuilding building in myBuildings)
            {
                building.EnterRegion(person);
            }
        }


    }

}

