using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Map.building
{
    public class BuildQueueManager
    {

        private List<CurrentlyBuilding> currentBuildings;


        public BuildQueueManager()
        {
            currentBuildings = new List<CurrentlyBuilding>();
        }


        /// <summary>
        /// Add a building to building queue;
        /// </summary>
        /// <param name="s"></param>
        public void AddToBuildingsQueue(SettlementBuildingInit s)
        {
            currentBuildings.Add(new CurrentlyBuilding(s));
            currentBuildings.Sort(CompareRemainingBuildOrder);
        }

        /// <summary>
        /// Remove a building from the building queue
        /// </summary>
        /// <param name="s"></param>
        public void RemoveFromBuildingQueue(SettlementBuildingInit s)
        {
            
            currentBuildings.RemoveAll(e => (e.settlementBuildingInit == s));
            currentBuildings.Sort(CompareRemainingBuildOrder);
        }

        public List<SettlementBuildingInit> PassTurn()
        {
            List<SettlementBuildingInit> doneBuilding = new List<SettlementBuildingInit>();
            for (int i = currentBuildings.Count - 1; i >= 0; i--)
            {
                currentBuildings[i].remainingTime--;
                if (currentBuildings[i].remainingTime <= 0)
                {
                    doneBuilding.Add(currentBuildings[i].settlementBuildingInit);
                    currentBuildings.RemoveAt(i);
                }
            }
            return doneBuilding;
        }

        protected int CompareRemainingBuildOrder(CurrentlyBuilding a, CurrentlyBuilding b)
        {
            if (a.remainingTime < b.remainingTime)
                return -1;
            else if (a.remainingTime > b.remainingTime)
                return 1;
            return 0;
        }
    }

    
}
