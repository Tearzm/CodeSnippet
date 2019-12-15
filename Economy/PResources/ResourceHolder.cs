using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PResources
{
    
    public class ResourceHolder
    {
        [HideInInspector]
        private Dictionary<ResourceTypes, PResources.Resource> resources;

        public ResourceHolder(ResourceHolderInitializer rh)
        {
            resources = new Dictionary<ResourceTypes, Resource>();
            for (int i = 0; i < rh.resources.Count; i++)
            {    
                if (rh.resources[i]._MaxResource == 0)
                    resources.Add((rh.resources[i]._resourceTypes), new Resource());
                else
                    resources.Add((rh.resources[i]._resourceTypes), new Resource(rh.resources[i]._MaxResource));
            }
        }


        /// <summary>
        /// Not yet fully implemented
        /// </summary>
        /// <param name="rh"></param>
        /// <param name="isCost"></param>
        public ResourceHolder(ResourceHolderInitializer rh, bool isCost)
        {
            resources = new Dictionary<ResourceTypes, Resource>();
            if (!isCost)
            {
                NormalInitialize(rh);
            }
            else
            {
                for (int i = 0; i < rh.resources.Count; i++)
                {
                    resources.Add((rh.resources[i]._resourceTypes), new Resource(rh.resources[i]._MaxResource,10000));
                }
            }
        }

        public ResourceHolder(bool isTrader)
        {
            resources = new Dictionary<ResourceTypes, Resource>();
            if (isTrader)
            {
                foreach (ResourceTypes r in System.Enum.GetValues(typeof(ResourceTypes)))
                {
                    resources.Add(r, new Resource());
                }
            }
        }

        
        public ResourceHolder()
        {
            resources = new Dictionary<ResourceTypes, Resource>();
        }

        //Needs fixing, DOESN'T CLONE GIVEN HOLDER BUT REFERNECE IT.
        public ResourceHolder(ResourceHolder holder)
        {
            resources = new Dictionary<ResourceTypes, Resource>(holder.resources);
        }

        private void NormalInitialize(ResourceHolderInitializer rh)
        {
            for (int i = 0; i < rh.resources.Count; i++)
            {
                if (rh.resources[i]._MaxResource == 0)
                    resources.Add((rh.resources[i]._resourceTypes), new Resource());
                else
                    resources.Add((rh.resources[i]._resourceTypes), new Resource(rh.resources[i]._MaxResource));
            }
        }

        public void EmptyHolder()
        {
            foreach (var item in resources) item.Value.Empty();
        }


        public void EmptyHolder(bool a)
        {
            foreach (var item in resources) item.Value.Empty(a);
        }

        public PResources.Resource Get(ResourceTypes _type)
        {
            if (resources.ContainsKey(_type)) return resources[_type];
            else return null;
        }

        /// <summary>
        /// Add given resource to a resource holder
        /// Loses everything if resource holder is full
        /// </summary>
        /// <param name="_type"></param>
        /// <param name="_value"></param>
        public void AddToResource (ResourceTypes _type, float _value)
        {
            if (resources.ContainsKey(_type)) resources[_type].MergeResource(_value);   
        }

        /// <summary>
        /// Return a list of resources of the given Types list
        /// </summary>
        /// <param name="resourceTypes"></param>
        /// <param name="_list"></param>
        /// <returns></returns>
        public bool GetResourceList(List<ResourceTypes> resourceTypes, out List<PResources.Resource> _list)
        {
            _list = new List<PResources.Resource>();
            foreach(ResourceTypes r in resourceTypes)
            {
                if (resources.ContainsKey(r)) _list.Add(resources[r]);
                else return false;
            }
            return true;
        }


        public void AddListOfResources(ResourceHolder rh)
        {
            foreach (var item in rh.resources) AddToResource((ResourceTypes)item.Key, item.Value.value); 
        }

        public bool AddTick(ResourceTypes _type, object _source, float _v)
        {
            if (resources.ContainsKey(_type))
            {
                resources[_type].AddTick(new Tick(_v, _source));
                return true;
            }
            return false;
        }

        public bool RemoveTick(ResourceTypes _type, object _source)
        {
            if (resources.ContainsKey(_type))
            {
                return resources[_type].RemoveTickBySource(_source);
            }
            return false;
        }

        public void Applyticks()
        {
            foreach (PResources.Resource r in resources.Values) r.ApplyTicks();
        }

        /// <summary>
        /// Cut resource by a negative amount of RH
        /// Needs better code
        /// Needs replacing maxValue for _value
        /// </summary>
        /// <param name="rh"></param>
        /// <returns></returns>
        public bool CutResources(ResourceHolder rh)
        {
            foreach(var item in rh.resources)
            {
                if (item.Value.maxValue > resources[item.Key].value) return false;
            }
            foreach(var item in rh.resources)
            {
                AddToResource(item.Key, -item.Value.maxValue);
            }
            return true;
        }

        public bool CutResources(Dictionary<ResourceTypes, int> _resources)
        {
            foreach(var item in _resources)
            {
                if ((!resources.ContainsKey(item.Key)) || (resources[item.Key].value < item.Value)) return false;
            }
            foreach (var item in _resources) resources[item.Key].MergeResource(-item.Value);
            return true;
        }

        public bool CheckResources(ResourceHolder rh)
        {
            foreach (var item in rh.resources)
            {
                if (item.Value.maxValue > resources[item.Key].value) return false;
            }
            return true;
        }
    }
}