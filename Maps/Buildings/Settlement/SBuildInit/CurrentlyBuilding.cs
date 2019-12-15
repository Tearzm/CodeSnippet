using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Map.building
{
    public class CurrentlyBuilding
    {
        public int remainingTime;
        public SettlementBuildingInit settlementBuildingInit;

        public CurrentlyBuilding(SettlementBuildingInit s)
        {
            settlementBuildingInit = s;
            remainingTime = s.TrainTime;
        }
    }
}
