using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;
using UnityEditorInternal;

namespace Map.building
{
    public class SettlementBuildingList : MonoBehaviour
    {
    }
    public enum SettlementBuildingEnumList
    {
        School = 1 << 0,
        DefensePost = 1 << 1,
        Shop = 1 << 2,
        University = 1 << 3,
        TradingPost = 1 << 4,
        Barracks = 1 << 5,
        Library = 1 << 6,
    }

    //NotFinal, delete maybe??
    public enum NonupgradedSettlementBuildingList
    {
        School = 1 << 0,
        DefensePost = 1 << 1,
        Shop = 1 << 2,
        Barracks = 1 << 5,
        Library = 1 << 6,
    }

    public enum UpgradedSettlementBuildingList
    {
        University = 1 << 3,
        TradingPost = 1 << 4,
    }
}
