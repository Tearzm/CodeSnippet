using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PResources;

namespace Map.building
{
    [CreateAssetMenu(fileName = "NewHarvestSpot", menuName = "Map/Harvest/HarvestSpot")]
    public class HarvestSpotInit : ScriptableObject
    {
        [SerializeField]
        public ResourceTypes harvestType;
        [SerializeField]
        public JobTypesList harvesterType;
        [SerializeField]
        public int efficiency;
        [SerializeField]
        public List<ResourceBehaviour> ResourceBehavioursInit;

    }
}
