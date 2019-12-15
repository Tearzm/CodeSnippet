using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PResources
{
    [System.Serializable]
    public struct behaviour
    {
        [SerializeField]
        public ResourceTypes rType;
        [SerializeField]
        public int value;
        [SerializeField]
        public BehaviourType type;
    }

    public enum BehaviourType
    {
        Additive,
        Subtructive,
    }

    [System.Serializable]
    [CreateAssetMenu(fileName = "ResourceBehaviour", menuName = "Economy/ResourceBehaviour")]
    public class ResourceBehaviour : ScriptableObject
    {
        [SerializeField]
        public List<behaviour> behaviours = new List<behaviour>();
    }
}
