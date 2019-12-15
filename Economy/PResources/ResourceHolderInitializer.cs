using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PResources
{
    [System.Serializable]
    public struct ResourceInit
    {
        [SerializeField]
        public ResourceTypes _resourceTypes;

        [SerializeField]
        [Tooltip("0 is unlimited")]
        public int _MaxResource;
    }

    [System.Serializable]
    [CreateAssetMenu(fileName = "ResourceHolder", menuName = "Economy/ResourceHolder")]
    public class ResourceHolderInitializer : ScriptableObject
    {
        [SerializeField]
        public List<ResourceInit> resources = new List<ResourceInit>();
    }
}
