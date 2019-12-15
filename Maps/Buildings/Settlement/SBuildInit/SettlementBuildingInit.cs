using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pops;
using PResources;

namespace Map.building
{
    public class SettlementBuildingInit : ScriptableObject, ISettlementBuildingType
    {
        [SerializeField]
        public string Bname;

        [SerializeField]
        [TextArea]
        private string Description;

        [SerializeField]
        [Space]
        public ResourceHolderInitializer Cost;

        [SerializeField]
        public int TrainTime;

        [SerializeField]
        [Space]
        public DefaultJobs buildingJobs;

        [SerializeField]
        public List<SettlementBuildingEnumList> requiredBuildings;

        public virtual SettlementBuildingEnumList BuildingType { get; set; }
    }
}
