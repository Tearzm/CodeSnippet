using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PResources
{
    //Not used yet
    public enum TickTypes
    {
        Additive,
        Subtractive,
    }

    public class Tick
    {
        public readonly float Value;
        public readonly object Source;
        public readonly TickTypes TickType;

        public Tick (float value, object source)
        {
            Value = value;
            Source = source;
        }
        public Tick(float value, TickTypes tickType, object source)
        {
            Value = value;
            TickType = tickType;
            Source = source;
        }

    }
}
