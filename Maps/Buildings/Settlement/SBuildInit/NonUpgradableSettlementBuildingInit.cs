using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Map.building
{
    [CreateAssetMenu(fileName = "NewBuilding", menuName = "Map/Buildings/SettlementBuilding-NonUpgraded")]
    public class NonUpgradableSettlementBuildingInit : SettlementBuildingInit, ISettlementBuildingType
    {
        [SerializeField]
        public NonupgradedSettlementBuildingList newBuilding;


        public override SettlementBuildingEnumList BuildingType { get { return (SettlementBuildingEnumList)newBuilding; } set { newBuilding = (NonupgradedSettlementBuildingList)value; } }

    }
}
