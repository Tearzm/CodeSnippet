using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.ObjectModel;

namespace PResources
{
    public class Resource
    {

        private float _value;

        private float MaxValue;

        //Contains resource gathering and consuming data for each turn
        //For example a farm that increases food +2 every turn will add a tick of 2 to the food resource
        protected readonly List<Tick> ticks;
        public readonly ReadOnlyCollection<Tick> Ticks;

        public float value { get { return _value; } }
        public float maxValue { get { return MaxValue; } }

        public Resource()
        {
            ticks = new List<Tick>();
            Ticks = ticks.AsReadOnly();
            _value = 0;

            MaxValue = -1;
        }
        public Resource(float maxValue) : this()
        {
            MaxValue = maxValue;
        }

        public Resource(float value, float maxValue) : this()
        {
            _value = value;
            MaxValue = maxValue;
        }

        /// <summary>
        /// Adds a tick
        /// </summary>
        /// <param name="tick"></param>
        public void AddTick(Tick tick)
        {
            if (HasTick(tick)) return;
            ticks.Add(tick);
        }

        public bool RemoveTick(Tick tick)
        {
            if (ticks.Remove(tick)) return true;
            return false;
        }

        /// <summary>
        /// Removes a tick from given source if found
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public bool RemoveTickBySource(object source)
        {
            bool removed = false;
            for (int i = ticks.Count - 1; i >= 0; i--)
            {
                if(ticks[i].Source == source)
                {
                    removed = true;
                    ticks.RemoveAt(i);
                }
            }
            return removed;
        }


        /// <summary>
        /// Get all ticks values of a specific tickType
        /// </summary>
        /// <param name="tickType"></param>
        /// <returns></returns>
        public float GetTicks(TickTypes tickType)
        {
            float t = 0;
            for (int i = ticks.Count - 1; i >= 0; i--)
            {
                if(ticks[i].TickType == tickType)
                    t += ticks[i].Value;
            }
            return t;
        }

        /// <summary>
        /// Called when a gathered resource is returned to stockpile
        /// </summary>
        /// <param name="value">add ammount to current resource</param>
        public void MergeResource(float value)
        {
            _value += value;
            CheckIfMaxed(_value);
        }

        /// <summary>
        /// Called when a new turn is started
        /// </summary>
        public void ApplyTicks()
        {
            for (int i = ticks.Count - 1; i >= 0; i--)
            {
                _value += ticks[i].Value;
            }
            CheckIfMaxed(_value);
        }

        public bool HasTick(Tick tick)
        {
            for (int i = ticks.Count - 1; i >= 0; i--)
            {
                if (tick.Source == ticks[i].Source) return true;
            }
            return false;
        }


        /// <summary>
        /// Empty a resource and all its ticks
        /// </summary>
        /// <returns></returns>
        public float Empty()
        {
            
            float v = _value;
            _value = 0;
            return v;
        }

        /// <summary>
        /// Empty a resource without stopping all it's behaviours
        /// </summary>
        /// <returns></returns>
        public float Empty(bool a)
        {
            if (a)
                ticks.Clear();
            float v = _value;
            _value = 0;
            return v;
        }

        private void CheckIfMaxed(float v)
        {
            if (MaxValue != -1 && v > MaxValue) _value = MaxValue;
        }
    }
}