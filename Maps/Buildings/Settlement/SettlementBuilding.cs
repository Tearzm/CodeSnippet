using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pops;
using Interactions;

namespace Map.building
{
    public class SettlementBuilding : PBuilding
    {

        private Settlement mySettlement;

        private SettlementBuildingEnumList type;

        public SettlementBuildingEnumList Type { get { return type; } }

        public SettlementBuilding(Settlement settlement, SettlementBuildingInit init)
        {
            mySettlement = settlement;
            type = init.BuildingType;
        }

        public override void EnterRegion(Person person)
        {
            base.EnterRegion(person);

            //for debugging
            Debug.Log(Type);
        }

    }
}
