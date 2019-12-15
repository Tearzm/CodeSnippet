using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PResources
{
    [System.Serializable]
    public class ResourceBehaviours
    {
       
        [HideInInspector]
        public List<behaviour> behaviours;

        public ResourceBehaviours(ResourceBehaviour rh)
        {
            behaviours = new List<behaviour>(rh.behaviours);
        }
    }
}
