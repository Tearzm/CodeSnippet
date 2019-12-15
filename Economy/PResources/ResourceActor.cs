using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Map.building;

namespace PResources
{
    [System.Serializable]
    public class ResourceActor
    {
        [HideInInspector]
        public ResourceHolder MyResources;

        [HideInInspector]
        public List<ResourceBehaviours> MyResourceBehaviours;

        /// <summary>
        /// Instantiate a new Resource container or behaviour.
        /// Requires two scriptable objects of type ResourceHolder and ResourceBehaviour
        /// </summary>
        /// <param name="rhi">Resource Holder</param>
        /// <param name="mrb">Resource Behaviour</param>
        public ResourceActor(ResourceHolderInitializer rhi, List<ResourceBehaviour> mrb)
        {
            MyResourceBehaviours = new List<ResourceBehaviours>();

            MyResources = new ResourceHolder(rhi);
            for (int i = 0; i < mrb.Count; i++)
            {
                MyResourceBehaviours.Add(new ResourceBehaviours(mrb[i]));
            }
        }

        public ResourceActor()
        {
            MyResourceBehaviours = new List<ResourceBehaviours>();
        }

        public ResourceActor(bool isTrader)
        {
            MyResources = new ResourceHolder(true);
            MyResourceBehaviours = new List<ResourceBehaviours>();
        }

        public ResourceActor(List<ResourceBehaviour> mrb)
        {
            MyResources = new ResourceHolder(true);
            MyResourceBehaviours = new List<ResourceBehaviours>();
            for (int i = 0; i < mrb.Count; i++)
            {
                MyResourceBehaviours.Add(new ResourceBehaviours(mrb[i]));
            }
        }

        /// <summary>
        /// Returns the value of a given resource type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public float GetValue(ResourceTypes type)
        {
            if (MyResources.Get(type) != null) return MyResources.Get(type).value;
            else return 0;
        }

        /// <summary>
        /// Return maximum value of a given resource type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public float GetMaxValue(ResourceTypes type)
        {
            if (MyResources.Get(type) != null) return MyResources.Get(type).maxValue;
            else return 0;
        }

        /// <summary>
        /// Steal from this Resource holder and return all stolen resources
        /// </summary>
        /// <returns></returns>
        public ResourceHolder Steal()
        {
            ResourceHolder StolenResources = new ResourceHolder(MyResources);
            return StolenResources;
        }

        public void Destroy(ResourceHolder rh)
        {
            MyResources.AddListOfResources(rh);
            rh.EmptyHolder(true);
        }

        /// <summary>
        /// Add a list of stolen resources to this Resource Actor
        /// Discard anything above maximum capacity
        /// </summary>
        /// <param name="rh"></param>
        public void Stolen(ResourceHolder rh)
        {
            MyResources.AddListOfResources(rh);
            rh.EmptyHolder();
        }

        /// <summary>
        /// Add a given amount to a resource holder
        /// </summary>
        /// <param name="_type"></param>
        /// <param name="_v"></param>
        public void AddResource(ResourceTypes _type,float _v)
        {
            MyResources.AddToResource(_type, _v);
        }

        /// <summary>
        /// Add a given set of resources to a resource holder
        /// </summary>
        /// <param name="r"></param>
        public void AddResources(Dictionary<ResourceTypes, int> r)
        {
            foreach (var item in r) AddResource(item.Key, item.Value);
        }

        /// <summary>
        /// Add a behaviour to a resource holder
        /// </summary>
        /// <param name="resourceBehaviour"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public bool AddBehaviour(ResourceBehaviours resourceBehaviour, object source)
        {
            List<PResources.Resource> temp;
            List<ResourceTypes> types = new List<ResourceTypes>();
            foreach (behaviour b in resourceBehaviour.behaviours)
            {
                if (b.type == BehaviourType.Subtructive) types.Add(b.rType);
            }
            if(MyResources.GetResourceList(types, out temp))
            {
                foreach(behaviour b in resourceBehaviour.behaviours)
                {
                    if (b.type == BehaviourType.Additive)
                        MyResources.AddTick(b.rType, source, b.value);
                    else if(b.type == BehaviourType.Subtructive)
                        MyResources.AddTick(b.rType, source, b.value);
                }
                return true;
            }
            return false;
        }


        /// <summary>
        /// Removes a behaviour from the specific source
        /// </summary>
        /// <param name="resourceBehaviour"></param>
        /// <param name="source"></param>
        public void RemoveBehaviour(ResourceBehaviours resourceBehaviour, object source)
        {
            foreach (behaviour b in resourceBehaviour.behaviours)
            {
                MyResources.RemoveTick(b.rType, source);
            }
        }

        /// <summary>
        /// Buy with a given resource holder as a price
        /// Cut this resource actor by a negative amount of the given resource holder
        /// </summary>
        /// <param name="resourceHolder"></param>
        /// <returns></returns>
        public bool Buy(ResourceHolder resourceHolder)
        {
            return MyResources.CutResources(resourceHolder);
        }

        public bool Buy(Dictionary<ResourceTypes, int> r)
        {
            return MyResources.CutResources(r);
        }

        /// <summary>
        /// Cut this resource actor by the amount of the building cost
        /// positive amount are considred as negative
        /// for example a build with 2 food cost and 3 iron cost will remove 2food and 3iron from this resource holder
        /// </summary>
        /// <param name="building"></param>
        /// <returns></returns>
        public bool Buy(SettlementBuildingInit building)
        {
            
            return MyResources.CutResources(new ResourceHolder(building.Cost));
        }



        public bool HasResources(ResourceHolder rh)
        {
            return (MyResources.CheckResources(rh));
        }

        public bool HasResources(SettlementBuildingInit building)
        {
            return (MyResources.CheckResources(new ResourceHolder(building.Cost)));
        }


        /// <summary>
        /// Apply every tick to each Resource and change their values
        /// Call on turn's end or start
        /// </summary>
        public void EndTurn()
        {
            MyResources.Applyticks();
        }
    }
}