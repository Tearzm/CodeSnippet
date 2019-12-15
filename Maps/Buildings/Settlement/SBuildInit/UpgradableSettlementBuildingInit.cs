using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Map.building
{
    [CreateAssetMenu(fileName = "NewBuilding", menuName = "Map/Buildings/SettlementBuilding-Upgraded")]
    public class UpgradableSettlementBuildingInit : SettlementBuildingInit, ISettlementBuildingType
    {
        [SerializeField]
        public UpgradedSettlementBuildingList newBuilding;

        [SerializeField]
        public SettlementBuildingEnumList oldBuilding;

        public override SettlementBuildingEnumList BuildingType { get { return (SettlementBuildingEnumList)newBuilding; } set { newBuilding = (UpgradedSettlementBuildingList)value; } }

       
    }
}
