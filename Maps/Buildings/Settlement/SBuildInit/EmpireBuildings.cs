using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Map.building
{
    [CreateAssetMenu(fileName = "NewEmpireBuildingList", menuName = "Map/Empire/SettlementBuildings")]
    public class EmpireBuildings : ScriptableObject
    {
        [SerializeField] string Name;
        [SerializeField] public List<SettlementBuildingInit> AllBuildings;
    }
}
