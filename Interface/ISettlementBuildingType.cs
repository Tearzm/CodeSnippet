using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Map.building
{
    public interface ISettlementBuildingType
    {

        SettlementBuildingEnumList BuildingType { get; set; }
    }
}
